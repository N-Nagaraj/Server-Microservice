using BoldReports.Server.Base.Models;
using BoldReports.Server.Base.DataClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BoldReports.Server.DIResolvers
{
    public class TenantResolver
    {
        private readonly AppSettings _appSettings;
        public TenantResolver(IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
            Tenant tenant = GetTenantIdentifierAsync(httpContextAccessor.HttpContext).Result;
            httpContextAccessor.HttpContext.Items["TenantInfo"] = tenant;
        }


        public async Task<Tenant> GetTenantIdentifierAsync(HttpContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), "HttpContext cannot be null.");

            var pathBase = context.Request.Path.Value.Trim('/');
            var tenantIdentifierPrefix = _appSettings.TenantIdentifierPrefix;

            var segments = pathBase.Split('/');

            // Find the index of the segment that contains the tenant identifier prefix
            var prefixIndex = Array.IndexOf(segments, tenantIdentifierPrefix);
            if (prefixIndex == -1)
                throw new ArgumentException("Tenant identifier prefix not found in the URL.", nameof(context));

            // Extract the tenant identifier
            if (prefixIndex < segments.Length - 1)
            {
                var identifier = segments[prefixIndex + 1];
                return new Tenant { TenantIdentifier = identifier, PreifxWithIdentifierKey = context.Request.Host + context.Request.PathBase +"/" + _appSettings.TenantIdentifierPrefix + "/" + identifier };
            }
            else
            {
                throw new ArgumentException("Tenant identifier not found in the URL.", nameof(context));
            }
        }
    }
}
