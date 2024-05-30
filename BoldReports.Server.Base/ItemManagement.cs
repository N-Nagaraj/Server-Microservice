using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using BoldReports.Server.Base.DataClasses;
using BoldReports.Server.Base.Resolvers;
using BoldReports.Server.DIResolvers;
using BoldReports.Server.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.Build.Tasks;
using Syncfusion.Server.Base;

namespace BoldReports.Server.Base
{
    public class ItemManagement : IItemManagement
    {
        private readonly TenantResolver _tenantResolver;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TenantHandler _tenantHandler;
        private readonly SystemSetting _systemSetting;
        private bool outputValue;

        public IQueryBuilder QueryBuilder { get; set; }

        public IRelationalDataProvider DataProvider { get; set; }

        public QueryBuilderHelper QueryBuilderHelper { get; set; }

        public ItemManagement(IHttpContextAccessor httpContextAccessor,TenantResolver tenantResolver, TenantHandler tenantHandler, SystemSetting systemSetting)
        {
            _httpContextAccessor = httpContextAccessor;
            _tenantResolver = tenantResolver;
            _tenantHandler = tenantHandler;
            _systemSetting = systemSetting;
            DataProvider = _tenantHandler.TenantSettings.DataProvider;
            QueryBuilder = _tenantHandler.TenantSettings.QueryBuilder;
            QueryBuilderHelper = new QueryBuilderHelper(_tenantHandler.TenantSettings, _systemSetting);
        }

        public async Task<EntityData<ItemDetail>> GetItems(int userId, ItemType itemType, List<string> sortCollection = null, List<string> filterSettings = null, string searchQuery = "", int? skip = 0, int? take = 0, Guid? itemId = null, bool isAllCategorySearch = false, bool isWidgetListRequest = false, bool canGetPublic = true, bool isPagination = false, bool isDraftRequired = false, bool isDatasourceListRequest = true)
        {
            var items = new List<ItemDetail>();

            var searchDescriptor = new List<string> { "Name", "Description", "CreatedByDisplayName" };
            if ((itemType == ItemType.Report || itemType == ItemType.Dashboard) && isAllCategorySearch)
            {
                searchDescriptor = new List<string> { "Name", "Description", "CategoryName", "CreatedByDisplayName" };
            }

            var groupIds = new  List<int>(){1};


           
            items = await GetAllItems(userId, groupIds, itemType, null, sortCollection, filterSettings, searchQuery, searchDescriptor, itemId, isWidgetListRequest, false, canGetPublic, false, isDraftRequired);

            var itemsCount = items.Count();

            if (isPagination)
            {
                items = itemsCount > skip.GetValueOrDefault() ? items.Skip(skip.GetValueOrDefault()).Take(take.GetValueOrDefault()).ToList() : items.Skip(itemsCount != 0 ? (itemsCount % 10 != 0 ? ((itemsCount / 10) * 10) : (((itemsCount / 10) - 1) * 10)) : 0).Take(take.GetValueOrDefault()).ToList();
            }

            foreach (var item in items)
            {
                item.ItemCreatedDate =
                    TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(item.CreatedDate), TimeZoneInfo.Local);
                item.ItemModifiedDate =
                    TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(item.ModifiedDate), TimeZoneInfo.Local);
                item.CreatedDate = item.ItemCreatedDate.ToString();
                item.ModifiedDate = item.ItemModifiedDate.ToString();
                item.CanMove = item.CanRead && item.CanDelete;
                item.CanCopy = item.CanRead;
                item.CanClone = item.CanRead && !item.IsSampleData;
                item.CanRead = item.CanRead || item.IsPublic;
                item.CanDownload = item.CanDownload;
                item.IsDraft = item.IsDraft;
            }

