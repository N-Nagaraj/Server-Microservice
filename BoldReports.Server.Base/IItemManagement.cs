using Microsoft.AspNetCore.Http.Extensions;
using BoldReports.Server.Base.DataClasses;

using BoldReports.Server.ORM;

namespace BoldReports.Server.Base
{
    public interface IItemManagement
    {
        IRelationalDataProvider DataProvider { get; set; }
        IQueryBuilder QueryBuilder { get; set; }
        QueryBuilderHelper QueryBuilderHelper { get; set; }
        Task<EntityData<ItemDetail>> GetItems(int userId, ItemType itemType, List<string> sortCollection = null, List<string> filterSettings = null, string searchQuery = "", int? skip = 0, int? take = 0, Guid? itemId = null, bool isAllCategorySearch = false, bool isWidgetListRequest = false, bool canGetPublic = true, bool isPagination = false, bool isDraftRequired = false, bool isDatasourceListRequest = true);
    }
}