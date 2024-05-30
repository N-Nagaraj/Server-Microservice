using Microsoft.AspNetCore.Mvc;
using BoldReports.Server.Base;
using BoldReports.Server.Base.DataClasses;
using BoldReports.Server.ORM;
using BoldReports.Server.DIResolvers;

namespace BoldReports.Server.WebAPI.Controllers
{

    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TenantHandler tenantHandler;

        public WeatherForecastController(TenantResolver tenantResolver ,TenantHandler tenantHandler)
        {
            this.tenantHandler = tenantHandler;
        }

        [Route("getweather")]
        public IEnumerable<WeatherForecast> Get()
        {
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
