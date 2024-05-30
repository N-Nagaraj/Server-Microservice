using System;

namespace BoldReports.Server.ORM
{
    public class DB_AzureADCredential
    {
        public string ClientId
        {
            get;
            set;
        }

        public string ClientSecret
        {
            get;
            set;
        }

        public string DB_SequenceName
        {
            get
            {
                return this.DB_TableName.Length > 26 ? this.DB_TableName.Substring(0, 26) + "_seq" : this.DB_TableName + "_seq";
            }
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string TenantName
        {
            get;
            set;
        }

        public string EnableGroupUserImport
        {
            get;
            set;
        }

        public string DeleteGroupUsers
        {
            get;
            set;
        }
    }

    public class DB_Comment
    {
        public string Comment
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ModifiedById
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string ParentId
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }

    public class DB_DashboardDataSource
    {
        public string DashboardItemId
        {
            get;
            set;
        }

        public string DataSourceItemId
        {
            get;
            set;
        }

        public string DataSourceName
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }
    }

    public class DB_DashboardWidget
    {
        public string DashboardItemId
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string WidgetDesignerId
        {
            get;
            set;
        }

        public string WidgetItemId
        {
            get;
            set;
        }
        
        public string WidgetInfo
        {
            get;
            set;
        }
    }

    public class DB_DatasetLinkage
    {
        public string DatasetItemId
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_DataSourceDetail
    {
        public string DataSourceId
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
    }

    public class DB_ExportType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_FavoriteItem
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }

    public class DB_Group
    {
        public string Color
        {
            get;
            set;
        }

        public string IsolationCode
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string DirectoryTypeId
        {
            get;
            set;
        }

        public string ExternalProviderId
        {
            get;
            set;
        }
    }

    public class DB_GroupPermission
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string GroupId
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string PermissionAccessId
        {
            get;
            set;
        }

        public string PermissionEntityId
        {
            get;
            set;
        }
        public string ScopeGroupId
        {
            get;
            set;
        }

        public string SettingsTypeId
        {
            get;
            set;
        }

        public string ItemTypeId
        {
            get;
            set;
        }
    }

    public class DB_Homepage
    {
        public string CreatedDate
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsDefaultHomepage
        {
            get;
            set;
        }

        public string ItemInfo
        {
            get;
            set;
        }

        public string ItemType
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }

    public class DB_HomepageItemFilter
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string FilterId
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string HomepageId
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string QueryString
        {
            get;
            set;
        }
    }

    public class DB_Item
    {
        public string CloneItemId
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Extension
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsSampleData
        {
            get;
            set;
        }

        public string DataSource
        {
            get;
            set;
        }

        public string IsPublic
        {
            get;
            set;
        }

        public string ItemTypeId
        {
            get;
            set;
        }

        public string ModifiedById
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ParentId
        {
            get;
            set;
        }

        public string IsDraft
        {
            get;
            set;
        }

        public string IsLocked
        {
            get;
            set;
        }

#if (BoldReportsOnPremise || BoldReportsCloud)
        public string IsUserBased
        {
            get;
            set;
        }
#endif
    }

    public class DB_ItemCommentLog
    {
        public string ClubId
        {
            get;
            set;
        }

        public string CommentId
        {
            get;
            set;
        }

        public string CurrentUserId
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsRead
        {
            get;
            set;
        }

        public string ItemCommentLogTypeId
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string NewValue
        {
            get;
            set;
        }

        public string NotificationTo
        {
            get;
            set;
        }

        public string OldValue
        {
            get;
            set;
        }

        public string RepliedFor
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }
    }

    public class DB_ItemCommentLogType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_ItemLog
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string FromCategoryId
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ItemLogTypeId
        {
            get;
            set;
        }

        public string ItemVersionId
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string ParentId
        {
            get;
            set;
        }

        public string ToCategoryId
        {
            get;
            set;
        }

        public string UpdatedUserId
        {
            get;
            set;
        }
#if(BoldReportsOnPremise)
        public string AdditionalLogInfo
        {
            get; set;
        }
