namespace BoldReports.Server.ORM
{
    using System.Data;
    using System.Threading.Tasks;
    using System.Xml;

    using BoldReports.Server.Base.DataClasses;
    public interface IDatabaseConnectionHelper
    {
        Task<Result> GetTableList(DatabaseConfiguration databaseCredentials);

        Task<Result> GetDatabaseList(DatabaseConfiguration databaseCredentials);

        Task<Result> CheckDatabaseExists(string connectionString, string databaseName, int retryCount = 0);

        Task<Result> IsValidConnection(string connectionString, int retryCount = 0);

        Result GenerateConnectionStringFromDBCongifuration(DatabaseConfiguration databaseConfiguration, bool maskPassword = false, bool isSecondaryConnectionString = true);

        Result GenerateDatabaseConfigurationFromConnecctionString(string connectionString, bool showPassword = false);

        Task<Result> CreateDabase(string connectionString, string databaseName, int retryCount = 0);

        Task<Result> CreateTableInDatabase(string connectionString, string tableScript, int retryCount = 0);

        Task<Result> DeleteDatabase(string connectionString, string databaseName, XmlNodeList nodeList, string maintenanceDatabase = null);

        Task<DataTable> ExecuteReaderQuery(string connectionString, string query, string prefix, string schema);

        Task<Result> ExecuteNonQuery(string query, string connectionString, string prefix, string schema);
    }
}
