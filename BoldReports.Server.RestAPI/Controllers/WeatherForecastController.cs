using Microsoft.AspNetCore.Mvc;

using BoldReports.Server.Base;
using BoldReports.Server.Base.DataClasses;
using BoldReports.Server.ORM;
using BoldReports.Server.DIResolvers;

namespace BoldReports.Server.RestAPI.Controllers
{
    [ApiController]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger, TenantHandler tenantHandler) : ControllerBase
    {

        [Route("getweather")]
        public IEnumerable<WeatherForecast> Get()


        {
            List<Tenant> newv = new List<Tenant>();
            newv.Any(x => x.TenantIdentifier == "112");
            return Enumerable.Range(1, 2).Select(index => new WeatherForecast
            {
               Name = tenantHandler.TenantSettings.TenantInfo.TenantIdentifier,
               ConnectionString = tenantHandler.TenantSettings.TenantInfo.TenantIdentifier,
               SiteIdentifier = tenantHandler.TenantSettings.TenantInfo.TenantIdentifier
            })
            .ToArray();
        }

        [Route("getid")]
        public IEnumerable<WeatherForecast> Get1()
        {
            return Enumerable.Range(1, 2).Select(index => new WeatherForecast
            {
                Name = tenantHandler.TenantSettings.TenantInfo.TenantIdentifier,
                ConnectionString = tenantHandler.TenantSettings.TenantInfo.TenantIdentifier,
                SiteIdentifier = tenantHandler.TenantSettings.TenantInfo.TenantIdentifier

            })
            .ToArray();
        }
    }
}
