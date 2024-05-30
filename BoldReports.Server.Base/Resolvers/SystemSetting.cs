using BoldReports.Server.DIResolvers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoldReports.Server.Base.DataClasses;

namespace BoldReports.Server.Base.Resolvers
{
    public class SystemSetting
    {
        private readonly TenantHandler _tenantHandler;

        public SystemSettings SystemSettings
        {
            get;
            set;
        }

        public SystemSetting(TenantHandler tenantHandler)
        {
            _tenantHandler = tenantHandler;
            SystemSettings = GetSystemSettings().Result;
        }

        public async Task<SystemSettings> GetSystemSettings()
        {
            var systemSettings = new SystemSettings { 
                SqlConfiguration = new DatabaseConfiguration
                {
                    ConnectionString = "SSL Mode=Prefer;Password=Syncfusion@123;Username=postgres;Database=microservice_test_site1;Port=5432;Host=localhost;Trust Server Certificate=True;Connection Idle Lifetime=5;Connection Pruning Interval=2",
                    DatabaseName = "microservice_test_site1",
                }
            
            };
            return Task.FromResult(systemSettings).Result;
        }
    }
}
