namespace BoldReports.Server.Base.DataClasses
{
    public class DbTablePrefixes
    {
        public static string TenantManagement
        {
            get
            {
                return "BOLDTC_";
            }
        }

        public static string ReportServer
        {
            get
            {
                return "BOLDRS_";
            }
        }
    }
}
