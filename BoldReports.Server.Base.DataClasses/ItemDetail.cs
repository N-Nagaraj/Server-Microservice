namespace BoldReports.Server.Base.DataClasses
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ItemDetail
    {
        [DataMember]
        public bool CanClone
        {
            get;
            set;
        }

        [DataMember]
        public bool CanCopy
        {
            get;
            set;
        }

        [DataMember]
        public bool CanCreateItem
        {
            get;
            set;
        }

        [DataMember]
        public bool CanDelete
        {
            get;
            set;
        }

        [DataMember]
        public bool CanDownload
        {
            get;
            set;
        }

        [DataMember]
        public bool CanMove
        {
            get;
            set;
        }

        [DataMember]
        public bool CanOpen
        {
            get;
            set;
        }

        [DataMember]
        public bool CanRead
        {
            get;
            set;
        }

        [DataMember]
        public bool CanSchedule
        {
            get;
            set;
        }

        [DataMember]
        public bool CanWrite
        {
            get;
            set;
        }

        [DataMember]
        public string CategoryDescription
        {
            get;
            set;
        }

        [DataMember]
        public Guid? CategoryId
        {
            get;
            set;
        }

        [DataMember]
        public string CategoryName
        {
            get;
            set;
        }

        [DataMember]
        public string CategoryOwnerName
        {
            get;
            set;
        }

        [DataMember]
        public Guid? CloneOf
        {
            get;
            set;
        }

        [DataMember]
        public string CreatedByDisplayName
        {
            get;
            set;
        }

        [DataMember]
        public int CreatedById
        {
            get;
            set;
        }

        [DataMember]
        public string CreatedDate
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get;
            set;
        }

        [DataMember]
        public string DesignerArgument
        {
            get;
            set;
        }

        [DataMember]
        public string Extension
        {
            get;
            set;
        }

        [DataMember]
        public string FileName
        {
            get;
            set;
        }

        [DataMember]
        public Guid Id
        {
            get;
            set;
        }

        [DataMember]
        public bool IsCreatedByActive
        {
            get;
            set;
        }

        [DataMember]
        public bool IsFavorite
        {
            get;
            set;
        }

        [DataMember]
        public List<string> Tags
        {
            get;
            set;
        }

        [DataMember]
        public bool IsModifiedByActive
        {
            get;
            set;
        }

        [DataMember]
        public bool IsPublic
        {
            get;
            set;
        }

        [DataMember]
        public DateTime ItemCreatedDate
        {
            get;
            set;
        }

        [DataMember]
        public string ItemLocation
        {
            get;
            set;
        }

        [DataMember]
        public DateTime ItemModifiedDate
        {
            get;
            set;
        }

        [DataMember]
        public ItemType ItemType
        {
            get;
            set;
        }

        [DataMember]
        public string ItemTypeString
        {
            get;
            set;
        }

        [DataMember]
        public string ModifiedByFullName
        {
            get;
            set;
        }

        [DataMember]
        public int ModifiedById
        {
            get;
            set;
        }

        [DataMember]
        public string ModifiedDate
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public bool IsMultiDashboard
        {
            get;
            set;
        }

        [DataMember]
        public bool IsChildDashboard
        {
            get;
            set;
        }

        [DataMember]
        public List<ItemDetail> ChildDashboards
        {
            get;
            set;
        }

        [DataMember]
        public string ParentCategoryName
        {
            get;
            set;
        }

        [DataMember]
        public bool IsActive
        {
            get;
            set;
        }

        [DataMember]
        public bool IsSampleData
        {
            get;
            set;
        }

        [DataMember]
        public byte[] FileContent
        {
            get;
            set;
        }

        public string DataSource
        {
            get;
            set;
        }
        public string DataSet
        {
            get;
            set;
        }


        [DataMember]
        public bool IsDraft
        {
            get;
            set;
        }

        /// <summary>
        /// If Datasouce item scheduled
        /// </summary>
        public bool IsScheduled
        {
            get;
            set;
        }

        /// <summary>
        /// Datasource schedule last attempt date time
        /// </summary>
        public string LastAttemptAt
        {
            get;
            set;
        }

        /// <summary>
        /// Datasource schedule last attempt date time
        /// </summary>
        public string LastSuccessfulAttemptAt
        {
            get;
            set;
        }   

        /// <summary>
        /// Datasource occupied row count in intermediate database
        /// </summary>
        public long RowCount
        {
            get;
            set;
        }

        [DataMember]
        public bool IsLocked
        {
            get;
            set;
        }

        [DataMember]
        public Guid DestinationId
        {
            get;
            set;
        }

        [DataMember]
        public int UserId
        {
            get;
            set;
        }

        [DataMember]
        public string SiteIdentifier
        {
            get;
            set;
        }

#if (BoldReportsOnPremise || BoldReportsCloud)
        [DataMember]
        public bool IsUserbased
        {
            get;
            set;
        }

        [DataMember]
        public Guid ReportId
        {
            get;
            set;
        }

        [DataMember]
        public string ReportName
        {
            get;
            set;
        }
#endif

#if (DashboardServerCloud || DashboardServerOnPremise)

        [DataMember]
        public Guid DashboardId
        {
            get;
            set;
        }

        [DataMember]
        public string DashboardName
        {
            get;
            set;
        }
#endif
    }
}