#endif
        public string SourceTypeId
        {
            get;
            set;
        }
    }

    public class DB_ItemLogType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_ItemTrash
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string TrashedById
        {
            get;
            set;
        }

        public string TrashedDate
        {
            get;
            set;
        }
    }

    public class DB_ItemTrashDeleted
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string DeletedById
        {
            get;
            set;
        }

        public string DeletedDate
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ItemTrashId
        {
            get;
            set;
        }
    }

    public class DB_ItemType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_ItemVersion
    {
        public string Comment
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsCurrentVersion
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ItemName
        {
            get;
            set;
        }

        public string ItemTypeId
        {
            get;
            set;
        }

        public string RolledbackVersionNumber
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }
    }

    public class DB_ItemView
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ItemViewId
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string QueryString
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }

    public class DB_ItemWatch
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsWatched
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }

    public class DB_MultiTabDashboard
    {
        public string ParentDashboardId
        {
            get;
            set;
        }

        public string ChildDashboardId
        {
            get;
            set;
        }

        public string DashboardDesignerId
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string OrderNumber
        {
            get;
            set;
        }
    }

    public class DB_PermissionAccess
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string AccessId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_PermissionAccEntity
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string PermissionEntityId
        {
            get;
            set;
        }
        public string PermissionAccessId
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_PermissionEntity
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string EntityType
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ItemTypeId
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    //public class DB_ProcessOption
    //{
    //    public string CreatedDate
    //    {
    //        get;
    //        set;
    //    }

    //    public string DB_TableName
    //    {
    //        get;
    //        set;
    //    }

    //    public string Id
    //    {
    //        get;
    //        set;
    //    }

    //    public string IsActive
    //    {
    //        get;
    //        set;
    //    }

    //    public string ItemId
    //    {
    //        get;
    //        set;
    //    }

    //    public string ModifiedDate
    //    {
    //        get;
    //        set;
    //    }

    //    public string NextScheduleDate
    //    {
    //        get;
    //        set;
    //    }

    //    public string ProcessOption
    //    {
    //        get;
    //        set;
    //    }
    //}

    //public class DB_ProcessOptionMap
    //{
    //    public string DB_TableName
    //    {
    //        get;
    //        set;
    //    }

    //    public string Id
    //    {
    //        get;
    //        set;
    //    }

    //    public string IsActive
    //    {
    //        get;
    //        set;
    //    }

    //    public string ItemId
    //    {
    //        get;
    //        set;
    //    }

    //    public string ProcessOptionId
    //    {
    //        get;
    //        set;
    //    }
    //}

    public class DB_RecurrenceType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_ReportDataSource
    {
        public string DataSourceItemId
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ReportItemId
        {
            get;
            set;
        }
    }

    public class DB_SchdLogExtnRecpt
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string DeliveredDate
        {
            get;
            set;
        }

        public string DeliveredEmailId
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsOnDemand
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string ScheduleStatusId
        {
            get;
            set;
        }
    }

    public class DB_ScheduleDetail
    {
        public string CreatedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string EndAfter
        {
            get;
            set;
        }

        public string EndDate
        {
            get;
            set;
        }

        public string ExportTypeId
        {
            get;
            set;
        }

        public string EmailContent
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsEnabled
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ModifiedById
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ExportFileName
        {
            get;
            set;
        }

        public string NextSchedule
        {
            get;
            set;
        }

        public string RecurrenceInfo
        {
            get;
            set;
        }

        public string RecurrenceTypeId
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string StartDate
        {
            get;
            set;
        }

        public string IsDataChanges
        {
            get;
            set;
        }

        public string IsTimeInterval
        {
            get;
            set;
        }

#if (BoldReportsOnPremise || BoldReportsCloud)
        public string ExportFileSettingsInfo
        {
            get;
            set;
        }

        public string IsParameterEnabled
        {
            get;
            set;
        }

        public string IsSaveAsFile
        {
            get;
            set;
        }

        public string IsSendAsMail
        {
            get;
            set;
        }

        public string ReportCount
        {
            get;
            set;
        }

        public string ExportPath
        {
            get;
            set;
        }
        public string IsOverwrite
        {
            get;
            set;
        }

        public string IsNotifySaveAs
        {
            get;
            set;
        }

        public string ScheduleExportInfo
        {
            get;
            set;
        }
#endif
    }

    public class DB_ScheduleLog
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string ExecutedDate
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsOnDemand
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string ScheduleStatusId
        {
            get;
            set;
        }
