using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;

using BoldReports.Server.Base;
using BoldReports.Server.Base.DataClasses;
using BoldReports.Server.ORM;
using BoldReports.Server.DIResolvers;
using BoldReports.Server.Base.Resolvers;
namespace BoldReports.Server.WebAPI.Controllers
{
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly TenantResolver _tenantResolver;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TenantHandler _tenantHandler;
        private readonly SystemSetting _systemSetting;
        private readonly IItemManagement _itemManagement;

        public ReportsController(IHttpContextAccessor httpContextAccessor, TenantResolver tenantResolver, TenantHandler tenantHandler, SystemSetting systemSetting, IItemManagement itemManagement)
        {
            _httpContextAccessor = httpContextAccessor;
            _tenantResolver = tenantResolver;
            _tenantHandler = tenantHandler;
            _systemSetting = systemSetting;
            _itemManagement = itemManagement;
        }

        [HttpGet]
        [Route("items")]
        public async Task<List<ApiItemDetail>> GetItems([FromQuery] ItemType itemType, [FromQuery] string serverPath = null, [FromQuery] string tags = null)
        {
            try
            {

                var userId = 1;
                var items = await this._itemManagement.GetItems(userId, itemType, null, null);

                var itemDetails = (List<ItemDetail>)items.Result;

                return items.Result.Select(t => new ApiItemDetail
                {
                    CanRead = t.CanRead,
                    CanWrite = t.CanWrite,
                    CanOpen = t.CanOpen,
                    CanSchedule = t.CanSchedule,
                    CanMove = t.CanMove,
                    CanClone = t.CanClone,
                    CanCopy = t.CanCopy,
                    CanCreateItem = t.CanCreateItem,
                    CanDelete = t.CanDelete,
                    CanDownload = t.CanDownload,
                    CategoryId = t.CategoryId,
                    CategoryName = t.CategoryName,
                    CreatedByDisplayName = t.CreatedByDisplayName,
                    CreatedById = t.CreatedById,
                    CreatedDate = t.CreatedDate,
                    Description = t.Description,
                    Id = t.Id,
                    ItemLocation = t.ItemLocation,
                    ItemCreatedDate = t.ItemCreatedDate,
                    ItemModifiedDate = t.ItemModifiedDate,
                    ItemType = t.ItemType,
                    ModifiedByFullName = t.ModifiedByFullName,
                    ModifiedById = t.ModifiedById,
                    ModifiedDate = t.ModifiedDate,
                    Name = t.Name,
                    Tags = t.Tags
                }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
