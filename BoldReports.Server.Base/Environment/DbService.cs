namespace Syncfusion.Server.Base
{
    using System;
    using System.Data.Odbc;
    using System.Reflection;
    using System.Threading.Tasks;
    using Npgsql;
    using BoldReports.Server.Base.DataClasses;

    using BoldReports.Server.ORM;
    using BoldReports.Server.Base;

    public class DbService
    {
        public readonly IRelationalDataProvider DataProvider;
        public readonly IQueryBuilder QueryBuilder;

        public DbService(TenantSettings globalAppSettings)
        {
            var tenantUrl = globalAppSettings.TenantInfo.PreifxWithIdentifierKey;
            switch (globalAppSettings.DBSupport)
            {
//#if (DashboardServerOnPremise || BoldReportsOnPremise)
//                case DatabaseType.MSSQLCE:
//                    DataProvider = new SqlCeRelationalDataAdapter(globalAppSettings.ConnectionString, tenantUrl);
//                    QueryBuilder = new SqlCeQueryBuilder();
//                    break;
//#endif

//                case DatabaseType.MSSQL:
//                    DataProvider = new SqlRelationalDataAdapter(globalAppSettings.ConnectionString, tenantUrl, globalAppSettings.TenantSchemaName, globalAppSettings.TenantDbTablePrefix);
//                    QueryBuilder = new SqlQueryBuilder();
//                    break;

//                case DatabaseType.Oracle:
//                    DataProvider = new OracleRelationalDataAdapter(globalAppSettings.ConnectionString, tenantUrl);
//                    QueryBuilder = new OracleQueryBuilder();
//                    break;

//                case DatabaseType.MySQL:
//                    var dbConfigurationFromConnectionString = new MySQLConnectionHelper().GenerateDatabaseConfigurationFromConnecctionString(globalAppSettings.ConnectionString, true).ReturnValue as DatabaseConfiguration;
//                    DataProvider = new MySqlRelationalDataAdapter(globalAppSettings.ConnectionString, tenantUrl);
//                    QueryBuilder = new MySqlQueryBuilder(dbConfigurationFromConnectionString.DatabaseName);
//                    break;

                case DatabaseType.PostgreSQL:
                    DataProvider = new PostgreSqlRelationalDataAdapter(globalAppSettings.ConnectionString, tenantUrl, globalAppSettings.TenantSchemaName, globalAppSettings.TenantDbTablePrefix);
                    QueryBuilder = new PostgreSqlQueryBuilder();
                    break;
            }
        }

        //public async Task<DatabaseConfiguration> GetDatabaseDetails(GlobalAppSettings globalAppSettings)
        //{
        //    var result = new Result();
        //    var dbsavedata = new DatabaseConfiguration();
        //    DbService dbService = new DbService(globalAppSettings);

        //    dbsavedata.ConnectionString = globalAppSettings.ConnectionString;

        //    try
        //    {
        //        {
        //            var dbType = dbsavedata.ServerType = globalAppSettings.DBSupport;
        //            var connectionHelper = new Result();
        //            switch (dbType)
        //            {
        //                case DatabaseType.MSSQL:
        //                    connectionHelper = new SQLConnectionHelper().GenerateDatabaseConfigurationFromConnecctionString(globalAppSettings.ConnectionString, true);
        //                    dbsavedata = connectionHelper.ReturnValue as DatabaseConfiguration;
        //                    break;

        //                case DatabaseType.MySQL:
        //                    connectionHelper = new MySQLConnectionHelper().GenerateDatabaseConfigurationFromConnecctionString(globalAppSettings.ConnectionString, true);
        //                    dbsavedata = connectionHelper.ReturnValue as DatabaseConfiguration;
        //                    break;

        //                //case DatabaseType.Oracle:
        //                //    var masterBuilder = new OdbcConnectionStringBuilder(globalAppSettings.ConnectionString);
        //                //    var masterdsn = masterBuilder["DSN"];
        //                //    var adminUserid = masterBuilder["UID"];
        //                //    var adminPassword = masterBuilder["PWD"];
        //                //    var masterUserName = masterBuilder["UserName"];
        //                //    dbsavedata.DSN = masterdsn.ToString();
        //                //    dbsavedata.UserName = masterUserName.ToString().Replace('"', ' ').Trim();
        //                //    dbsavedata.DatabaseName = adminUserid.ToString().Replace('"', ' ').Trim();
        //                //    dbsavedata.DatabasePassword = adminPassword.ToString().Replace('"', ' ').Trim();
        //                //    dbsavedata.ServerType = globalAppSettings.DBSupport;
        //                //    break;

        //                case DatabaseType.PostgreSQL:

        //                    connectionHelper = new PostgreSQLConnectionHelper().GenerateDatabaseConfigurationFromConnecctionString(globalAppSettings.ConnectionString, true);
        //                    dbsavedata = connectionHelper.ReturnValue as DatabaseConfiguration;
        //                    break;
        //            }
        //        }

        //        return dbsavedata;
        //    }
        //    catch (Exception e)
        //    {
        //       // LogExtension.LogError(globalAppSettings.SystemSettings.BaseUrl, "Error while getting database settings", e, MethodBase.GetCurrentMethod(), " Status - " + result.Status);
        //        return dbsavedata;
        //    }
        //}
    }
}