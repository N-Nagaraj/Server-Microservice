using BoldReports.Server.Base.DataClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoldReports.Server.Base;
using Syncfusion.Server.Base;
using BoldReports.Server.ORM;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml;

namespace BoldReports.Server.DIResolvers
{
    public class TenantHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantSettings TenantSettings
        {
            get;
            set;
        }

        public TenantHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            TenantSettings =  GetTenantConfig().Result;
        }
        public async Task<TenantSettings> GetTenantConfig()
        {
            var tenantSettings = new TenantSettings();

            if (_httpContextAccessor.HttpContext?.Items.TryGetValue("TenantInfo", out object tenantInfo)== true && tenantInfo is not null)
            {
                tenantSettings = new TenantSettings
                {
                    TenantInfo = tenantInfo as Tenant,
                    DBSupport = DatabaseType.PostgreSQL,
                    Branding = "Default",
                    TenantDbTablePrefix = "BOLDRS_",
                    TenantSchemaName = "public",
                    IsTenantExist = true,
                    BrandingDisplayName = "Default",
                    BrandingDomain = "Default",
                    BrandingCompanyName = "Default",
                    ConnectionString = "SSL Mode=Prefer;Password=Syncfusion@123;Username=postgres;Database=microservice_test_site1;Port=5432;Host=localhost;Trust Server Certificate=True;Connection Idle Lifetime=5;Connection Pruning Interval=2"
                };

                var dataProv = new DbService(tenantSettings);
                tenantSettings.DataProvider = dataProv.DataProvider;
                tenantSettings.QueryBuilder = dataProv.QueryBuilder;
                tenantSettings.DBColumns = DeserializeTables("D:\\Microservice\\Reference\\boldreports-server\\src\\Report\\Web\\Syncfusion.Server.Reports/configuration/db_schema.xml", tenantSettings.TenantDbTablePrefix);
            }
            return await Task.FromResult(tenantSettings);
        }

        public static DB_SyncUMP DeserializeTables(string filePath , string tenantDbTablePrefix)
        {
            DB_SyncUMP data = null;
            var xmlSerializer = new XmlSerializer(typeof(DB_SyncUMP));
            var xmlDoc = new XmlDocument();
            if (File.Exists(filePath))
            {
                try
                {
                    var prefix = !string.IsNullOrEmpty(tenantDbTablePrefix)?tenantDbTablePrefix: DbTablePrefixes.ReportServer;
                    filePath = Path.GetFullPath(filePath);
                    xmlDoc.Load(filePath);
                    var childNodes = xmlDoc.DocumentElement.SelectSingleNode("/DB_SyncUMP");
                    foreach (XmlNode node in childNodes)
                    {
                        var tableNode = node.SelectSingleNode("DB_TableName");
                        if (tableNode != null)
                        {
                            tableNode.InnerText = prefix + tableNode.InnerText;
                        }
                    }

                    data = (DB_SyncUMP)xmlSerializer.Deserialize(new XmlNodeReader(xmlDoc.DocumentElement));
                }
                catch (Exception e)
                {
                    //LogExtension.LogError(string.Empty, "Exception is thrown while deserializing db_schema.xml FilePath - " + filePath, e, MethodBase.GetCurrentMethod(), "FilePath - " + filePath);
                }
            }
            else
            {
                //LogExtension.LogInfo(string.Empty, "db_schema.xml file not found FilePath - " + filePath, MethodBase.GetCurrentMethod(), "FilePath - " + filePath);
            }

            return data;
        }
    }
}
