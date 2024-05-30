using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace BoldReports.Server.Base.DataClasses
{
    public enum AuthenticationType
    {
        [Description("Windows")]
        Windows,

        [Description("SQL Server")]
        SqlServer
    }

    public enum ItemType
    {
        [Description("None")]
        None = 0,

        [EnumMember]
        [Description("Category")]
        Category = 1,

        [EnumMember]
        [Description("Dashboard")]
        Dashboard,

        [EnumMember]
        [Description("Report")]
        Report,

        [EnumMember]
        [Description("Datasource")]
        Datasource,

        [EnumMember]
        [Description("Dataset")]
        Dataset,

        [EnumMember]
        [Description("File")]
        File,

        [EnumMember]
        [Description("Schedule")]
        Schedule,

        [EnumMember]
        [Description("Widget")]
        Widget,

        [EnumMember]
        [Description("ItemView")]
        ItemView,

        [EnumMember]
        [Description("Slideshow")]
        Slideshow,

        [EnumMember]
        [Description("Settings")]
        Settings,

        [EnumMember]
        [Description("User Management")]
        UserManagement,

        [EnumMember]
        [Description("Permissions")]
        Permissions,

        [EnumMember]
        [Description("Report Part")]
        ReportPart,

    }

    public enum DatabaseType
    {
        [Description("MSSQL")]
        MSSQL = 1,

        [Description("MySQL")]
        MySQL,

        [Description("MSSQLCE")]
        MSSQLCE,

        [Description("ORACLE")]
        Oracle,

        [Description("PostgreSQL")]
        PostgreSQL
    }

    public enum LogicalOperator
    {
        None,
        OR,
        AND,
        IN,
        LIKE,
        NOT
    }

    public enum Condition
    {
        /// <summary>
        ///     No Condition will be applied
        /// </summary>
        None,

        /// <summary>
        ///     Applies Equal Operator
        /// </summary>
        Equals,

        /// <summary>
        ///     Applies Not Equal Operator
        /// </summary>
        NotEquals,

        /// <summary>
        ///     Applies Lesser than Operator
        /// </summary>
        LessThan,

        /// <summary>
        ///     Applies Greater than Operator
        /// </summary>
        GreaterThan,

        /// <summary>
        ///     Applies Lesser than or Equal Operator
        /// </summary>
        LessThanOrEquals,

        /// <summary>
        ///     Applies Greater than or Equals Operator
        /// </summary>
        GreaterThanOrEquals,

        /// <summary>
        ///     Applies for NULL values
        /// </summary>
        IS,

        /// <summary>
        ///     Applies for NULL values
        /// </summary>
        IN,

        /// <summary>
        ///     Applies for NULL values
        /// </summary>
        LIKE,

        NOTIN
    }

    public enum JoinType
    {
        /// <summary>
        ///     Inner Joins
        /// </summary>
        Inner,

        /// <summary>
        ///     Full Outer Join
        /// </summary>
        FullOuter,

        /// <summary>
        ///     Left Outer Join
        /// </summary>
        Left,

        /// <summary>
        ///     Right Outer Join
        /// </summary>
        RightOuter,

        /// <summary>
        ///     Cross Join
        /// </summary>
        Cross
    }

    public enum AggregateMethod
    {
        /// <summary>
        ///     Aggregation will not be applied
        /// </summary>
        None,

        /// <summary>
        ///     Returns the number of rows
        /// </summary>
        COUNT,

        /// <summary>
        ///     Returns the Maximum value in the given column
        /// </summary>
        MAX,

        /// <summary>
        ///     Returns the Minimum value in the given column
        /// </summary>
        MIN,

        /// <summary>
        ///     Returns the Average of the given column
        /// </summary>
        AVG,

        /// <summary>
        ///     Returns the SUM of the given column
        /// </summary>
        SUM,

        /// <summary>
        ///     Returns the Standard deviation of the given column
        /// </summary>
        STDEV,

        /// <summary>
        ///     Returns the variance of all the values in the given column
        /// </summary>
        VAR
    }
    public enum DirectoryType
    {
        [Description("All Users")]
        All = 0,

        [Description("Local User Account")]
        Local = 1,

        [Description("Azure Active Directory Account User")]
        AzureAD,

        [Description("External Database User")]
        ExternalDatabase,

        [Description("GSuite User")]
        GSuite,

        [Description("Active Directory Account User")]
        WindowsAD,

        [Description("Syncfusion User")]
        Syncfusion,

        [Description("OAuth2 User")]
        OAuth2,

        [Description("OpenID Connect User")]
        OpenIDConnect,

        [Description("Linked In User")]
        LinkedIn,

        [Description("Google User")]
        Google,

        [Description("GitHub User")]
        GitHub,

        [Description("Facebook User")]
        Facebook,

        [Description("Twitter User")]
        Twitter,

        [Description("JWT SSO User")]
        JWTSSO,

        [Description("Azure Active Directory B2C")]
        AzureADB2C,
    }
}
