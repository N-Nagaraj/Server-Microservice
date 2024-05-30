namespace BoldReports.Server.ORM
{
    using System;
    using System.Collections.Generic;

    using BoldReports.Server.Base.DataClasses;
    /// <summary>
    ///     Interface for query builder
    /// </summary>
    public interface IQueryBuilder
    {
        /// <summary>
        ///     Adds a row in to the table
        /// </summary>
        /// <param name="tableName">Table</param>
        /// <param name="values">Values</param>
        /// <returns>Query string</returns>
        string AddToTable(string tableName, Dictionary<string, object> values);

        /// <summary>
        ///     Adds a row to the table and returns newly created row
        /// </summary>
        /// <param name="tableName">Table</param>
        /// <param name="values">Values</param>
        /// <param name="outputColumns">List of column to return</param>
        /// <returns>Query String</returns>
        string AddToTable(string tableName, Dictionary<string, object> values, List<string> outputColumns);

        string AddToTableAsBulkForLogs(
            string tableName,
            Dictionary<string, object> values,
            string bulkUpdateColumName,
            List<int> bulkValues);

        /// <summary>
        /// Adds a row in to the table
        /// </summary>
        /// <param name="tableName">Table</param>
        /// <param name="values">Values</param>
        /// <param name="guidColumn">Guid Column</param>
        /// <param name="guid">Guid</param>
        /// <returns>Query string</returns>
        string AddToTableWithGUID(string tableName, Dictionary<string, object> values, string guidColumn, Guid guid);

        /// <summary>
        ///     Joins two or more tables
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <param name="joinSpecification">Join specification object</param>
        /// <returns>Query string</returns>
        string ApplyJoins(string query, JoinSpecification joinSpecification);

        /// <summary>
        ///     Joins two or more tables
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="columnsToSelect">List of columns to select</param>
        /// <param name="joinSpecification">Join specification object</param>
        /// <returns>Query string</returns>
        string ApplyJoins(string tableName, List<SelectedColumn> columnsToSelect, JoinSpecification joinSpecification);

        /// <summary>
        ///     Joins Multiple tables
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <param name="joinSpecification">Join specification object</param>
        /// <returns>Query string</returns>
        string ApplyMultipleJoins(string query, List<JoinSpecification> joinSpecification);

        /// <summary>
        ///     Joins Multiple tables
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="columnsToSelect">List of columns to select</param>
        /// <param name="joinSpecification">Join specification object</param>
        /// <returns>Query string</returns>
        string ApplyMultipleJoins(string tableName, List<SelectedColumn> columnsToSelect, List<JoinSpecification> joinSpecification);

        /// <summary>
        ///     Applies Order by clause to the query string
        /// </summary>
        /// <param name="query">Query to append order by clause</param>
        /// <param name="orderByColumns">Order By Columns</param>
        /// <returns>Query string</returns>
        string ApplyOrderBy(string query, List<OrderByColumns> orderByColumns);

        /// <summary>
        ///     Appends where clause to the query string
        /// </summary>
        /// <param name="query">Query string to append where clause</param>
        /// <param name="whereConditionColumns">Where condition columns</param>
        /// <returns>Query string</returns>
        string ApplyWhereClause(string query, List<ConditionColumn> whereConditionColumns);

        /// <summary>
        ///     Deletes all rows from the table
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <returns>Query string</returns>
        string DeleteAllRowsFromTable(string tableName);

        /// <summary>
        ///     Selects all the records from the table
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <returns>Query string</returns>
        string SelectAllRecordsFromTable(string tableName);

        /// <summary>
        ///     Selects all columns from table based on where clause condition
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="whereConditionColumns">Columns to apply where clause</param>
        /// <returns>Query string</returns>
        string SelectAllRecordsFromTable(string tableName, List<ConditionColumn> whereConditionColumns);

        /// <summary>
        ///     Selects all records from table
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <param name="whereConditionColumns">Columns to apply where clause</param>
        /// <param name="orderByColumns">Columns to order the table</param>
        /// <returns>Returns the query</returns>
        string SelectAllRecordsFromTable(
            string tableName,
            List<ConditionColumn> whereConditionColumns,
            List<OrderByColumns> orderByColumns);

        /// <summary>
        ///     Selects the list of columns from the table
        /// </summary>
        /// <param name="tableName">Name if the table</param>
        /// <param name="columns">List of columns to select</param>
        /// <returns>Query string</returns>
        string SelectRecordsFromTable(string tableName, List<SelectedColumn> columns);

        /// <summary>
        ///     Select specified columns based on where condition
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="columns">Columns to select</param>
        /// <param name="values">Values</param>
        /// <returns> Query string</returns>
        string SelectRecordsFromTable(string tableName, List<SelectedColumn> columns, List<ConditionColumn> values);

        /// <summary>
        ///     Selects top records from the table
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="columns">List of columns to select from the table</param>
        /// <param name="numberOfRecords">Number of top records to fetch</param>
        /// <returns>Query string</returns>
        string SelectTopRecordsFromTable(string tableName, List<SelectedColumn> columns, int numberOfRecords);

        /// <summary>
        ///     Selects Top columns from the table
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <param name="columnsToSelect">List of column to select from the table</param>
        /// <param name="numberOfRecords">Number of top rows to select</param>
        /// <param name="whereConditionColumns">Columns to apply where clause</param>
        /// <param name="orderByColumns">Columns to order the table</param>
        /// <returns>Returns the query</returns>
        string SelectTopRecordsFromTable(
            string tableName,
            List<SelectedColumn> columnsToSelect,
            int numberOfRecords,
            List<ConditionColumn> whereConditionColumns, 
            List<OrderByColumns> orderByColumns);

        /// <summary>
        ///     Updates the row in table
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="updateColumns">List of columns to update</param>
        /// <param name="whereConditionColumns">List of conditions to apply in where clause</param>
        /// <returns>Query string</returns>
        string UpdateRowInTable(
            string tableName,
            List<UpdateColumn> updateColumns,
            List<ConditionColumn> whereConditionColumns);

        // These methods are not used now. This can be added if necessary
        /*
         /// <summary>
        ///     Deletes rows from table
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="row">List of rows to delete</param>
        /// <returns>Query string</returns>
        string DeleteRowFromTable(string tableName, List<ConditionColumn> row);

         */

        string GetRecordsCount(string query);

        string GetDistinctRecordsCountFromTable(string column, string tableName);

        //string ApplyPagination(string query, OrderByColumns orderByColumn, int skip = Pagination.DefaultSkip, int take = Pagination.DefaultPageSize);

        string GetDistinctRecordsCount(string query, string columName);

        //string ApplyPermission(string query, PermissionAccess scope);

        string ExcludeMultiTabDashboard(string query, string tableName);
    }
}