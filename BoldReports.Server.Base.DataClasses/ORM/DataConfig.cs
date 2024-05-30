namespace BoldReports.Server.Base.DataClasses
{
    /// <summary>
    /// Data configuration
    /// </summary>
    public class DataConfig
    {
        /// <summary>
        /// Maximum row count for Insert or Update sql operation
        /// </summary>
        public const int MaxRowCount = 50;

        /// <summary>
        /// Query execution timeout
        /// </summary>
        public const int CommandTimeout = 50;
    }
}