            return new EntityData<ItemDetail>
            {
                Result = items,
                Count = itemsCount
            };
        }

        public async Task<List<ItemDetail>> GetAllItems(int userId, List<int> groupIds, ItemType? itemType = null, List<string> parentIdPermissions = null, List<string> sortCollection = null, List<string> filterSettings = null, string search = "", List<string> searchDescriptor = null, Guid? itemId = null, bool isWidgetListRequest = false, bool isPublicListRequest = false, bool canGetPublic = true, bool isPermissionCheck = false, bool isDraftRequired = false)
        {
            var query = QueryBuilderHelper.GetAllItems(userId, groupIds, itemType, itemId, parentIdPermissions, sortCollection, filterSettings, search, searchDescriptor, isWidgetListRequest, isPublicListRequest, isDraftRequired);
            var taskList = new List<Task<Result>>();
            

            var taskResult = DataProvider.ExecuteReaderQuery(query).Result.DataTable.AsEnumerable();
            var canCreateSchedule = true;
            var publicItems = new List<ItemDetail>();

            var itemsList = taskResult.Select(row => new
            {
                Id = Guid.Parse(row.Field<object>(_tenantHandler.TenantSettings.DBColumns.DB_Item.Id).ToString()),
                Name = row.Field<string>(_tenantHandler.TenantSettings.DBColumns.DB_Item.Name),
                CategoryName = row.Field<string>("CategoryName"),
                CategoryDescription = row.Field<string>("CategoryDescription"),
                CategoryId = row.Field<object>("CategoryId") == null ? null : (Guid?)Guid.Parse(row.Field<object>("CategoryId").ToString()),
                Description = row.Field<string>(_tenantHandler.TenantSettings.DBColumns.DB_Item.Description),
                Extension = row.Field<string>(_tenantHandler.TenantSettings.DBColumns.DB_Item.Extension),
                ItemType = (ItemType)int.Parse(row.Field<object>(_tenantHandler.TenantSettings.DBColumns.DB_Item.ItemTypeId).ToString()),
                CreatedById = int.Parse(row.Field<object>(_tenantHandler.TenantSettings.DBColumns.DB_Item.CreatedById).ToString()),
                CreatedByDisplayName =
                     !string.IsNullOrWhiteSpace(row.Field<string>("CreatedByDisplayName")) ? row.Field<string>("CreatedByDisplayName") : row.Field<string>("CreatedByFirstName") + " " + row.Field<string>("CreatedByLastName"),
                CreatedDate =
                    row.Field<DateTime>(_tenantHandler.TenantSettings.DBColumns.DB_Item.CreatedDate)
                        .ToString(),
                ModifiedById = int.Parse(row.Field<object>(_tenantHandler.TenantSettings.DBColumns.DB_Item.ModifiedById).ToString()),
                ModifiedByFullName =
                    row.Field<string>("ModifiedByDisplayName"),
                ModifiedDate =
                    row.Field<DateTime>(_tenantHandler.TenantSettings.DBColumns.DB_Item.ModifiedDate)
                        .ToString(),
                IsCreatedByActive = bool.TryParse(row.Field<object>("IsCreatedByActive").ToString(), out outputValue) ? outputValue :
                                    int.Parse(row.Field<object>("IsCreatedByActive").ToString()) == 1,
                IsModifiedByActive = bool.TryParse(row.Field<object>("IsModifiedByActive").ToString(), out outputValue) ? outputValue :
                                    int.Parse(row.Field<object>("IsModifiedByActive").ToString()) == 1,
                PermissionEntityId =
                    row.Field<object>("PermissionEntityId") == null
                        ? 0
                        : int.Parse(row.Field<object>("PermissionEntityId").ToString()),
                PermissionAccessId =
                    row.Field<object>("PermissionAccessId") == null
                        ? 0
                        : int.Parse(row.Field<object>("PermissionAccessId").ToString()),
                IsSpecicPermission = bool.TryParse(row.Field<object>("IsSpecificItemPermission").ToString(), out outputValue) ? outputValue :
                                    int.Parse(row.Field<object>("IsSpecificItemPermission").ToString()) == 1,
                IsPublic = bool.TryParse(row.Field<object>("IsPublic").ToString(), out outputValue) ? outputValue :
                           int.Parse(row.Field<object>("IsPublic").ToString()) == 1,
                IsDraft = bool.TryParse(row.Field<object>("IsDraft").ToString(), out outputValue)
                        ? outputValue
                        : int.Parse(row.Field<object>("IsDraft").ToString()) == 1,
#if (DashboardServerCloud || DashboardServerOnPremise || BoldReportsOnPremise)
                IsLocked = row.Field<object>(_globalAppSettings.DBColumns.DB_Item.IsLocked) != null ? BooleanHelper.ToBoolean(row.Field<object>(_globalAppSettings.DBColumns.DB_Item.IsLocked).ToString()) : false,
#endif
                IsSampleData = row.Field<object>("IsSampleData") != null ?
                        bool.TryParse(row.Field<object>("IsSampleData").ToString(), out outputValue)
                        ? outputValue
                        : int.Parse(row.Field<object>("IsSampleData").ToString()) == 1 : false,
                IsFavorite = row.Field<int?>("FavoriteId") != null ? true : false,
            }).ToList();
            var groupedItems =
                itemsList.GroupBy(x => x.Id).Select(grp => new { ItemId = grp.Key, Details = grp.ToList() }).ToList();
            var items = groupedItems.Select(r => new ItemDetail
            {
                Id = r.ItemId,
                Name = r.Details[0].Name,
                Description = r.Details[0].Description,
                Extension = r.Details[0].Extension,
                ItemType = r.Details[0].ItemType,
                ItemTypeString = r.Details[0].ItemType.ToString().ToLower(),
                CreatedById = r.Details[0].CreatedById,
                CreatedByDisplayName = r.Details[0].CreatedByDisplayName,
                CreatedDate = r.Details[0].CreatedDate,
                CategoryName = r.Details[0].CategoryName,
                CategoryDescription = r.Details[0].CategoryDescription,
                CategoryId = r.Details[0].CategoryId,
                ModifiedById = r.Details[0].ModifiedById,
                ModifiedByFullName = r.Details[0].ModifiedByFullName,
                ModifiedDate = r.Details[0].ModifiedDate,
                IsCreatedByActive = r.Details[0].IsCreatedByActive,
                IsModifiedByActive = r.Details[0].IsModifiedByActive,
                CanRead =true,
                CanWrite = true,
                CanDelete =false,
                CanDownload =true,
                CanOpen = true,
                CanSchedule = canCreateSchedule,
                IsPublic = r.Details[0].IsPublic,
                IsDraft = r.Details[0].IsDraft,
                IsSampleData = r.Details[0].IsSampleData,
                IsFavorite = r.Details[0].IsFavorite
            }).ToList();
            var itemUnion = items.Union(publicItems).GroupBy(x => x.Id).Select(a => new { ItemId = a.Key, itemDetails = a.ToList() }).ToList();
            items = itemUnion.Select(row => new ItemDetail
            {
                Id = row.ItemId,
                Name = row.itemDetails[0].Name,
                CategoryName = row.itemDetails[0].CategoryName,
                CategoryDescription = row.itemDetails[0].CategoryDescription,
                CategoryId = row.itemDetails[0].CategoryId,
                Description = row.itemDetails[0].Description,
                Extension = row.itemDetails[0].Extension,
                ItemType = row.itemDetails[0].ItemType,
                ItemTypeString = row.itemDetails[0].ItemTypeString,
                CreatedById = row.itemDetails[0].CreatedById,
                CreatedByDisplayName =
                    row.itemDetails[0].CreatedByDisplayName,
                CreatedDate =
                    row.itemDetails[0].CreatedDate,
                ModifiedById = row.itemDetails[0].ModifiedById,
                ModifiedByFullName =
                    row.itemDetails[0].ModifiedByFullName,
                ModifiedDate =
                    row.itemDetails[0].ModifiedDate,
                IsCreatedByActive = row.itemDetails[0].IsCreatedByActive,
                IsModifiedByActive = row.itemDetails[0].IsModifiedByActive,
                CanRead = row.itemDetails.Where(s => s.CanRead).Select(d => d.CanRead).FirstOrDefault(),
                CanWrite = row.itemDetails.Where(s => s.CanWrite).Select(d => d.CanWrite).FirstOrDefault(),
                CanDelete = row.itemDetails.Where(s => s.CanDelete).Select(d => d.CanDelete).FirstOrDefault(),
                CanDownload = row.itemDetails.Where(s => s.CanDownload).Select(d => d.CanDownload).FirstOrDefault(),
                CanOpen = true,
                CanSchedule = row.itemDetails.Where(s => s.CanSchedule).Select(d => d.CanSchedule).FirstOrDefault(),
                IsPublic = row.itemDetails.Where(s => s.Id == row.ItemId).Any(d => d.IsPublic),
                IsDraft = row.itemDetails.Where(s => s.Id == row.ItemId).Any(d => d.IsDraft),
#if (DashboardServerCloud || DashboardServerOnPremise)
                IsLocked = row.itemDetails.Where(s => s.Id == row.ItemId).Any(d => d.IsLocked),
#endif
                IsSampleData = row.itemDetails.Where(s => s.Id == row.ItemId).Any(d => d.IsSampleData),
                IsFavorite = row.itemDetails.Where(s => s.Id == row.ItemId).Any(d => d.IsFavorite)
            }).Distinct().ToList();

            if (isPublicListRequest)
            {
                var publicItemsList = items.Where(s => s.IsPublic).ToList();
                return publicItemsList;
            }
            else
            {
                return items;
            }
        }

    }
}
