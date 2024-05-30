namespace BoldReports.Server.ORM
{
    using System;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Xml;
    using Npgsql;

    using BoldReports.Server.Base.DataClasses;
    public class PostgreSQLConnectionHelper : IDatabaseConnectionHelper
    {
        public PostgreSQLConnectionHelper()
        {
        }

        public async Task<Result> CheckDatabaseExists(string connectionString, string databaseName, int retryCount = 0)
        {
            var result = new Result();
            try
            {
                var sqlCreateDbQuery = string.Format("SELECT datname FROM pg_catalog.pg_database WHERE lower(datname)='{0}'", databaseName.ToLower());
                using (var tmpConn = new NpgsqlConnection(connectionString))
                {
                    using (var sqlCmd = new NpgsqlCommand(sqlCreateDbQuery, tmpConn))
                    {
                        var dataTable = new DataTable();
                        dataTable.Locale = CultureInfo.InvariantCulture;
                        await sqlCmd.Connection.OpenAsync();
                        using (var reader = await sqlCmd.ExecuteReaderAsync())
                        {
                            using (DataSet dataSet = new DataSet() { EnforceConstraints = false })
                            {
                                dataSet.Tables.Add(dataTable);
                                dataTable.Load(reader, LoadOption.OverwriteChanges);
                                dataSet.Tables.Remove(dataTable);
                            }
                        }

                        result.Status = true;
                        result.ReturnValue = dataTable.Rows.Count > 0;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                retryCount++;
                if (retryCount <= 3)
                {
                    //LogExtension.LogInfo(string.Empty, "Retrying operation for " + retryCount + "time", MethodBase.GetCurrentMethod());
                    return await CheckDatabaseExists(connectionString, databaseName, retryCount);
                }
                else
                {
                    result.Status = false;
                    result.Exception = ex;
                }
            }

            return result;
        }

        public async Task<Result> CreateDabase(string connectionString, string databaseName, int retryCount = 0)
        {
            var dbCreationScript = "CREATE DATABASE \"" + databaseName + "\" with LC_COLLATE = \"" + DefaultCollation.PostgrSQLCollation + "\" template template0;";
            var result = new Result();
            do
            {
                var connection = new NpgsqlConnection(connectionString);                
                    try
                    {
                        var command = new NpgsqlCommand(dbCreationScript, connection);
                        command.CommandTimeout = DataConfig.CommandTimeout;
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        result.Status = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (Convert.ToBoolean((await CheckDatabaseExists(connectionString, databaseName)).ReturnValue))
                        {
                            result.Status = true;
                            break;
                        }
                        else
                        {
                            retryCount++;
                            if (retryCount >= 3)
                            {
                                result.Status = false;
                                result.Exception = ex;
                                return result;
                            }

                            continue;
                        }
                    }
                    finally
                    {
                        await connection.CloseAsync();
                        await connection.DisposeAsync();
                    }               
            }
            while (retryCount <= 3);

            return result;
        }

        public async Task<Result> CreateTableInDatabase(string connectionString, string tableScript, int retryCount = 0)
        {
            var splitter = new[] { ";" };
            var result = new Result();
            var commandTexts = tableScript.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

            foreach (string commandText in commandTexts)
            {
                retryCount = 0;
                do
                {
                    var connectionForTables = new NpgsqlConnection(connectionString);
                    try
                    {
                        using (var command = new NpgsqlCommand(commandText, connectionForTables))
                        {
                            command.CommandTimeout = DataConfig.CommandTimeout;
                            await connectionForTables.OpenAsync();
                            await command.ExecuteNonQueryAsync();
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        retryCount++;
                        if (retryCount >= 3)
                        {
                            result.Status = false;
                            result.Exception = ex;
                            return result;
                        }

                        continue;
                    }
                    finally
                    {
                        await connectionForTables.CloseAsync();
                    }
                }
                while (retryCount <= 3);
            }

            result.Status = true;
            return result;
        }

        public async Task<Result> DeleteDatabase(string connectionString, string databaseName, XmlNodeList nodeList, string maintenanceDatabase = null)
        {
            var result = new Result();
            var tryCount = 0;
            do
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        var builder = new NpgsqlConnectionStringBuilder(connectionString);
                        var tableCountScript = "SELECT COUNT(*) from information_schema.tables where table_schema = 'public'";
                        foreach (XmlNode values in nodeList)
                        {
                            var commandScript = "drop table " + values.InnerText + ";";
                            using (var command = new NpgsqlCommand(commandScript, connection))
                            {
                                await command.ExecuteNonQueryAsync();
                            }
                        }

                        var cmd = new NpgsqlCommand(tableCountScript, connection);
                        var tableCount = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        var defaultDatabase = ";Database=" + maintenanceDatabase;
                        if (tableCount == 0)
                        {
                            using (var connections = new NpgsqlConnection(connectionString + defaultDatabase))
                            {
                                var sqlterminateDbQuery = string.Format("SELECT pg_terminate_backend(pg_stat_activity.pid) FROM pg_stat_activity WHERE pg_stat_activity.datname = '{0}'", builder.Database);

                                using (var command = new NpgsqlCommand(sqlterminateDbQuery, connections))
                                {
                                    await command.Connection.OpenAsync();
                                    await command.ExecuteNonQueryAsync();
                                }
                            }

                            using (var connections = new NpgsqlConnection(connectionString + defaultDatabase))
                            {
                                var script = "drop database \"" + builder.Database + "\";";
                                using (var command = new NpgsqlCommand(script, connections))
                                {
                                    await command.Connection.OpenAsync();
                                    await command.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }
                    catch (NpgsqlException ex)
                    {
                        tryCount++;
                        if (tryCount == 3)
                        {
                            result.Exception = ex;
                        }
                    }
                    finally
                    {
                        await connection?.CloseAsync();
                    }
                }
            }
            while (tryCount != 0 && tryCount < 3);

            result.Status = !(tryCount >= 3);
            return result;
        }

        public async Task<DataTable> ExecuteReaderQuery(string connectionString, string query, string prefix, string schema)
        {
            var dataTable = new DataTable();
            query = SetSchemaInQuery(query, prefix, schema);
            var npgConnection = new NpgsqlConnection(connectionString);
            var command = new NpgsqlCommand(query, npgConnection);
            try
            {
                await command.Connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    using (DataSet dataSet = new DataSet() { EnforceConstraints = false })
                    {
                        dataSet.Tables.Add(dataTable);
                        dataTable.Load(reader, LoadOption.OverwriteChanges);
                        dataSet.Tables.Remove(dataTable);
                    }
                }
            }
            catch (Exception e)
            {
                //LogExtension.LogError(string.Empty, "Exception on Getting PostgreSQL DatabaseSchema on Import users from database ", e, MethodBase.GetCurrentMethod(), "Executed query is : " + query);
                return null;
            }
            finally
            {
                await npgConnection.CloseAsync();
                await command.DisposeAsync();
            }

            return dataTable;
        }

        public Result GenerateConnectionStringFromDBCongifuration(DatabaseConfiguration databaseConfiguration, bool maskPassword = false, bool isSecondaryConnectionString = true)
        {
            var result = new Result();
            try
            {
                if (string.IsNullOrWhiteSpace(databaseConfiguration.ServerName))
                {
                    throw new ArgumentNullException("databaseConnection", "Server name is empty");
                }

                if (string.IsNullOrWhiteSpace(databaseConfiguration.Port))
                {
                    throw new ArgumentNullException("databaseConnection", "Port number is empty");
                }

                if (string.IsNullOrWhiteSpace(databaseConfiguration.UserName))
                {
                    throw new ArgumentNullException("databaseConnection", "User name is empty");
                }

                var postgreSQLBuilder = new NpgsqlConnectionStringBuilder()
                {
                    Host = databaseConfiguration.ServerName,
                    Port = Convert.ToInt32(databaseConfiguration.Port),
                    Database = isSecondaryConnectionString ? databaseConfiguration.DatabaseName ?? string.Empty : databaseConfiguration.MaintenanceDatabase,
                    Username = databaseConfiguration.UserName,
                    Password = maskPassword ? "******" : databaseConfiguration.Password,
                    SslMode = databaseConfiguration.SslEnabled ? SslMode.Require : SslMode.Prefer,
                    TrustServerCertificate = true,
                    ConnectionIdleLifetime = PostgreSqlConfig.ConnectionIdleLifetime,
                    ConnectionPruningInterval = PostgreSqlConfig.ConnectionPruningInterval
                };

                result.ReturnValue = postgreSQLBuilder.ConnectionString;
                result.Status = true;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Exception = ex;
                //LogExtension.LogError(string.Empty, "Error in getting connection string from DB configuration ", ex, MethodBase.GetCurrentMethod());
            }

            return result;
        }

        public Result GenerateDatabaseConfigurationFromConnecctionString(string connectionString, bool showPassword = false)
        {
            var result = new Result();
            try
            {
                var databaseDetails = new DatabaseConfiguration();
                var connectionBuilder = new NpgsqlConnectionStringBuilder(connectionString);
                databaseDetails.ServerName = connectionBuilder.Host;
                databaseDetails.DatabaseName = connectionBuilder.Database;
                databaseDetails.Port = connectionBuilder.Port.ToString();
                databaseDetails.UserName = connectionBuilder.Username;
                databaseDetails.ServerType = DatabaseType.PostgreSQL;
                databaseDetails.SslEnabled = connectionBuilder.SslMode == SslMode.Require;

                if (showPassword)
                {
                    databaseDetails.Password = connectionBuilder.Password;
                }

                result.ReturnValue = databaseDetails;
                result.Status = true;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Exception = ex;
                //LogExtension.LogError(string.Empty, "Error in generating DB configuration from connection string ", ex, MethodBase.GetCurrentMethod());
            }

            return result;
        }

        public async Task<Result> GetDatabaseList(DatabaseConfiguration databaseCredentials)
        {
            var dataTable = new DataTable();
            var result = new Result();
            var connectionString = GenerateConnectionStringFromDBCongifuration(databaseCredentials);
            if (connectionString.Status)
            {
                using (var connection = new NpgsqlConnection((string)connectionString.ReturnValue))
                {
                    var command = new NpgsqlCommand("SELECT distinct datname FROM pg_database", connection);
                    try
                    {
                        await command.Connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            using (DataSet dataSet = new DataSet() { EnforceConstraints = false })
                            {
                                dataSet.Tables.Add(result.DataTable);
                                result.DataTable.Load(reader, LoadOption.OverwriteChanges);
                                dataSet.Tables.Remove(result.DataTable);
                            }
                        }

                        result.ReturnValue =
                            dataTable.AsEnumerable().Select(s => s.Field<string>("datname").ToString()).ToList();

                        result.Status = true;
                    }
                    catch (Exception e)
                    {
                        //LogExtension.LogError(string.Empty, "Exception on ExecuteReaderQuery ", e, MethodBase.GetCurrentMethod());
                        result.Status = false;
                        result.Exception = connectionString.Exception;
                    }
                    finally
                    {
                        await connection.CloseAsync();
                        await command.DisposeAsync();
                    }
                }
            }
            else
            {
                result.Status = false;
                result.Exception = connectionString.Exception;
            }

            return result;
        }

        public async Task<Result> GetTableList(DatabaseConfiguration databaseCredentials)
        {
            var dataTable = new DataTable();
            var result = new Result();
            var connectionString = GenerateConnectionStringFromDBCongifuration(databaseCredentials);
            if (connectionString.Status)
            {
                using (var connection = new NpgsqlConnection((string)connectionString.ReturnValue))
                {
                    using (var adapter = new NpgsqlDataAdapter("SELECT * FROM pg_catalog.pg_tables WHERE schemaname != 'pg_catalog' AND schemaname != 'information_schema'; ", connection))
                    {
                        try
                        {
                            adapter.Fill(dataTable);
                            result.ReturnValue =
                                dataTable.AsEnumerable().Select(s => s.Field<string>("tablename").ToString().ToLower()).ToList();

                            result.Status = true;
                        }
                        catch (Exception e)
                        {
                            //LogExtension.LogError(string.Empty, "Exception on ExecuteReaderQuery.", e,
                                                  //MethodBase.GetCurrentMethod());
                            result.Status = false;
                            result.Exception = connectionString.Exception;
                        }
                        finally
                        {
                            adapter?.Dispose();
                            connection?.CloseAsync();
                            connection?.DisposeAsync();
                        }
                    }
                }
            }
            else
            {
                result.Status = false;
                result.Exception = connectionString.Exception;
            }

            return result;
        }

        public async Task<Result> IsValidConnection(string connectionString, int retryCount = 0)
        {
            var result = new Result();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                   // LogExtension.LogInfo(string.Empty, "Postgre SQL server connected successfully.", MethodBase.GetCurrentMethod());
                    result.Status = true;
                }
            }
            catch (Exception ex)
            {
                retryCount++;
                if (retryCount <= 3)
                {
                   // LogExtension.LogInfo(string.Empty, "Retrying operation for " + retryCount + "time",
                                        // MethodBase.GetCurrentMethod());
                    return await IsValidConnection(connectionString, retryCount);
                }
                else
                {
                    //LogExtension.LogInfo(string.Empty, "Invalid connection properties.", MethodBase.GetCurrentMethod());
                    result.Exception = ex;
                    result.Status = false;
                }
            }

            return result;
        }
        public async Task<Result> CreateSchemaAsync(string connectionString, string schemaName, int retryCount = 0)
        {
            var schemaCreationScript = $"CREATE SCHEMA {schemaName};";
            var result = new Result();

            do
            {
                var connection = new NpgsqlConnection(connectionString);

                try
                {
                    //LogExtension.LogInfo(string.Empty, "Creating schema in PostgreSQL.", MethodBase.GetCurrentMethod());
                    var command = new NpgsqlCommand(schemaCreationScript, connection);
                    command.CommandTimeout = DataConfig.CommandTimeout;
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    result.Status = true;
                    break;
                }
                catch (PostgresException ex)
                {
                    retryCount++;

                    if (retryCount >= 3)
                    {
                        result.Status = false;
                       //LogExtension.LogInfo(string.Empty, "Error in creating PostgreSQL schema.", MethodBase.GetCurrentMethod());
                        result.Exception = ex;
                        return result;
                    }

                    continue;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
            while (retryCount <= 3);

            return result;
        }
        public async Task<Result> IsSchemaExist(string connectionString, string schemaName, int retryCount = 0)
        {
            var result = new Result();
            //LogExtension.LogInfo(string.Empty, "Testing schema existence in PostgreSQL database", MethodBase.GetCurrentMethod());
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var schemaExistsQuery = "SELECT COUNT(*) FROM information_schema.schemata WHERE schema_name = @SchemaName";
                    var command = new NpgsqlCommand(schemaExistsQuery, connection);
                    command.Parameters.AddWithValue("@SchemaName", schemaName);

                    var count = await command.ExecuteScalarAsync();
                    var schemaExists = Convert.ToInt32(count) > 0;

                    result.Status = schemaExists;
                    result.ReturnValue = schemaExists;
                    return result;
                }
            }
            catch (Exception ex)
            {
                retryCount++;
                if (retryCount <= 3)
                {
                    //LogExtension.LogInfo(string.Empty, "Retrying operation for " + retryCount + " time", MethodBase.GetCurrentMethod());
                    return await IsSchemaExist(connectionString, schemaName, retryCount);
                }
                else
                {
                    result.Status = false;
                    result.Exception = ex;
                }
            }

            return result;
        }

        public async Task<Result> ExecuteNonQuery(string query, string connectionString, string prefix, string schema)
        {
            var result = new Result();
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                var connection = new NpgsqlConnection(connectionString);

                var command = new NpgsqlCommand(query, connection);
                command.CommandTimeout = 50;

                try
                {
                    await connection.OpenAsync();
                    result.ReturnValue = await command.ExecuteNonQueryAsync();
                }
                catch (Exception e)
                {
                   // LogExtension.LogError(string.Empty, "Exception on ExecuteNonQuery ", e, MethodBase.GetCurrentMethod(), "Executed query is : " + query);
                   // ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.DatabaseError, MethodBase.GetCurrentMethod());
                }
                finally
                {
                    await connection.CloseAsync();
                    await connection.DisposeAsync();
                    await command.DisposeAsync();
                }
            }
            else
            {
                //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.ConnectionStringEmpty, MethodBase.GetCurrentMethod());
            }

            result.Status = true;
            return result;
        }

        public string SetSchemaInQuery(string query, string Prefix, string SchemaName)
        {
            var prefix = !string.IsNullOrEmpty(Prefix) ? Prefix : DbTablePrefixes.ReportServer;
            if (!string.IsNullOrEmpty(SchemaName))
            {
                query = query.Replace($"[{prefix}", $"[{SchemaName}].[{prefix}");
                query = query.Replace($" {prefix}", $" {SchemaName}.{prefix}");
            }
            return query;
        }
    }
}
