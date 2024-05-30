namespace BoldReports.Server.ORM
{
    using System;
    using System.Reflection;
    using System.Net;
    using System.Threading.Tasks;
    using System.Data;
    using Npgsql;

    using BoldReports.Server.Base.DataClasses;

    public class PostgreSqlRelationalDataAdapter : IRelationalDataProvider
    {
        #region Private Properties

        private string _connectionString;
        private string schemaName;
        private string prefix;

        #endregion

        /// <summary>
        /// Creates an instance of RelationalDataAdapter Class with connection string
        /// </summary>
        /// <param name="connectionString">Connection string of the DB to be connected</param>
        /// <param name="tenantUrl">Tenant Url</param>
        public PostgreSqlRelationalDataAdapter(string connectionString, string tenantUrl, string schemaName, string prefix)
        {
            _connectionString = connectionString;
            this.TenantUrl = tenantUrl;
            this.SchemaName = schemaName;
            this.Prefix = prefix;
        }

        #region Public Properties

        public string TenantUrl
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public string SchemaName
        {
            get
            {
                return this.schemaName;
            }

            set
            {
                this.schemaName = value;
            }
        }
        public string Prefix
        {
            get
            {
                return this.prefix;
            }

            set
            {
                this.prefix = value;
            }
        }
        #endregion

        public async Task<Result> ExecuteNonQuery(string query)
        {
            query = SetSchemaInQuery(query);
            var result = new Result();
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.CommandTimeout = 50;

                        try
                        {
                            await connection.OpenAsync();
                            result.ReturnValue = await command.ExecuteNonQueryAsync();
                        }
                        catch (Exception e)
                        {
                            //LogExtension.LogError(this.TenantUrl, "Exception on ExecuteNonQuery ", e, MethodBase.GetCurrentMethod(), "Executed query is : " + query);
                            //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.DatabaseError, MethodBase.GetCurrentMethod());
                        }
                        finally
                        {
                            await connection.CloseAsync();
                            await connection.DisposeAsync();
                            await command.DisposeAsync();
                        }
                    }
                }
            }
            else
            {
                //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.ConnectionStringEmpty, MethodBase.GetCurrentMethod());
            }

            result.Status = true;
            return result;
        }

        public async Task<Result> ExecuteNonQuery(string query, string connectionString)
        {
            query = SetSchemaInQuery(query);
            var result = new Result();
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.CommandTimeout = 50;

                        try
                        {
                            await connection.OpenAsync();
                            result.ReturnValue = await command.ExecuteNonQueryAsync();
                        }
                        catch (Exception e)
                        {
                            //LogExtension.LogError(this.TenantUrl, "Exception on ExecuteNonQuery ", e, MethodBase.GetCurrentMethod(), "Executed query is : " + query);
                            //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.DatabaseError, MethodBase.GetCurrentMethod());
                        }
                        finally
                        {
                            await connection.CloseAsync();
                            await connection.DisposeAsync();
                            await command.DisposeAsync();
                        }
                    }
                }
            }
            else
            {
                //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.ConnectionStringEmpty, MethodBase.GetCurrentMethod());
            }

            result.Status = true;
            return result;
        }

        public async Task<Result> ExecuteReaderQuery(string query)
        {
            string filePath = @"D:\Microservice\Query.txt"; 

            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))

            using (StreamWriter writer = new StreamWriter(fs))

            {
                await writer.WriteLineAsync(query);
            }
            query = SetSchemaInQuery(query);
            var result = new Result();
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                var connection = new NpgsqlConnection(_connectionString);
                var command = new NpgsqlCommand(query, connection);
                
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
                }
                catch (Exception e)
                {
                    //LogExtension.LogError(TenantUrl, "Exception on ExecuteReaderQuery ", e, MethodBase.GetCurrentMethod(), "Executed query is : " + query);
                    //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.DatabaseError, MethodBase.GetCurrentMethod());
                }
                finally
                {
                    await connection.CloseAsync();
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

        public async Task<Result> ExecuteReaderQuery(string query, string connectionString)
        {
            query = SetSchemaInQuery(query);
            var result = new Result();
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                var connection = new NpgsqlConnection(connectionString);
                var command = new NpgsqlCommand(query, connection);
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
                }
                catch (Exception e)
                {
                    //LogExtension.LogError(TenantUrl, "Exception on ExecuteReaderQuery ", e, MethodBase.GetCurrentMethod(), "Executed query is : " + query);
                    //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.DatabaseError, MethodBase.GetCurrentMethod());
                }
                finally
                {
                    await connection.CloseAsync();
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

        public async Task<Result> ExecuteBulkQuery(string query)
        {
            query = SetSchemaInQuery(query);
            var result = new Result();

            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    string[] splitter = new string[] { ";" };
                    var querySplit = query.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    for (var queryInc = 0; queryInc < querySplit.Length; queryInc++)
                    {
                        using (var command = new NpgsqlCommand(querySplit[queryInc], connection))
                        {
                            try
                            {
                                await command.Connection.OpenAsync();
                                result.ReturnValue = await command.ExecuteNonQueryAsync();
                            }
                            catch (Exception e)
                            {
                                //LogExtension.LogError(this.TenantUrl, "Exception on ExecuteBulkQuery", e, MethodBase.GetCurrentMethod(), " Query - " + query);
                                //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.DatabaseError, MethodBase.GetCurrentMethod());
                            }
                            finally
                            {
                                await command.Connection.CloseAsync();
                                await command.DisposeAsync();
                            }
                        }
                    }
                }
            }
            else
            {
                //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.ConnectionStringEmpty, MethodBase.GetCurrentMethod());
            }

            if (result.Exception == null)
            {
                result.Status = true;
            }

            return result;
        }

        public async Task<Result> ExecuteBulkQuery(string query, string connectionString)
        {
            query = SetSchemaInQuery(query);
            var result = new Result();

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    string[] splitter = new string[] { ";" };
                    var querySplit = query.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    for (var a = 0; a < querySplit.Length; a++)
                    {
                        using (var command = new NpgsqlCommand(querySplit[a], connection))
                        {
                            try
                            {
                                await command.Connection.OpenAsync();
                                result.ReturnValue = await command.ExecuteNonQueryAsync();
                            }
                            catch (Exception e)
                            {
                                //LogExtension.LogError(this.TenantUrl, "Exception on ExecuteBulkQuery", e, MethodBase.GetCurrentMethod(), " Query - " + query);
                                //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.DatabaseError, MethodBase.GetCurrentMethod());
                            }
                            finally
                            {
                                await command.Connection.CloseAsync();
                                await command.DisposeAsync();
                            }
                        }
                    }
                }
            }
            else
            {
                //ExceptionHelper.ThrowException(HttpStatusCode.InternalServerError, ErrorCode.ConnectionStringEmpty, MethodBase.GetCurrentMethod());
            }

            if (result.Exception == null)
            {
                result.Status = true;
            }

            return result;
        }
        public string SetSchemaInQuery(string query)
        {
            var prefix = !string.IsNullOrEmpty(Prefix) ? Prefix : DbTablePrefixes.ReportServer;
            if (!string.IsNullOrEmpty(SchemaName))
            {
                query = query.Replace($"{prefix}", $"{SchemaName}.{prefix}");
            }
            return query;
        }
    }
}