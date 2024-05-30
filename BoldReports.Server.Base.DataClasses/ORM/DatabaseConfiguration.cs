namespace BoldReports.Server.Base.DataClasses
{
    public class DatabaseConfiguration
    {
        public AuthenticationType AuthenticationType
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }

        [System.Xml.Serialization.XmlElementAttribute("DataBaseName")]
        public string DatabaseName
        {
            get;
            set;
        }

        public string DatabasePassword
        {
            get;
            set;
        }

        public string DSN
        {
            get;
            set;
        }

        public bool IsWindowsAuthentication
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Port
        {
            get;
            set;
        }

        public string Prefix
        {
            get;
            set;
        }

        public string ServerName
        {
            get;
            set;
        }

        public DatabaseType ServerType
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public DatabaseType ImDbDatabaseType
        {
            get;
            set;
        }

        public string ImDbConnectionString
        {
            get;
            set;
        }

        public bool SslEnabled
        {
            get;
            set;
        }

        public bool IsNewDatabase
        {
            get;
            set;
        }

        public string MaintenanceDatabase
        {
            get;
            set;
        }
        public string SchemaName { get;set; }

        public string ErrorMessage
        {
            get;
            set;
        }

    }
}