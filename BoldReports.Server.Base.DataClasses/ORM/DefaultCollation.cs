namespace BoldReports.Server.Base.DataClasses
{
    public class DefaultCollation
    {
        public static string MSSQLCollation => "SQL_Latin1_General_CP1_CI_AS";

        public static string PostgrSQLCollation => "C";

        public static string MySQLCollation => "utf8mb4_general_ci";

    }
}
