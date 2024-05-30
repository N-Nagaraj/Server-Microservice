namespace BoldReports.Server.Base
{
    using System.Linq;
    using System.Collections.Generic;
    
    using BoldReports.Server.Base.DataClasses;
    using BoldReports.Server.Base.Resolvers;
    using System.Security;

    public class QueryBuilderHelper
    {
        private readonly TenantSettings _globalAppSettings;
        private readonly SystemSetting _systemSetting;

        public QueryBuilderHelper(TenantSettings globalAppSettings, SystemSetting systemSetting)
        {
            _globalAppSettings = globalAppSettings;
            _systemSetting = systemSetting;

        }

        public string GetActiveDirectoryUserDetail()
        {
            string query = string.Empty;
            switch (_globalAppSettings.DBSupport)
            {
                case DatabaseType.MSSQL:
                case DatabaseType.MSSQLCE:
                    query = "SELECT a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId + " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.CanSync + " AS CanSync,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a."
                            + _globalAppSettings.DBColumns.DB_User.DisplayName +
                            " as DisplayName FROM [" +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + "] AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + "=" + (int)DirectoryType.WindowsAD + " AND a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;

                case DatabaseType.MySQL:
                    query = "SELECT a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId + " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.CanSync + " AS CanSync,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a."
                            + _globalAppSettings.DBColumns.DB_User.DisplayName +
                            " as DisplayName FROM `" +
                            _systemSetting.SystemSettings.SqlConfiguration.DatabaseName + "`." +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + "=" + (int)DirectoryType.WindowsAD + " AND a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;

                case DatabaseType.Oracle:
                    query = "SELECT a.\"" +
                            _globalAppSettings.DBColumns.DB_User.FirstName + "\" AS FirstName,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.LastName + "\" AS LastName,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Email + "\" AS Email,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsActive + "\" AS IsActive,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId + "\" AS ExternalProviderId,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Id + "\" AS Id,a.\""
                            + _globalAppSettings.DBColumns.DB_User.DisplayName +
                            "\" as DisplayName FROM \"" +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + "\" a where a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "\"=0";
                    break;

                case DatabaseType.PostgreSQL:
                    query = "SELECT a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId + " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.CanSync + " AS CanSync,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a."
                            + _globalAppSettings.DBColumns.DB_User.DisplayName +
                            " as DisplayName FROM " +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + "=" + (int)DirectoryType.WindowsAD + " AND a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;
            }

            return query;
        }

        public string GetAllGeneralUsers()
        {
            string query = string.Empty;
            switch (_globalAppSettings.DBSupport)
            {
                case DatabaseType.MSSQL:
                case DatabaseType.MSSQLCE:
                    query = "SELECT NULL as ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                            _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName,a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + " AS DirectoryTypeId,a." +
                            _globalAppSettings.DBColumns.DB_User.Contact +
                            " AS Contact FROM [" +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + "] AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;

                case DatabaseType.MySQL:
                    query = "SELECT NULL as ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                            _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName, a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + " AS DirectoryTypeId, a." +
                            _globalAppSettings.DBColumns.DB_User.Contact +
                           " AS Contact FROM `" +
                            _systemSetting.SystemSettings.SqlConfiguration.DatabaseName + "`." +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;

                case DatabaseType.Oracle:
                    query = "SELECT NULL as ExternalProviderId,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.FirstName + "\" AS FirstName,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.LastName + "\" AS LastName,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Email + "\" AS Email,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Username + "\" AS Username,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsActive + "\" AS IsActive,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + "\" AS Id,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.DisplayName + "\" AS DisplayName, a.\"" +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + "\" AS DirectoryTypeId, a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Contact +
                            "\" AS Contact FROM \"" +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + "\" a where a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "\"=0";
                    break;

                case DatabaseType.PostgreSQL:
                    query = "SELECT NULL as ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                            _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName,a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + " AS DirectoryTypeId,a." +
                            _globalAppSettings.DBColumns.DB_User.Contact +
                            " AS Contact FROM " +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;
            }

            return query;
        }

        public string GetAllUsers()
        {
            string query = string.Empty;
            switch (_globalAppSettings.DBSupport)
            {
                case DatabaseType.MSSQL:
                case DatabaseType.MSSQLCE:
                    query = "SELECT a." + _globalAppSettings.DBColumns.DB_User.ExternalProviderId + " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                            _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName,a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + " AS DirectoryTypeId,a." +
                            _globalAppSettings.DBColumns.DB_User.Contact +
                            " AS Contact FROM [" +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + "] AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;

                case DatabaseType.MySQL:
                    query = "SELECT a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId + " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                            _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName, a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + " AS DirectoryTypeId, a." +
                            _globalAppSettings.DBColumns.DB_User.Contact +
                            " AS Contact FROM `" +
                            _systemSetting.SystemSettings.SqlConfiguration.DatabaseName + "`." +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;

                case DatabaseType.Oracle:
                    query = "SELECT a.\"" +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId + "\" AS ExternalProviderId,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.FirstName + "\" AS FirstName,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.LastName + "\" AS LastName,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Username + "\" AS Username,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Email + "\" AS Email,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsActive + "\" AS IsActive,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + "\" AS Id,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.DisplayName + "\" AS DisplayName, a.\"" +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + "\" AS DirectoryTypeId, a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Contact +
                            "\" AS Contact FROM \"" +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + "\" a where a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "\"=0";
                    break;

                case DatabaseType.PostgreSQL:
                    query = "SELECT a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId + " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                            _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName,a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + " AS DirectoryTypeId,a." +
                            _globalAppSettings.DBColumns.DB_User.Contact +
                            " AS Contact FROM " +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;
            }

            return query;
        }

        public string GetAzureActiveDirectoryUserDetail()
        {
            string query = string.Empty;
            switch (_globalAppSettings.DBSupport)
            {
                case DatabaseType.MSSQL:
                case DatabaseType.MSSQLCE:
                    query = "SELECT a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                             _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId +
                            " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.CanSync + " AS CanSync,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a."
                            + _globalAppSettings.DBColumns.DB_User.DisplayName +
                            " as DisplayName FROM [" +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + "] AS a " +
                            " where a." + _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + "=" + (int)DirectoryType.AzureAD + " AND a." + _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;

                case DatabaseType.MySQL:
                    query = "SELECT a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                             _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId +
                            " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.CanSync + " AS CanSync,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a."
                            + _globalAppSettings.DBColumns.DB_User.DisplayName +
                            " as DisplayName FROM `" +
                            _systemSetting.SystemSettings.SqlConfiguration.DatabaseName + "`." +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                            _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + "=" + (int)DirectoryType.AzureAD + " AND a." +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;

                case DatabaseType.Oracle:
                    query = "SELECT a.\"" +
                            _globalAppSettings.DBColumns.DB_User.FirstName + "\" AS FirstName,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.LastName + "\" AS LastName,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Username + "\" AS Username,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.Email + "\" AS Email,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsActive + "\" AS IsActive,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId +
                            "\" AS ExternalProviderId,a.\"" +
                            _globalAppSettings.DBColumns.DB_User.CanSync + " AS CanSync,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + "\" AS Id,a.\""
                            + _globalAppSettings.DBColumns.DB_User.DisplayName +
                            "\" as DisplayName FROM \"" +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + "\" a where a.\"" +
                            _globalAppSettings.DBColumns.DB_User.IsDeleted + "\"=0";
                    break;

                case DatabaseType.PostgreSQL:
                    query = "SELECT a." +
                            _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                            _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                            _globalAppSettings.DBColumns.DB_User.Username + " AS Username,a." +
                            _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActive + " AS IsActive,a." +
                            _globalAppSettings.DBColumns.DB_User.IsActivated + " AS IsActivated,a." +
                            _globalAppSettings.DBColumns.DB_User.ExternalProviderId +
                            " AS ExternalProviderId,a." +
                            _globalAppSettings.DBColumns.DB_User.CanSync + " AS CanSync,a." +
                            _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a."
                            + _globalAppSettings.DBColumns.DB_User.DisplayName +
                            " as DisplayName FROM " +
                            _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a " +
                            " where a." + _globalAppSettings.DBColumns.DB_User.DirectoryTypeId + "=" + (int)DirectoryType.AzureAD + 
                            " AND a." + _globalAppSettings.DBColumns.DB_User.IsDeleted + "=0";
                    break;
            }

            return query;
        }

        public string GetAllActiveUserGroup(string excludeEmails, string excludeGroupIds)
        {
            string query = string.Empty;
            switch (_globalAppSettings.DBSupport)
            {
                case DatabaseType.MSSQL:
                case DatabaseType.MSSQLCE:
                    query = "SELECT * from ( SELECT a." +
                        _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                        _globalAppSettings.DBColumns.DB_User.IdPReferenceId + " AS IdPReferenceId,a." +
                        _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                        _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                        _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                        _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName, 'User' AS Type FROM " +
                        _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                        _globalAppSettings.DBColumns.DB_User.IsActive + "=1";

                    if (!string.IsNullOrWhiteSpace(excludeEmails))
                    {
                        var emailList = excludeEmails.Split(',').ToList();
                        query += "AND " + _globalAppSettings.DBColumns.DB_User.Email + " NOT IN" + QueryHelper.GetArrayAsString(emailList);
                    }

                    query += ") UserListTable union SELECT* from ( SELECT b." +
                        _globalAppSettings.DBColumns.DB_Group.Id + " AS Id, null AS IdPReferenceId,null AS FirstName,null AS LastName,null AS Email,b." +
                        _globalAppSettings.DBColumns.DB_Group.Name + " AS DisplayName, 'Group' AS Type FROM " +
                        _globalAppSettings.DBColumns.DB_Group.DB_TableName + " AS b where b." +
                        _globalAppSettings.DBColumns.DB_Group.IsActive + "=1";
                    if (!string.IsNullOrWhiteSpace(excludeGroupIds))
                    {
                        var groupIdList = excludeGroupIds.Split(',').ToList();
                        query += "AND " + _globalAppSettings.DBColumns.DB_Group.Id + " NOT IN" + QueryHelper.GetArrayAsString(groupIdList);
                    }

                    query += ") GroupListTable";
                    break;

                case DatabaseType.PostgreSQL:
                    query = "SELECT * from ( SELECT a." +
                        _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                        _globalAppSettings.DBColumns.DB_User.IdPReferenceId + " AS IdPReferenceId,a." +
                        _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                        _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                        _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                        _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName, 'User' AS Type FROM " +
                        _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                        _globalAppSettings.DBColumns.DB_User.IsActive + "=1";

                    if (!string.IsNullOrWhiteSpace(excludeEmails))
                    {
                        var emailList = excludeEmails.Split(',').ToList();
                        query += "AND " + _globalAppSettings.DBColumns.DB_User.Email + " NOT IN" + QueryHelper.GetArrayAsString(emailList);
                    }

                    query += ") UserListTable union SELECT* from ( SELECT b." +
                        _globalAppSettings.DBColumns.DB_Group.Id + " AS Id, null::uuid AS IdPReferenceId,null AS FirstName,null AS LastName,null AS Email,b." +
                        _globalAppSettings.DBColumns.DB_Group.Name + " AS DisplayName, 'Group' AS Type FROM " +
                        _globalAppSettings.DBColumns.DB_Group.DB_TableName + " AS b where b." +
                        _globalAppSettings.DBColumns.DB_Group.IsActive + "=1";
                    if (!string.IsNullOrWhiteSpace(excludeGroupIds))
                    {
                        var groupIdList = excludeGroupIds.Split(',').ToList();
                        query += " AND " + _globalAppSettings.DBColumns.DB_Group.Id + " NOT IN" + QueryHelper.GetArrayAsString(groupIdList);
                    }

                    query += ") GroupListTable";
                    break;

                case DatabaseType.MySQL:
                    query = "SELECT * from ( SELECT a." +
                        _globalAppSettings.DBColumns.DB_User.Id + " AS Id,a." +
                        _globalAppSettings.DBColumns.DB_User.IdPReferenceId + " AS IdPReferenceId,a." +
                        _globalAppSettings.DBColumns.DB_User.FirstName + " AS FirstName,a." +
                        _globalAppSettings.DBColumns.DB_User.LastName + " AS LastName,a." +
                        _globalAppSettings.DBColumns.DB_User.Email + " AS Email,a." +
                        _globalAppSettings.DBColumns.DB_User.DisplayName + " AS DisplayName, 'User' AS Type FROM `" +
                        _systemSetting.SystemSettings.SqlConfiguration.DatabaseName + "`." +
                        _globalAppSettings.DBColumns.DB_User.DB_TableName + " AS a where a." +
                        _globalAppSettings.DBColumns.DB_User.IsActive + "=1";

                    if (!string.IsNullOrWhiteSpace(excludeEmails))
                    {
                        var emailList = excludeEmails.Split(',').ToList();
                        query += " AND " + _globalAppSettings.DBColumns.DB_User.Email + " NOT IN" + QueryHelper.GetArrayAsString(emailList);
                    }

                    query += ") UserListTable union SELECT* from ( SELECT b." +
                        _globalAppSettings.DBColumns.DB_Group.Id + " AS Id, null AS IdPReferenceId,null AS FirstName,null AS LastName,null AS Email,b." +
                        _globalAppSettings.DBColumns.DB_Group.Name + " AS DisplayName, 'Group' AS Type FROM `" +
                        _systemSetting.SystemSettings.SqlConfiguration.DatabaseName + "`." +
                        _globalAppSettings.DBColumns.DB_Group.DB_TableName + " AS b where b." +
                        _globalAppSettings.DBColumns.DB_Group.IsActive + "=1";
                    if (!string.IsNullOrWhiteSpace(excludeGroupIds))
                    {
                        var groupIdList = excludeGroupIds.Split(',').ToList();
                        query += " AND " + _globalAppSettings.DBColumns.DB_Group.Id + " NOT IN" + QueryHelper.GetArrayAsString(groupIdList);
                    }

                    query += ") GroupListTable";
                    break;
            }

            return query;
        }

        public virtual string GetAllItems(int userId, List<int> groupIds, ItemType? itemType = null, Guid? itemId = null,
           List<string> parentIdPermissions = null,
           List<string> sortCollection = null, List<string> filterSettings = null, string search = "",
           List<string> searchDescriptor = null, bool isWidgetListRequest = false, bool isPublicListRequest = false, bool isDraftRequired = true)
        {
            string query = string.Empty;
            switch (_globalAppSettings.DBSupport)
            {

                case DatabaseType.PostgreSQL:
                    query =
                        "SELECT UnionResult.PermissionAccessId,UnionResult.PermissionEntityId,UnionResult.IsSpecificItemPermission," +
                        _globalAppSettings.DBColumns.DB_Item.DB_TableName +
                        ".*,ParentItemTable.Name AS CategoryName,ParentItemTable.Id AS CategoryId,ParentItemTable.Description AS CategoryDescription,ParentItemTable.DisplayName AS CategoryCreatedByDisplayName, " + _globalAppSettings.DBColumns.DB_User.DB_TableName + ".FirstName AS CreatedByFirstName," + _globalAppSettings.DBColumns.DB_User.DB_TableName + ".LastName AS CreatedByLastName," + _globalAppSettings.DBColumns.DB_User.DB_TableName + ".DisplayName AS CreatedByDisplayName," + _globalAppSettings.DBColumns.DB_User.DB_TableName + ".IsActive AS IsCreatedByActive,User_modified.FirstName AS ModifiedByFirstName,User_modified.LastName AS ModifiedByLastName,User_modified.DisplayName AS ModifiedByDisplayName,User_modified.IsActive AS IsModifiedByActive," + _globalAppSettings.DBColumns.DB_FavoriteItem.DB_TableName + "." +
                        _globalAppSettings.DBColumns.DB_FavoriteItem.Id +
                        " as FavoriteId FROM (SELECT " +
                        _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                        _globalAppSettings.DBColumns.DB_Item.Id +
                        "," + _globalAppSettings.DBColumns.DB_UserPermission.DB_TableName + "." +
                        _globalAppSettings.DBColumns.DB_UserPermission.PermissionAccessId + "," +
                        _globalAppSettings.DBColumns.DB_UserPermission.DB_TableName + "." +
                        _globalAppSettings.DBColumns.DB_UserPermission.PermissionEntityId +
                        ",1 as IsSpecificItemPermission FROM " +
                        _globalAppSettings.DBColumns.DB_Item.DB_TableName +
                        " LEFT JOIN " + _globalAppSettings.DBColumns.DB_UserPermission.DB_TableName + " ON " +
                        _globalAppSettings.DBColumns.DB_UserPermission.DB_TableName + "." +
                        _globalAppSettings.DBColumns.DB_UserPermission.ItemId + "=" +
                        _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                        _globalAppSettings.DBColumns.DB_Item.Id +
                        " WHERE " + _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                        _globalAppSettings.DBColumns.DB_Item.IsActive + "=1 ";
                    if (itemType != null)
                    {
                        query += " AND " +
                                 _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_Item.ItemTypeId + "=" + (int)itemType;
                    }
                    else
                    {
                        query += " AND " +
                                 _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_Item.ItemTypeId + "!=" + (int)ItemType.Category;
                    }

                    if (!isDraftRequired)
                    {
                        query += " AND " +
                                 _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_Item.IsDraft + "=0";
                    }

                    if (itemId != null)
                    {
                        query += " AND " +
                                 _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_Item.Id + "=" + "'" + (Guid)itemId + "'";
                    }

                    query += " AND " +
                             _globalAppSettings.DBColumns.DB_UserPermission.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_UserPermission.UserId + "=" + userId +
                             " AND " + _globalAppSettings.DBColumns.DB_UserPermission.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_UserPermission.IsActive + "=1";

                    if (groupIds.Count > 0)
                    {
                        var groupString = string.Empty;
                        for (var i = 0; i < groupIds.Count; i++)
                        {
                            if (i != 0)
                            {
                                groupString += ",";
                            }

                            groupString += groupIds[i];
                        }

                        query += " UNION SELECT " + _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_Item.Id + "," +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.PermissionAccessId + "," +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.PermissionEntityId +
                                 ",1 as IsSpecificItemPermission FROM " +
                                 _globalAppSettings.DBColumns.DB_Item.DB_TableName +
                                 " LEFT JOIN " + _globalAppSettings.DBColumns.DB_GroupPermission.DB_TableName + " ON " +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.ItemId + "=" +
                                 _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_Item.Id +
                                 " WHERE " + _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_Item.IsActive + "=1";
                        if (itemType != null)
                        {
                            query += " AND " +
                                     _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                     _globalAppSettings.DBColumns.DB_Item.ItemTypeId + "=" + (int)itemType;
                        }
                        else
                        {
                            query += " AND " +
                                     _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                     _globalAppSettings.DBColumns.DB_Item.ItemTypeId + "!=" + (int)ItemType.Category;
                        }

                        if (!isDraftRequired)
                        {
                            query += " AND " +
                                     _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                     _globalAppSettings.DBColumns.DB_Item.IsDraft + "=0";
                        }

                        query += " AND " +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.GroupId + " IN (" + groupString + ")" +
                                 " AND " + _globalAppSettings.DBColumns.DB_GroupPermission.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_GroupPermission.IsActive + "=1";
                    }

                    if (!isDraftRequired)
                    {
                        query += " AND " +
                                 _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_Item.IsDraft + "=0";
                    }

                    query += ") as UnionResult " +
                             " INNER JOIN " + _globalAppSettings.DBColumns.DB_Item.DB_TableName + " ON " +
                             _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_Item.Id +
                             "=UnionResult.Id" +
                             " INNER JOIN " + _globalAppSettings.DBColumns.DB_User.DB_TableName + " ON " +
                             _globalAppSettings.DBColumns.DB_User.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_User.Id +
                             "=" + _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_Item.CreatedById +
                             " INNER JOIN " + _globalAppSettings.DBColumns.DB_User.DB_TableName +
                             "  AS User_modified ON " +
                             _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_Item.ModifiedById + "=User_modified." +
                             _globalAppSettings.DBColumns.DB_User.Id +
                             " LEFT JOIN " + _globalAppSettings.DBColumns.DB_FavoriteItem.DB_TableName +
                             "  ON " +
                             _globalAppSettings.DBColumns.DB_FavoriteItem.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_FavoriteItem.ItemId +
                             "=UnionResult.Id AND " +
                             _globalAppSettings.DBColumns.DB_FavoriteItem.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_FavoriteItem.UserId +
                             "=" + userId + " AND " +
                             _globalAppSettings.DBColumns.DB_FavoriteItem.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_FavoriteItem.IsActive +
                             "=1" +
                             " LEFT JOIN (SELECT  UserTable.DisplayName,CategoryItemTable.Name,CategoryItemTable.Id,CategoryItemTable.Description FROM "
                             + _globalAppSettings.DBColumns.DB_Item.DB_TableName +
                             " AS CategoryItemTable INNER JOIN " + _globalAppSettings.DBColumns.DB_User.DB_TableName +
                             " AS UserTable ON UserTable.Id=CategoryItemTable.CreatedById)AS ParentItemTable ON " +
                             _globalAppSettings.DBColumns.DB_Item.DB_TableName + "." +
                             _globalAppSettings.DBColumns.DB_Item.ParentId +
                             "=ParentItemTable.Id";

                    if (isWidgetListRequest)
                    {
                        query += " WHERE UnionResult.Id NOT IN (SELECT " +
                                 _globalAppSettings.DBColumns.DB_DashboardWidget.DB_TableName + "." +
                                 _globalAppSettings.DBColumns.DB_DashboardWidget.WidgetItemId + " FROM " +
                                 _globalAppSettings.DBColumns.DB_DashboardWidget.DB_TableName + ")";
                    }

                    break;
            }

           return query;
        }

    }
}