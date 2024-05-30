namespace BoldReports.Server.ORM
{
    using BoldReports.Server.Base.DataClasses;
    using System.Threading.Tasks;
    public interface IRelationalDataProvider
    {
        /// <summary>
        /// Execute the bulk query depends on the server type (SQL/SQLCE)
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <returns>Result with the queried result</returns>
        Task<Result> ExecuteBulkQuery(string query);

        /// <summary>
        /// Execute the bulk query depends on the server type (SQL/SQLCE)
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <param name="connectionString">Connection String</param>
        /// <returns>Result with the queried result</returns>
        Task<Result> ExecuteBulkQuery(string query, string connectionString);

        /// <summary>
        ///     For executing SQL Query that doesn't return a value
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>Result with the queried result</returns>
        Task<Result> ExecuteNonQuery(string query);

        /// <summary>
        ///     For executing SQL Query that doesn't return a value
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <param name="connectionString">Connection String</param>
        /// <returns>Result with the queried result</returns>
        Task<Result> ExecuteNonQuery(string query, string connectionString);

        /// <summary>
        ///     Executes Query that returns  the table
        /// </summary>
        /// <param name="query">SQL query</param>
        /// <returns>Query result as DataTable</returns>
        Task<Result> ExecuteReaderQuery(string query);

        /// <summary>
        ///     Executes Query that returns  the table
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <param name="connectionString">SQL Connection String</param>
        /// <returns>Query result as DataTable</returns>
        Task<Result> ExecuteReaderQuery(string query, string connectionString);
    }
}