#if(BoldReportsOnPremise)
        public string Message
        {
            get;
            set;
        }
#endif
    }

    public class DB_ScheduleLogGroup
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string DeliveredDate
        {
            get;
            set;
        }

        public string DeliveredUserId
        {
            get;
            set;
        }

        public string GroupId
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsOnDemand
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string ScheduleStatusId
        {
            get;
            set;
        }
    }

    public class DB_ScheduleLogUser
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string DeliveredDate
        {
            get;
            set;
        }

        public string DeliveredUserId
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsOnDemand
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string ScheduleStatusId
        {
            get;
            set;
        }
    }

    public class DB_ScheduleStatus
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_ServerVersion
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }
    }

    public class DB_SubscrExtnRecpt
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string EmailIds
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string SubscribedById
        {
            get;
            set;
        }

        public string SubscribedDate
        {
            get;
            set;
        }
    }

    public class DB_SubscribedGroup
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string RecipientGroupId
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string SubscribedById
        {
            get;
            set;
        }

        public string SubscribedDate
        {
            get;
            set;
        }
    }

    public class DB_SubscribedUser
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string RecipientUserId
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string SubscribedById
        {
            get;
            set;
        }

        public string SubscribedDate
        {
            get;
            set;
        }
    }

    public class DB_SyncUMP
    {
        public DB_AzureADCredential DB_AzureADCredential
        {
            get;
            set;
        }

        public DB_Comment DB_Comment
        {
            get;
            set;
        }

        public DB_ItemCommentLogType DB_CommentLogType
        {
            get;
            set;
        }

        public DB_DashboardDataSource DB_DashboardDataSource
        {
            get;
            set;
        }

        public DB_DashboardWidget DB_DashboardWidget
        {
            get;
            set;
        }

        public DB_DatasetLinkage DB_DatasetLinkage
        {
            get;
            set;
        }

        public DB_DataSourceDetail DB_DataSourceDetail
        {
            get;
            set;
        }

        public DB_ExportType DB_ExportType
        {
            get;
            set;
        }

        public DB_FavoriteItem DB_FavoriteItem
        {
            get;
            set;
        }

        public DB_Group DB_Group
        {
            get;
            set;
        }

        public DB_GroupPermission DB_GroupPermission
        {
            get;
            set;
        }

        public DB_Homepage DB_Homepage
        {
            get;
            set;
        }

        public DB_HomepageItemFilter DB_HomepageItemFilter
        {
            get;
            set;
        }

        public DB_Item DB_Item
        {
            get;
            set;
        }

        public DB_ItemCommentLog DB_ItemCommentLog
        {
            get;
            set;
        }

        public DB_ItemLog DB_ItemLog
        {
            get;
            set;
        }

        public DB_ItemLogType DB_ItemLogType
        {
            get;
            set;
        }

        public DB_ItemTrash DB_ItemTrash
        {
            get;
            set;
        }

        public DB_ItemTrashDeleted DB_ItemTrashDeleted
        {
            get;
            set;
        }

        public DB_ItemType DB_ItemType
        {
            get;
            set;
        }

        public DB_ItemVersion DB_ItemVersion
        {
            get;
            set;
        }

        public DB_ItemView DB_ItemView
        {
            get;
            set;
        }

        public DB_ItemWatch DB_ItemWatch
        {
            get;
            set;
        }

        public DB_MultiTabDashboard DB_MultiTabDashboard
        {
            get;
            set;
        }

        public DB_PermissionAccEntity DB_PermissionAccEntity
        {
            get;
            set;
        }

        public DB_PermissionAccess DB_PermissionAccess
        {
            get;
            set;
        }

        public DB_PermissionEntity DB_PermissionEntity
        {
            get;
            set;
        }

        //public DB_ProcessOption DB_ProcessOption
        //{
        //    get;
        //    set;
        //}

        //public DB_ProcessOptionMap DB_ProcessOptionMap
        //{
        //    get;
        //    set;
        //}

        public DB_RecurrenceType DB_RecurrenceType
        {
            get;
            set;
        }

        public DB_ReportDataSource DB_ReportDataSource
        {
            get;
            set;
        }

        public DB_SchdLogExtnRecpt DB_SchdLogExtnRecpt
        {
            get;
            set;
        }

        public DB_ScheduleDetail DB_ScheduleDetail
        {
            get;
            set;
        }

        public DB_ScheduleLog DB_ScheduleLog
        {
            get;
            set;
        }

        public DB_ScheduleLogGroup DB_ScheduleLogGroup
        {
            get;
            set;
        }

        public DB_ScheduleLogUser DB_ScheduleLogUser
        {
            get;
            set;
        }

        public DB_ScheduleStatus DB_ScheduleStatus
        {
            get;
            set;
        }

        public DB_ServerVersion DB_ServerVersion
        {
            get;
            set;
        }

        public DB_SubscrExtnRecpt DB_SubscrExtnRecpt
        {
            get;
            set;
        }

        public DB_SubscribedGroup DB_SubscribedGroup
        {
            get;
            set;
        }

        public DB_SubscribedUser DB_SubscribedUser
        {
            get;
            set;
        }

        public DB_SystemLog DB_SystemLog
        {
            get;
            set;
        }

        public DB_SystemLogType DB_SystemLogType
        {
            get;
            set;
        }

        public DB_SystemSettings DB_SystemSettings
        {
            get;
            set;
        }

        public DB_User DB_User
        {
            get;
            set;
        }

        public DB_UserGroup DB_UserGroup
        {
            get;
            set;
        }

        public DB_UserLog DB_UserLog
        {
            get;
            set;
        }

        public DB_UserLogin DB_UserLogin
        {
            get;
            set;
        }

        public DB_UserLogType DB_UserLogType
        {
            get;
            set;
        }

        public DB_UserPermission DB_UserPermission
        {
            get;
            set;
        }

        public DB_UserPreference DB_UserPreference
        {
            get;
            set;
        }

        public DB_UserType DB_UserType
        {
            get;
            set;
        }

        public DB_DataNotification DB_DataNotification
        {
            get;
            set;
        }

        public DB_UserDataNotification DB_UserDataNotification
        {
            get;
            set;
        }

        public DB_ConditionCategory DB_ConditionCategory
        {
            get;
            set;
        }
        public DB_DBCredential DB_DBCredential
        {
            get;
            set;
        }

        public DB_TableRelation DB_TableRelation
        {
            get;
            set;
        }

        public DB_CustomExpression DB_CustomExpression
        {
            get;
            set;
        }

        public DB_Source DB_Source
        {
            get;
            set;
        }

        public DB_SlideshowInfo DB_SlideshowInfo
        {
            get;
            set;
        }

        public DB_PermissionLogType DB_PermissionLogType
        {
            get;
            set;
        }

        public DB_UserPermissionLog DB_UserPermissionLog
        {
            get;
            set;
        }

        public DB_GroupPermissionLog DB_GroupPermissionLog
        {
            get;
            set;
        }

        public DB_LogField DB_LogField
        {
            get;
            set;
        }

        public DB_LogModule DB_LogModule
        {
            get;
            set;
        }

        public DB_LogStatus DB_LogStatus
        {
            get;
            set;
        }

        public DB_GroupLogType DB_GroupLogType
        {
            get;
            set;
        }

        public DB_GroupLog DB_GroupLog
        {
            get;
            set;
        }

        public DB_ItemSettings DB_ItemSettings
        {
            get;
            set;
        }

        public DB_ItemUserPreference DB_ItemUserPreference
        {
            get;
            set;
        }

        public DB_PublishedItem DB_PublishedItem
        {
            get;
            set;
        }

        public DB_PublishJobs DB_PublishJobs
        {
            get;
            set;
        }        

        public DB_DeploymentDashboards DB_DeploymentDashboards
        {
            get;
            set;
        }

        public DB_UserAttributes DB_UserAttributes
        {
            get;
            set;
        }

        public DB_GroupAttributes DB_GroupAttributes
        {
            get;
            set;
        }

        public DB_SiteAttributes DB_SiteAttributes
        {
            get;
            set;
        }

        public DB_ExternalSites DB_ExternalSites
        {
            get;
            set;
        }

        public DB_SettingsType DB_SettingsType
        {
            get;
            set;
        }

        public DB_AttributeType DB_AttributeType
        {
            get;
            set;
        }

        public DB_ItemAttribute DB_ItemAttribute
        {
            get;
            set;
        }

#if (DashboardServerOnPremise || BoldReportsOnPremise)
        public DB_ADCredentials DB_ADCredentials
        {
            get;
            set;
        }
#endif
#if (BoldReportsOnPremise || BoldReportsCloud)
        public DB_ScheduleParameter DB_ScheduleParameter
        {
            get;
            set;
        }
#endif
        public DB_ReportPartType DB_ReportPartType
        {
            get;
            set;
        }

        public DB_ReportPartTypeInfo DB_ReportPartTypeInfo
        {
            get;
            set;
        }

        public DB_ReportPartLinkage DB_ReportPartLinkage
        {
            get;
            set;
        }

        public DB_UserSession DB_UserSession
        {
            get;
            set;
        }
    }

    public class DB_DeploymentDashboards
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }
        
        public string ItemName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }

        public string IsDashboardLocked
        {
            get;
            set;
        }

        public string IsDatasourceLocked
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_PublishJobs
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string PublishId
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string JobDetails
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string CompletedDate
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_PublishedItem
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string TenantId
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ItemName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string DestinationItemId
        {
            get;
            set;
        }

        public string IsLocked
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string PublishType
        {
            get;
            set;
        }
    }

    public class DB_SystemLog
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string SystemLogTypeId
        {
            get;
            set;
        }

        public string LogFieldId
        {
            get;
            set;
        }

        public string OldValue
        {
            get;
            set;
        }

        public string NewValue
        {
            get;
            set;
        }

        public string LogStatusId
        {
            get;
            set;
        }

        public string UpdatedUserId
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_SystemLogType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_SystemSettings
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }

    public class DB_User
    {
        public string Contact
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string DisplayName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActivated
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string IsDeleted
        {
            get;
            set;
        }

        public string LastLogin
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Picture
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string PasswordChangedDate
        {
            get;
            set;
        }

        public string DirectoryTypeId
        {
            get;
            set;
        }

        public string IdPReferenceId
        {
            get;
            set;
        }

        public string ExternalProviderId
        {
            get;
            set;
        }

        public string CanSync
        {
            get;
            set;
        }

        public string IsCloseRequest
        {
            get;
            set;
        }
    }

    public class DB_UserGroup
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string GroupId
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }

    public class DB_UserLog
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ActivityId
        {
            get;
            set;
        }

        public string UserLogTypeId
        {
            get;
            set;
        }

        public string LogFieldId
        {
            get;
            set;
        }

        public string NewValue
        {
            get;
            set;
        }

        public string OldValue
        {
            get;
            set;
        }

        public string TargetUserId
        {
            get;
            set;
        }

        public string CurrentUserId
        {
            get;
            set;
        }

        public string SourceTypeId
        {
            get;
            set;
        }

        public string LogStatusId
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_UserLogin
    {
        public string ClientToken
        {
            get;
            set;
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IpAddress
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string LoggedInTime
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
    }

    public class DB_UserLogType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_UserPermission
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string PermissionAccessId
        {
            get;
            set;
        }

        public string PermissionEntityId
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string ScopeGroupId
        {
            get;
            set;
        }

        public string SettingsTypeId
        {
            get;
            set;
        }

        public string ItemTypeId
        {
            get;
            set;
        }
    }

    public class DB_UserPreference
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string ItemFilters
        {
            get;
            set;
        }

        public string ItemSort
        {
            get;
            set;
        }

        public string Language
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string Notifications
        {
            get;
            set;
        }

        public string RecordSize
        {
            get;
            set;
        }

        public string TimeZone
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string Dashboards
        {
            get;
            set;
        }

        public string IsolationCode
        {
            get;
            set;
        }

        public string ViewerFeatures
        {
            get;
            set;
        }

        public string DesignerFeatures
        {
            get;
            set;
        }

        public string ServerFeatures
        {
            get;
            set;
        }
    }

    public class DB_UserType
    {
        public string DB_SequenceName
        {
            get
            {
                return this.DB_TableName.Length > 26 ? this.DB_TableName.Substring(0, 26) + "_seq" : this.DB_TableName + "_seq";
            }
        }

        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }
    }

    public class DB_DataNotification
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string DataSourceId
        {
            get;
            set;
        }

        public string DaJsonString
        {
            get;
            set;
        }

        public string FilterData
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_UserDataNotification
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string FilterData
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_ConditionCategory
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

    }

    public class DB_DBCredential
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string EmailRelationId
        {
            get;
            set;
        }

        public string FirstNameRelationId
        {
            get;
            set;
        }

        public string LastNameRelationId
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }

        public string DatabaseType
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public string ActiveStatusValue
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string EmailColumn
        {
            get;
            set;
        }

        public string EmailSchema
        {
            get;
            set;
        }

        public string EmailTable
        {
            get;
            set;
        }

        public string FirstNameColumn
        {
            get;
            set;
        }

        public string FirstNameSchema
        {
            get;
            set;
        }

        public string FirstNameTable
        {
            get;
            set;
        }

        public string LastNameColumn
        {
            get;
            set;
        }

        public string LastNameSchema
        {
            get;
            set;
        }

        public string LastNameTable
        {
            get;
            set;
        }

        public string UserNameColumn
        {
            get;
            set;
        }

        public string UserNameSchema
        {
            get;
            set;
        }

        public string UserNameTable
        {
            get;
            set;
        }

        public string IsActiveColumn
        {
            get;
            set;
        }

        public string IsActiveSchema
        {
            get;
            set;
        }

        public string IsActiveTable
        {
            get;
            set;
        }

        public string IsActiveRelationId
        {
            get;
            set;
        }
    }

    public class DB_TableRelation
    {

        public string DB_TableName
        {
            get;
            set;
        }
        public string Id
        {
            get;
            set;
        }
        public string LeftTable
        {
            get;
            set;
        }

        public string LeftTableColumnName
        {
            get;
            set;
        }

        public string LeftTableCondition
        {
            get;
            set;
        }

        public string LeftTableName
        {
            get;
            set;
        }

        public string LeftTableSchema
        {
            get;
            set;
        }

        public string Relationship
        {
            get;
            set;
        }

        public string RightTable
        {
            get;
            set;
        }

        public string RightTableColumnName
        {
            get;
            set;
        }

        public string RightTableCondition
        {
            get;
            set;
        }

        public string RightTableName
        {
            get;
            set;
        }

        public string RightTableSchema
        {
            get;
            set;
        }
    }

    public class DB_CustomExpression
    {
        public string DB_TableName
        {
            get;
            set;
        }
        public string Id
        {
            get;
            set;
        }
        public string DashboardId
        {
            get;
            set;
        }

        public string WidgetId
        {
            get;
            set;
        }

        public string DatasourceId
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Expression
        {
            get;
            set;
        }

        public string ColumnInfo
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_SlideshowInfo
    {
        public string DB_TableName
        {
            get;
            set;
        }
        public string Id
        {
            get;
            set;
        }
        public string SlideshowId
        {
            get;
            set;
        }

        public string ItemInfo
        {
            get;
            set;
        }

        public string LoopInterval
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_Source
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_PermissionLogType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_UserPermissionLog
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }


        public string UserId
        {
            get;
            set;
        }

        public string AffectedUserId
        {
            get;
            set;
        }

        public string UserPermissionId
        {
            get;
            set;
        }

        public string LogTypeId
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_GroupPermissionLog
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }


        public string UserId
        {
            get;
            set;
        }

        public string AffectedGroupId
        {
            get;
            set;
        }

        public string GroupPermissionId
        {
            get;
            set;
        }

        public string LogTypeId
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_LogField
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }


        public string ModuleId
        {
            get;
            set;
        }

        public string Field
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_LogModule
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_LogStatus
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_GroupLogType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class DB_GroupLog
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ActivityId
        {
            get;
            set;
        }

        public string GroupLogTypeId
        {
            get;
            set;
        }

        public string LogFieldId
        {
            get;
            set;
        }

        public string NewValue
        {
            get;
            set;
        }

        public string OldValue
        {
            get;
            set;
        }

        public string TargetGroupId
        {
            get;
            set;
        }

        public string CurrentUserId
        {
            get;
            set;
        }

        public string SourceTypeId
        {
            get;
            set;
        }

        public string LogStatusId
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_ItemSettings
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string ItemConfig
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }    

    public class DB_ItemUserPreference
    {
        public string DB_TableName
        {
            get;
            set;
        }
        public string Id { get; set; }

        public string ItemId { get; set; }

        public string UserId { get; set; }

        public string AutosaveFilter { get; set; }

        public string DefaultViewId { get; set; }

        public string ModifiedDate { get; set; }

        public string IsActive { get; set; }
    }

    public class DB_UserAttributes
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Encrypt
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string ModifiedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_GroupAttributes
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Encrypt
        {
            get;
            set;
        }

        public string GroupId
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string ModifiedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_SiteAttributes
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Encrypt
        {
            get;
            set;
        }
		
        public string CreatedById
        {
            get;
            set;
        }

        public string ModifiedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_ExternalSites
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ClientId
        {
            get;
            set;
        }

        public string ClientSecret
        {
            get;
            set;
        }

        public string SiteURL
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_AttributeType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }
    }

    public class DB_ItemAttribute
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ItemTypeId
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string AttributeType
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }
        public string ModifiedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_SettingsType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

