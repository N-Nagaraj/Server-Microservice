using System;
using System.Collections.Generic;
using BoldReports.Server.Base.DataClasses;
using BoldReports.Server.DIResolvers;
using BoldReports.Server.ORM;

namespace BoldReports.Server.Base
{
    public record TenantSettings
    {
        public Tenant TenantInfo
        {
            get;
            set;
        }

        public string Branding
        {
            get;
            set;
        }

        public string BrandingDisplayName
        {
            get;
            set;
        }

        public string BrandingDomain
        {
            get;
            set;
        }

        public string BrandingCompanyName
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }

        public IRelationalDataProvider DataProvider
        {
            get;
            set;
        }

        public DatabaseType DBSupport
        {
            get;
            set;
        }

        public DB_SyncUMP DBColumns
        {
            get;
            set;
        }

        public bool IsSecureConnection
        {
            get;
            set;
        }

        //public LicenseSettings LicenseSettings
        //{
        //    get;
        //    set;
        //}

        public DateTime LocalSystemTime
        {
            get;
            set;
        }

        public IQueryBuilder QueryBuilder
        {
            get;
            set;
        }

        public bool IsTenantExist
        {
            get;
            set;
        }

        public string TenantDbTablePrefix
        {
            get;
            set;
        }

        public string TenantSchemaName
        {
            get;
            set;
        }
    }
}
