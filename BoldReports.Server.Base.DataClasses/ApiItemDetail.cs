﻿namespace BoldReports.Server.Base.DataClasses
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Item details
    /// </summary>
    public class ApiItemDetail
    {
        /// <summary>
        /// Specifies the read permission of the item
        /// </summary>
        [DataMember]
        public bool CanRead { get; set; }

        /// <summary>
        /// Specifies the write permission of the item
        /// </summary>
        [DataMember]
        public bool CanWrite { get; set; }

        /// <summary>
        /// Specifies the delete permission of the item
        /// </summary>
        [DataMember]
        public bool CanDelete { get; set; }

        /// <summary>
        /// Specifies the download permission of the item
        /// </summary>
        [DataMember]
        public bool CanDownload { get; set; }

        /// <summary>
        /// Specifies the schedule permission of the item
        /// </summary>
        [DataMember]
        public bool CanSchedule { get; set; }

        /// <summary>
        /// Specifies the open permission of the item
        /// </summary>
        [DataMember]
        public bool CanOpen { get; set; }

        /// <summary>
        /// Specifies the move permission of the item
        /// </summary>
        [DataMember]
        public bool CanMove { get; set; }

        /// <summary>
        /// Specifies the copy permission of the item
        /// </summary>
        [DataMember]
        public bool CanCopy { get; set; }

        /// <summary>
        /// Specifies the clone permission of the item
        /// </summary>
        [DataMember]
        public bool CanClone { get; set; }

        /// <summary>
        /// Specifies the create permission of the item
        /// </summary>
        [DataMember]
        public bool CanCreateItem { get; set; }

        /// <summary>
        /// Item ID
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// Item type
        /// </summary>
        [DataMember]
        public ItemType ItemType { get; set; }

        /// <summary>
        /// Item name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Item description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Item location
        /// </summary>
        [DataMember]
        public string ItemLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Returns true if the item is favorite.
        /// </summary>
        [DataMember]
        public bool? IsFavorite
        {
            get;
            set;
        }

        /// <summary>
        /// Report item tag list
        /// </summary>
        [DataMember]
        public List<string> Tags
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies the user ID of the item creator
        /// </summary>
        [DataMember]
        public int CreatedById { get; set; }

        /// <summary>
        /// Specifies the display name of the user who created the item
        /// </summary>
        [DataMember]
        public string CreatedByDisplayName { get; set; }

        /// <summary>
        /// Specifies the user ID of the item modifier
        /// </summary>
        [DataMember]
        public int ModifiedById { get; set; }

        /// <summary>
        /// Specifies the full name of the user who modified the item
        /// </summary>
        [DataMember]
        public string ModifiedByFullName { get; set; }

        /// <summary>
        /// Category ID
        /// </summary>
        [DataMember]
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        [DataMember]
        public string CategoryName { get; set; }

        /// <summary>
        /// Date created of item in string format
        /// </summary>
        [DataMember]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Date modified of item in string format
        /// </summary>
        [DataMember]
        public string ModifiedDate { get; set; }

        /// <summary>
        /// Date modified of item in date format
        /// </summary>
        [DataMember]
        public DateTime ItemModifiedDate { get; set; }

        /// <summary>
        /// Date created of item in date format
        /// </summary>
        [DataMember]
        public DateTime ItemCreatedDate { get; set; }

#if (DashboardServerCloud || DashboardServerOnPremise)
        [DataMember]
        public Guid DashboardId { get; set; }

        [DataMember]
        public string DashboardName { get; set; }
#endif

#if (BoldReportsOnPremise || BoldReportsCloud)
        [DataMember]
        public Guid ReportId { get; set; }

        [DataMember]
        public string ReportName { get; set; }
#endif
    }
}
