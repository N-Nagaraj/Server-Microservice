namespace BoldReports.Server.ORM
{
    public class PostgreSqlConfig
    {
        public static int ConnectionIdleLifetime { get; set; } = 5;

        public static int ConnectionPruningInterval { get; set; } = 2;
    }
}