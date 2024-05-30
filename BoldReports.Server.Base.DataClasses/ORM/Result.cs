using System;
using System.Data;

namespace BoldReports.Server.Base.DataClasses
{
    public class Result
    {
        public Result()
        {
            DataTable = new DataTable();
        }

        public DataTable DataTable
        {
            get;
            set;
        }

        public Exception Exception
        {
            get;
            set;
        }

        public object ReturnValue
        {
            get;
            set;
        }

        public bool Status
        {
            get;
            set;
        }
    }
}