#if (DashboardServerOnPremise || BoldReportsOnPremise)
    public class DB_ADCredentials
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string DistinguishedName
        {
            get;
            set;
        }

        public string EnableSsl
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string LdapUrl
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string PortNo
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string EnableGroupUserImport
        {
            get;
            set;
        }
    }
#endif
#if (BoldReportsOnPremise || BoldReportsCloud)
    public class DB_ScheduleParameter
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ScheduleId
        {
            get;
            set;
        }

        public string Parameter
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

    }
#endif
    public class DB_ReportPartType
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_ReportPartTypeInfo
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ReportPartId
        {
            get;
            set;
        }

        public string ReportPartTypeId
        {
            get;
            set;
        }

        public string ItemTypeId
        {
            get;
            set;
        }

        public string ItemId
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string ModifiedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_ReportPartLinkage
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ReportPartId
        {
            get;
            set;
        }

        public string ReportId
        {
            get;
            set;
        }

        public string CreatedById
        {
            get;
            set;
        }

        public string ModifiedById
        {
            get;
            set;
        }

        public string CreatedDate
        {
            get;
            set;
        }

        public string ModifiedDate
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }
    }

    public class DB_UserSession
    {
        public string DB_TableName
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string IdpReferenceId
        {
            get;
            set;
        }

        public string DirectoryTypeId
        {
            get;
            set;
        }

        public string IpAddress
        {
            get;
            set;
        }

        public string LoggedInTime
        {
            get;
            set;
        }

        public string IsActive
        {
            get;
            set;
        }

        public string SessionId
        {
            get;
            set;
        }

        public string Browser
        {
            get;
            set;
        }

        public string LastActive
        {
            get;
            set;
        }
    }
}