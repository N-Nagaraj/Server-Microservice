 namespace BoldReports.Server.ORM
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    using BoldReports.Server.Base.DataClasses;

    public class PostgreSqlQueryBuilder : IQueryBuilder
    {
        #region Private Variables

        #endregion 

        public string AddToTable(string tableName, Dictionary<string, object> values)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                tableName = tableName.Trim();
            }

            if (tableName.Contains(" "))
            {
                throw new ArgumentException("Table Name has whitespace");
            }

            var querystring = new StringBuilder();
            querystring.Append("INSERT INTO ");
            querystring.Append(tableName.Replace("'", string.Empty) + " (");
            var columnValues = new StringBuilder();
            var counter = 0;

            if (values == null || values.Count <= 0)
            {
                throw new ArgumentNullException("The Values should not be null");
            }

            foreach (var value in values)
            {
                if (string.IsNullOrWhiteSpace(value.Key))
                {
                    throw new ArgumentNullException("The key field should not be null");
                }
                else
                {
                    if (value.Key.Trim().Contains(" "))
                    {
                        throw new ArgumentException("Column Name has whitespace");
                    }
                }

                querystring.Append(value.Key.Trim());
                columnValues.Append(GetData(value.Value));

                if (counter != values.Keys.Count - 1)
                {
                    querystring.Append(",");
                    columnValues.Append(",");
                }

                counter++;
            }

            querystring.Append(") VALUES (");
            querystring.Append(columnValues);
            querystring.Append(")");
            return querystring.ToString();
        }

        public string AddToTableWithGUID(string tableName, Dictionary<string, object> values, string guidColumn, Guid guid)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                tableName = tableName.Trim();
            }

            if (tableName.Contains(" "))
            {
                throw new ArgumentException("Table Name has whitespace");
            }

            var querystring = new StringBuilder();

            if (guid == null || guid == Guid.Empty)
            {
                querystring.Append("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\"; ");
            }

            querystring.Append("INSERT INTO ");
            querystring.Append(tableName.Replace("'", string.Empty) + " (");
            var columnValues = new StringBuilder();
            var counter = 0;
            if (values == null || values.Count <= 0)
            {
                throw new ArgumentNullException("The Values should not be null");
            }

            foreach (var value in values)
            {
                if (string.IsNullOrWhiteSpace(value.Key))
                {
                    throw new ArgumentNullException("The key field should not be null");
                }
                else
                {
                    if (value.Key.Trim().Contains(" "))
                    {
                        throw new ArgumentException("Column Name has whitespace");
                    }
                }

                querystring.Append(value.Key);

                columnValues.Append(GetData(value.Value));

                if (counter != values.Keys.Count - 1)
                {
                    querystring.Append(",");
                    columnValues.Append(",");
                }

                counter++;
            }

            if (string.IsNullOrWhiteSpace(guidColumn))
            {
                throw new ArgumentNullException("Guid Column Name is null");
            }
            else
            {
                guidColumn = guidColumn.Trim();
            }

            if (guidColumn.Contains(" "))
            {
                throw new ArgumentException("Guid Column Name has whitespace");
            }

            var guidValue = string.Empty;

            if (guid == null || guid == Guid.Empty)
            {
                guidValue = "uuid_generate_v4()";
            }
            else
            {
                guidValue = guid.ToString();
            }

            querystring.Append("," + guidColumn + ") VALUES (" + columnValues + ",'" + guidValue + "')");
            return querystring.ToString();
        }

        public string AddToTable(string tableName, Dictionary<string, object> values, List<string> outputColumns)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                tableName = tableName.Trim();
            }

            if (tableName.Contains(" "))
            {
                throw new ArgumentException("Table Name has whitespace");
            }

            var querystring = new StringBuilder();
            querystring.Append("INSERT INTO ");
            querystring.Append(tableName.Replace("'", string.Empty) + " (");
            var columnValues = new StringBuilder();
            int counter = 0;

            if (values == null || values.Count <= 0)
            {
                throw new ArgumentNullException("The Values should not be null");
            }

            foreach (var value in values)
            {
                if (string.IsNullOrWhiteSpace(value.Key))
                {
                    throw new ArgumentNullException("The key field should not be null");
                }
                else
                {
                    if (value.Key.Trim().Contains(" "))
                    {
                        throw new ArgumentException("Column Name has whitespace");
                    }
                }

                querystring.Append(value.Key);
                columnValues.Append(GetData(value.Value));
                if (counter != values.Keys.Count - 1)
                {
                    querystring.Append(",");
                    columnValues.Append(",");
                }

                counter++;
            }

            querystring.Append(") VALUES (");
            querystring.Append(columnValues);
            querystring.Append(")");

            if (outputColumns != null)
            {
                querystring.Append(" RETURNING ");
                for (int i = 0; i < outputColumns.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(outputColumns[i]))
                    {
                        throw new ArgumentNullException("Column Name is null");
                    }
                    else
                    {
                        outputColumns[i] = outputColumns[i].Trim();
                    }

                    if (outputColumns[i].Contains(" "))
                    {
                        throw new ArgumentException("Column Name has whitespace");
                    }

                    querystring.Append(outputColumns[i]);
                    if (i != outputColumns.Count - 1)
                    {
                        querystring.Append(",");
                    }
                }
            }

            return querystring.ToString();
        }

        public string AddToTableAsBulkForLogs(string tableName, Dictionary<string, object> values,
            string bulkUpdateColumName, List<int> bulkValues)
        {
            if (string.IsNullOrWhiteSpace(bulkUpdateColumName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                if (bulkUpdateColumName.Contains(" "))
                {
                    throw new ArgumentException("Table Name has whitespace");
                }

                bulkUpdateColumName = bulkUpdateColumName.Trim();
            }

            var querystring = new StringBuilder();
            var tempDictionary = new Dictionary<string, object>(values);
            tempDictionary.Add(bulkUpdateColumName, DBNull.Value);
            querystring.Append(AddToTable(tableName, tempDictionary));
            querystring.Append(";");
            if (bulkValues != null)
            {
                for (var queryCount = 0; queryCount < bulkValues.Count; queryCount++)
                {
                    tempDictionary = new Dictionary<string, object>(values);
                    tempDictionary.Add(bulkUpdateColumName, bulkValues[queryCount]);
                    querystring.Append(AddToTable(tableName, tempDictionary));
                    querystring.Append(";");
                }
            }

            return querystring.ToString();
        }

        public string UpdateRowInTable(string tableName, List<UpdateColumn> updateColumns,
            List<ConditionColumn> whereConditionColumns)
        {
            var querystring = new StringBuilder();
            querystring.Append("UPDATE ");
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                if (tableName.Contains(" "))
                {
                    throw new ArgumentException("Table Name has whitespace");
                }

                tableName = tableName.Trim();
            }

            querystring.Append(tableName);
            querystring.Append(" SET ");
            for (var i = 0; i < updateColumns.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(updateColumns[i].ColumnName))
                {
                    throw new ArgumentNullException("The column name should not be null");
                }
                else
                {
                    if (updateColumns[i].ColumnName.Contains(" "))
                    {
                        throw new ArgumentException("Column Name has whitespace");
                    }

                    updateColumns[i].ColumnName = updateColumns[i].ColumnName.Trim();
                }

                if (updateColumns[i].Value != null)
                {
                    if (updateColumns[i].Value.ToString().ToLower() == "true")
                    {
                        updateColumns[i].Value = 1;
                    }
                    else if (updateColumns[i].Value.ToString().ToLower() == "false")
                    {
                        updateColumns[i].Value = 0;
                    }
                }

                querystring.Append(updateColumns[i].ColumnName + "=");
                querystring.Append(GetData(updateColumns[i].Value));
                if (i != updateColumns.Count - 1)
                {
                    querystring.Append(",");
                }
            }

            return ApplyWhereClause(querystring.ToString(), whereConditionColumns);
        }

        public string DeleteRowFromTable(string tableName, List<ConditionColumn> row)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                if (tableName.Contains(" "))
                {
                    throw new ArgumentException("Table Name has whitespace");
                }

                tableName = tableName.Trim();
            }

            var querystring = new StringBuilder();
            querystring.Append("DELETE FROM ");
            querystring.Append(tableName.Replace("'", string.Empty));
            return ApplyWhereClause(querystring.ToString(), row);
        }

        public string DeleteAllRowsFromTable(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                if (tableName.Contains(" "))
                {
                    throw new ArgumentException("Table Name has whitespace");
                }

                tableName = tableName.Trim();
            }

            return "DELETE FROM " + tableName;
        }

        public string SelectAllRecordsFromTable(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                if (tableName.Contains(" "))
                {
                    throw new ArgumentException("Table Name has whitespace");
                }

                tableName = tableName.Trim();
            }

            return "SELECT * FROM " + tableName.Replace("'", string.Empty);
        }

        public string SelectAllRecordsFromTable(string tableName, List<ConditionColumn> whereConditionColumns)
        {
            return ApplyWhereClause(SelectAllRecordsFromTable(tableName), whereConditionColumns);
        }

        public string SelectAllRecordsFromTable(string tableName, List<ConditionColumn> whereConditionColumns,
           List<OrderByColumns> orderByColumns)
        {
            var query = SelectAllRecordsFromTable(tableName);
            if (whereConditionColumns != null && whereConditionColumns.Count > 0)
            {
                query = ApplyWhereClause(query, whereConditionColumns);
            }

            if (orderByColumns != null && orderByColumns.Count > 0)
            {
                query = ApplyOrderBy(query, orderByColumns);
            }

            return query;
        }

        public string SelectRecordsFromTable(string tableName, List<SelectedColumn> columns)
        {
            var querystring = new StringBuilder();
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("Table Name is null");
            }
            else
            {
                if (tableName.Contains(" "))
                {
                    throw new ArgumentException("Table Name has whitespace");
                }

                tableName = tableName.Trim();
            }

            querystring.Append("SELECT ");

            if (columns == null)
            {
                throw new ArgumentNullException("Column name is null");
            }
            else
            {
                for (var i = 0; i < columns.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(columns[i].TableName))
                    {
                        if (columns[i].TableName.Contains(" "))
                        {
                            throw new ArgumentException("Table Name has whitespace");
                        }

                        columns[i].TableName = columns[i].TableName.Trim();
                    }

                    if (string.IsNullOrWhiteSpace(columns[i].ColumnName))
                    {
                        throw new ArgumentNullException("Column Name is null");
                    }

                    if (!string.IsNullOrWhiteSpace(columns[i].ColumnName))
                    {
                        if (columns[i].ColumnName.Contains(" "))
                        {
                            throw new ArgumentException("Column Name has whitespace");
                        }

                        columns[i].ColumnName = columns[i].ColumnName.Trim();
                    }

                    if (!string.IsNullOrWhiteSpace(columns[i].AliasName))
                    {
                        columns[i].AliasName = columns[i].AliasName.Trim();
                        if (columns[i].AliasName.Contains(" "))
                        {
                            throw new ArgumentException("Alias Name has whitespace");
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(columns[i].JoinAliasName))
                    {
                        if (columns[i].JoinAliasName.Contains(" "))
                        {
                            throw new ArgumentException("JoinAliasName has whitespace");
                        }

                        columns[i].JoinAliasName = columns[i].JoinAliasName.Trim();
                    }

                    if (columns[i].IsDistinct)
                    {
                        querystring.Append("DISTINCT ");
                    }

                    if (columns[i].Aggregation != AggregateMethod.None)
                    {
                        var aggregrationType = columns[i].Aggregation == AggregateMethod.VAR
                            ? "VARIANCE" : columns[i].Aggregation.ToString();
                        querystring.Append(aggregrationType + "(" +
                                       ((!string.IsNullOrWhiteSpace(columns[i].TableName))
                                           ? columns[i].TableName + "."
                                           : string.Empty) + columns[i].ColumnName + ")");
                    }
                    else
                    {
                        querystring.Append(
                          ((!string.IsNullOrWhiteSpace(columns[i].JoinAliasName))
                              ? columns[i].JoinAliasName + "."
                              : (!string.IsNullOrWhiteSpace(columns[i].TableName))
                                  ? columns[i].TableName + "."
                                  : string.Empty) + columns[i].ColumnName);
                    }

                    if (!string.IsNullOrWhiteSpace(columns[i].AliasName))
                    {
                        querystring.Append(" AS " + columns[i].AliasName);
                    }

                    if (i != columns.Count - 1)
                    {
                        querystring.Append(",");
                    }
                }
            }

            querystring.Append(" FROM ");
            querystring.Append(tableName);
            return querystring.ToString();
        }

        public string SelectRecordsFromTable(string tableName, List<SelectedColumn> columns,
            List<ConditionColumn> values)
        {
            return ApplyWhereClause(SelectRecordsFromTable(tableName, columns), values);
        }

        public string SelectTopRecordsFromTable(string tableName, List<SelectedColumn> columns, int numberOfRecords)
        {
            var querystring = new StringBuilder();
            querystring.Append(SelectRecordsFromTable(tableName, columns));
            querystring.Append(" LIMIT ");
            querystring.Append(numberOfRecords);
            return querystring.ToString();
        }

        public string SelectTopRecordsFromTable(string tableName, List<SelectedColumn> columnsToSelect,
            int numberOfRecords, List<ConditionColumn> whereConditionColumns,
            List<OrderByColumns> orderByColumns)
        {
            var query = SelectRecordsFromTable(tableName, columnsToSelect);
            if (whereConditionColumns != null && whereConditionColumns.Count > 0)
            {
                query = ApplyWhereClause(query, whereConditionColumns);
            }

            if (orderByColumns != null && orderByColumns.Count > 0)
            {
                query = ApplyOrderBy(query, orderByColumns);
            }

            query += " LIMIT " + numberOfRecords;
            return query;
        }

        public string ApplyOrderBy(string query, List<OrderByColumns> orderByColumns)
        {
            var querystring = new StringBuilder();
            if (!string.IsNullOrEmpty(query))
            {
                querystring.Append(query);
                if (orderByColumns != null && orderByColumns.Count > 0)
                {
                    querystring.Append(" ORDER BY ");
                    for (var i = 0; i < orderByColumns.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(orderByColumns[i].ColumnName))
                        {
                            throw new ArgumentNullException("The column name should not be null");
                        }
                        else
                        {
                            if (orderByColumns[i].ColumnName.Contains(" "))
                            {
                                throw new ArgumentException("Column Name has whitespace");
                            }

                            orderByColumns[i].ColumnName = orderByColumns[i].ColumnName.Trim();
                        }

                        if (!string.IsNullOrWhiteSpace(orderByColumns[i].TableName))
                        {
                            if (orderByColumns[i].TableName.Contains(" "))
                            {
                                throw new ArgumentException("Table Name has whitespace");
                            }

                            orderByColumns[i].TableName = orderByColumns[i].TableName.Trim();
                        }

                        querystring.Append(((!string.IsNullOrWhiteSpace(orderByColumns[i].TableName))
                            ? orderByColumns[i].TableName + "."
                            : string.Empty) + orderByColumns[i].ColumnName);

                        if (orderByColumns[i].OrderBy != OrderByType.None)
                        {
                            querystring.Append(" " + orderByColumns[i].OrderBy);
                        }

                        if (i != orderByColumns.Count - 1)
                        {
                            querystring.Append(",");
                        }
                    }
                }
            }

            return querystring.ToString();
        }

        public string ApplyWhereClause(string query, List<ConditionColumn> whereColumns)
        {
            var outGuidId = new Guid();
            int outId;
            var querystring = new StringBuilder();
            if (!string.IsNullOrEmpty(query))
            {
                querystring.Append(query);
                if (whereColumns != null && whereColumns.Count > 0)
                {
                    querystring.Append(" WHERE ");
                    for (var i = 0; i < whereColumns.Count; i++)
                    {
                        if (string.IsNullOrWhiteSpace(whereColumns[i].ColumnName))
                        {
                            throw new ArgumentNullException("ColumnName should not be empty");
                        }

                        if (whereColumns[i].ColumnName.Contains(" "))
                        {
                            throw new ArgumentException("ColumnName has whitespace");
                        }

                        whereColumns[i].ColumnName = whereColumns[i].ColumnName.Trim();
                        if (whereColumns[i].Condition == Condition.None)
                        {
                            throw new ArgumentException("Condition should not be none");
                        }

                        if (i != 0)
                        {
                            if (whereColumns[i].LogicalOperator == LogicalOperator.None)
                            {
                                throw new ArgumentException("LogicalOperator should not be none for multiple conditions");
                            }

                            querystring.Append(" " + whereColumns[i].LogicalOperator + " ");
                        }

                        if (!string.IsNullOrWhiteSpace(whereColumns[i].TableName))
                        {
                            if (whereColumns[i].TableName.Contains(" "))
                            {
                                throw new ArgumentException("Table Name has whitespace");
                            }

                            whereColumns[i].TableName = whereColumns[i].TableName.Trim();
                        }

                        if (whereColumns[i].Value != null)
                        {
                            if (whereColumns[i].Value.ToString().ToLower() == "true")
                            {
                                whereColumns[i].Value = 1;
                            }
                            else if (whereColumns[i].Value.ToString().ToLower() == "false")
                            {
                                whereColumns[i].Value = 0;
                            }
                        }

                        if (whereColumns[i].Condition == Condition.IN || whereColumns[i].Condition == Condition.NOTIN)
                        {
                            if (whereColumns[i].Values == null || whereColumns[i].Values.Count == 0)
                            {
                                throw new ArgumentException("Values could not be null or empty");
                            }

                            int parsedOutput;
                            if (int.TryParse(whereColumns[i].Values[0], out parsedOutput) || string.IsNullOrWhiteSpace(whereColumns[i].Values[0]) || Guid.TryParse(whereColumns[i].Values[0]?.ToString(), out outGuidId))
                            { 
                                querystring.Append(((!string.IsNullOrWhiteSpace(whereColumns[i].TableName))
                                    ? whereColumns[i].TableName + "."
                                    : string.Empty) + whereColumns[i].ColumnName);
                            }
                            else
                            {
                                querystring.Append(" LOWER(");
                                querystring.Append(((!string.IsNullOrWhiteSpace(whereColumns[i].TableName))
                                    ? whereColumns[i].TableName + "."
                                    : string.Empty) + whereColumns[i].ColumnName);
                                querystring.Append(")");
                            }

                            querystring.Append(GetConditionOperator(whereColumns[i].Condition));
                            querystring.Append("(");

                            for (var j = 0; j < whereColumns[i].Values.Count; j++)
                            {
                                if (j != 0)
                                {
                                    querystring.Append(",");
                                }

                                querystring.Append(GetData(whereColumns[i].Values[j], true));
                            }

                            querystring.Append(")");
                        }
                        else
                        {
                            if (whereColumns[i].OpenParenthesis)
                            {
                                querystring.Append("(");
                            }

                            if (IsNumber(whereColumns[i].Value) || (whereColumns[i].Value == DBNull.Value) || whereColumns[i].Value == null || whereColumns[i].Value is DateTime || whereColumns[i].Value is bool || Guid.TryParse(whereColumns[i].Value?.ToString(), out outGuidId) || int.TryParse(whereColumns[i].Value?.ToString(), out outId))
                            {
                                querystring.Append(((!string.IsNullOrWhiteSpace(whereColumns[i].TableName))
                                ? whereColumns[i].TableName + "."
                                : string.Empty) + whereColumns[i].ColumnName);
                            }
                            else
                            {
                                querystring.Append(" lower(");
                                querystring.Append(((!string.IsNullOrWhiteSpace(whereColumns[i].TableName))
                                    ? whereColumns[i].TableName + "."
                                    : string.Empty) + whereColumns[i].ColumnName);
                                querystring.Append(")");
                            }
                            
                            querystring.Append(GetConditionOperator(whereColumns[i].Condition));
                            if (whereColumns[i].Condition == Condition.LIKE)
                            {
                                querystring.Append(whereColumns[i].Value == DBNull.Value
                                      ? "Null"
                                      : (IsNumber(whereColumns[i].Value)
                                          ? whereColumns[i].Value
                                          : (whereColumns[i].Value == null) ? "%%" : "'%" + whereColumns[i].Value.ToString().ToLower() + "%'"));
                            }
                            else if (whereColumns[i].Condition == Condition.IS)
                            {
                                querystring.Append("NULL");
                            }
                            else
                            {
                                querystring.Append(GetData(whereColumns[i].Value, true));
                            }
                            if (whereColumns[i].ClosedParenthesis)
                            {
                                querystring.Append(")");
                            }
                        }
                    }
                }
            }

            return querystring.ToString();
        }

        /// <summary>
        ///   Gives the count of records
        /// </summary>
        /// <param name="query">Input query</param>
        /// <returns>Query string</returns>
        public string GetRecordsCount(string query)
        {
            var queryString = new StringBuilder();
            queryString.Append("SELECT COUNT(*) AS TotalRecords FROM (" + query + ") AS GETRECORD");
            return queryString.ToString();
        }

        public string GetDistinctRecordsCountFromTable(string column, string tableName)
        {
            var queryString = new StringBuilder();
            queryString.Append("SELECT COUNT(DISTINCT " + column + ") AS TotalRecords FROM " + tableName);
            return queryString.ToString();
        }

        #region Joins

        public string ApplyJoins(string query, JoinSpecification joinSpecification)
        {
            var querystring = new StringBuilder();
            if (joinSpecification == null)
            {
                return query;
            }

            if (joinSpecification.Table == null && joinSpecification.Column == null)
            {
                return query;
            }

            if (!string.IsNullOrWhiteSpace(query))
            {
                querystring.Append(query);
                querystring.Append(" " + joinSpecification.JoinType + " JOIN ");

                if (string.IsNullOrWhiteSpace(joinSpecification.Table))
                {
                    throw new ArgumentNullException("Table Name is null");
                }
                else
                {
                    if (joinSpecification.Table.Contains(" "))
                    {
                        throw new ArgumentException("Table Name has whitespace");
                    }

                    joinSpecification.Table = joinSpecification.Table.Trim();
                }

                querystring.Append(joinSpecification.Table);
                if (!string.IsNullOrWhiteSpace(joinSpecification.JoinTableAliasName))
                {
                    if (joinSpecification.JoinTableAliasName.Contains(" "))
                    {
                        throw new ArgumentException("Alias Name has whitespace");
                    }

                    joinSpecification.JoinTableAliasName = joinSpecification.JoinTableAliasName.Trim();
                }

                if (!string.IsNullOrWhiteSpace(joinSpecification.JoinTableAliasName))
                {
                    querystring.Append(" AS " + joinSpecification.JoinTableAliasName);
                }

                querystring.Append(" ON ");
                querystring.Append("(");
                for (var j = 0; j < joinSpecification.Column.Count; j++)
                {
                    var parentTable =
                        query.Substring((query.LastIndexOf("FROM") != -1)
                            ? query.LastIndexOf("FROM") + 5
                            : query.LastIndexOf("from") + 5);

                    if (joinSpecification.Column[j].LogicalOperator != LogicalOperator.None && j != 0)
                    {
                        querystring.Append(" " + joinSpecification.Column[j].LogicalOperator);
                    }

                    if (string.IsNullOrWhiteSpace(joinSpecification.Column[j].ParentTableColumn))
                    {
                        throw new ArgumentNullException("Table Name is null");
                    }
                    else
                    {
                        if (joinSpecification.Column[j].ParentTableColumn.Contains(" "))
                        {
                            throw new ArgumentException("Table Name has whitespace");
                        }

                        joinSpecification.Column[j].ParentTableColumn =
                            joinSpecification.Column[j].ParentTableColumn.Trim();
                    }

                    querystring.Append(parentTable + "." + joinSpecification.Column[j].ParentTableColumn + GetConditionOperator(joinSpecification.Column[j].Operation));

                    if (string.IsNullOrWhiteSpace(joinSpecification.JoinTableAliasName))
                    {
                        if (string.IsNullOrWhiteSpace(joinSpecification.Column[j].TableName))
                        {
                            throw new ArgumentNullException("Join Table Name is null");
                        }
                        else
                        {
                            if (joinSpecification.Column[j].TableName.Contains(" "))
                            {
                                throw new ArgumentException("Join Table Name has whitespace");
                            }

                            joinSpecification.Column[j].TableName =
                                joinSpecification.Column[j].TableName.Trim();
                        }
                    }

                    querystring.Append((joinSpecification.Column[j].ConditionValue != null)
                        ? GetData(joinSpecification.Column[j].ConditionValue)
                        : (!string.IsNullOrWhiteSpace(joinSpecification.JoinTableAliasName))
                            ? joinSpecification.JoinTableAliasName
                            : joinSpecification.Column[j].TableName);
                    if (joinSpecification.Column[j].ConditionValue == null)
                    {
                        if (string.IsNullOrWhiteSpace(joinSpecification.Column[j].JoinedColumn))
                        {
                            throw new ArgumentNullException("Join Column Name is null");
                        }
                        else
                        {
                            if (joinSpecification.Column[j].JoinedColumn.Contains(" "))
                            {
                                throw new ArgumentException("Join Column Name has whitespace");
                            }

                            joinSpecification.Column[j].JoinedColumn =
                                joinSpecification.Column[j].JoinedColumn.Trim();
                        }
                    }

                    querystring.Append((joinSpecification.Column[j].ConditionValue == null)
                        ? "." + joinSpecification.Column[j].JoinedColumn
                        : string.Empty);
                }

                querystring.Append(")");
            }

            return querystring.ToString();
        }

        public string ApplyMultipleJoins(string query, List<JoinSpecification> joinSpecification)
        {
            var querystring = new StringBuilder();
            querystring.Append(query);
            if (joinSpecification == null)
            {
                return query;
            }

            for (var t = 0; t < joinSpecification.Count; t++)
            {
                if (joinSpecification[t].Table == null && joinSpecification[t].Column == null)
                {
                    return query;
                }

                if (!string.IsNullOrWhiteSpace(query))
                {
                    querystring.Append(" " + joinSpecification[t].JoinType + " JOIN ");

                    if (string.IsNullOrWhiteSpace(joinSpecification[t].Table))
                    {
                        throw new ArgumentNullException("Table Name is null");
                    }
                    else
                    {
                        if (joinSpecification[t].Table.Contains(" "))
                        {
                            throw new ArgumentException("Table Name has whitespace");
                        }

                        joinSpecification[t].Table = joinSpecification[t].Table.Trim();
                    }

                    querystring.Append(joinSpecification[t].Table);
                    if (!string.IsNullOrWhiteSpace(joinSpecification[t].JoinTableAliasName))
                    {
                        if (joinSpecification[t].JoinTableAliasName.Contains(" "))
                        {
                            throw new ArgumentException("Alias Name has whitespace");
                        }

                        joinSpecification[t].JoinTableAliasName = joinSpecification[t].JoinTableAliasName.Trim();
                    }

                    if (!string.IsNullOrWhiteSpace(joinSpecification[t].JoinTableAliasName))
                    {
                        querystring.Append(" AS " + joinSpecification[t].JoinTableAliasName);
                    }

                    querystring.Append(" ON ");
                    querystring.Append("(");
                    for (var j = 0; j < joinSpecification[t].Column.Count; j++)
                    {
                        if (joinSpecification[t].Column[j].LogicalOperator != LogicalOperator.None && j != 0)
                        {
                            querystring.Append(" " + joinSpecification[t].Column[j].LogicalOperator + " ");
                        }

                        if (string.IsNullOrWhiteSpace(joinSpecification[t].Column[j].ParentTable))
                        {
                            throw new ArgumentNullException("Table Name is null");
                        }
                        else
                        {
                            if (joinSpecification[t].Column[j].ParentTable.Contains(" "))
                            {
                                throw new ArgumentException("Table Name has whitespace");
                            }

                            joinSpecification[t].Column[j].ParentTable =
                                joinSpecification[t].Column[j].ParentTable.Trim();
                        }

                        if (string.IsNullOrWhiteSpace(joinSpecification[t].Column[j].ParentTableColumn))
                        {
                            throw new ArgumentNullException("Table Name is null");
                        }
                        else
                        {
                            if (joinSpecification[t].Column[j].ParentTableColumn.Contains(" "))
                            {
                                throw new ArgumentException("Table Name has whitespace");
                            }

                            joinSpecification[t].Column[j].ParentTableColumn =
                                joinSpecification[t].Column[j].ParentTableColumn.Trim();
                        }

                        querystring.Append(joinSpecification[t].Column[j].ParentTable + "." + joinSpecification[t].Column[j].ParentTableColumn + GetConditionOperator(joinSpecification[t].Column[j].Operation));

                        if (!string.IsNullOrWhiteSpace(joinSpecification[t].JoinTableAliasName))
                        {
                            joinSpecification[t].JoinTableAliasName = joinSpecification[t].JoinTableAliasName.Trim();
                            
                            if (joinSpecification[t].JoinTableAliasName.Contains(" "))
                            {
                                throw new ArgumentException("Alias Name has whitespace");
                            }
                        }

                        querystring.Append((joinSpecification[t].Column[j].ConditionValue != null)
                            ? IsNumber(joinSpecification[t].Column[j].ConditionValue)
                                ? joinSpecification[t].Column[j].ConditionValue
                                : GetData(joinSpecification[t].Column[j].ConditionValue)
                            : (!string.IsNullOrWhiteSpace(joinSpecification[t].JoinTableAliasName))
                                ? joinSpecification[t].JoinTableAliasName
                                : joinSpecification[t].Column[j].TableName);
                        if (joinSpecification[t].Column[j].ConditionValue == null)
                        {
                            if (string.IsNullOrWhiteSpace(joinSpecification[t].Column[j].JoinedColumn))
                            {
                                throw new ArgumentNullException("Join Column Name is null");
                            }
                            else
                            {
                                if (joinSpecification[t].Column[j].JoinedColumn.Contains(" "))
                                {
                                    throw new ArgumentException("Join Column Name has whitespace");
                                }

                                joinSpecification[t].Column[j].JoinedColumn =
                                    joinSpecification[t].Column[j].JoinedColumn.Trim();
                            }
                        }

                        querystring.Append((joinSpecification[t].Column[j].ConditionValue == null)
                            ? "." + joinSpecification[t].Column[j].JoinedColumn
                            : string.Empty);
                    }

                    querystring.Append(")");
                }
            }

            return querystring.ToString();
        }

        public string ApplyMultipleJoins(string tableName, List<SelectedColumn> columnsToSelect,
            List<JoinSpecification> joinSpecification)
        {
            var query = SelectRecordsFromTable(tableName, columnsToSelect);
            return ApplyMultipleJoins(query, joinSpecification);
        }

        public string ApplyJoins(string tableName, List<SelectedColumn> columnsToSelect,
            JoinSpecification joinSpecification)
        {
            var query = SelectRecordsFromTable(tableName, columnsToSelect);
            return ApplyJoins(query, joinSpecification);
        }

        #endregion

        //public string ApplyPagination(string query, OrderByColumns orderByColumn, int skip = Pagination.DefaultSkip, int take = Pagination.DefaultPageSize)
        //{
        //    var queryString = new StringBuilder();
        //    queryString.Append(query);
        //    if (query.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase) == -1)
        //    {
        //        queryString.Append(" ORDER BY " + orderByColumn.ColumnName + " " + orderByColumn.OrderBy);
        //    }

        //    queryString.Append(" LIMIT " + take + " OFFSET " + skip);
        //    return queryString.ToString();
        //}

        public string ExcludeMultiTabDashboard(string query, string tableName)
        {
            string orderByClause, removalQuery = string.Empty;
            var queryString = new StringBuilder();
            Regex regex = new Regex(@"(order\s+by)\s+[A-Za-z0-9\[\]\.\\_]+\s+(desc|asc)?", RegexOptions.IgnoreCase);
            Match match = regex.Match(query);
            if (match.Success)
            {
                removalQuery = " AND (Id NOT IN (SELECT " + tableName + ".ParentDashboardId FROM " + tableName + " ))";
                query = query.Replace(match.Value, string.Empty);
                orderByClause = match.Value;
                queryString.Append(query + removalQuery);
                queryString.Append(" " + orderByClause);
            }
            else
            {
                queryString.Append(query + removalQuery);
            }

            return queryString.ToString();
        }

        public string GetDistinctRecordsCount(string query, string columName)
        {
            var queryString = new StringBuilder();
            queryString.Append("SELECT COUNT(DISTINCT " + columName + ") AS TotalRecords FROM (" + query);
            if (query.IndexOf("ORDER BY", StringComparison.OrdinalIgnoreCase) != -1)
            {
                queryString.Append(" OFFSET 0 ROWS");
            }

            queryString.Append(") AS GETRECORD");
            return queryString.ToString();
        }

        #region Private Methods

        /// <summary>
        ///     Returns mathematical operator for the given condition
        /// </summary>
        /// <param name="condition">Conditions Enum</param>
        /// <returns>Mathematical operator as string</returns>
        private static string GetConditionOperator(Condition condition)
        {
            switch (condition)
            {
                case Condition.Equals:
                    return "=";

                case Condition.GreaterThan:
                    return ">";

                case Condition.GreaterThanOrEquals:
                    return ">=";

                case Condition.LessThan:
                    return "<";

                case Condition.LessThanOrEquals:
                    return "<=";

                case Condition.NotEquals:
                    return "!=";

                case Condition.IS:
                    return " IS ";

                case Condition.IN:
                    return " IN ";

                case Condition.LIKE:
                    return " ILIKE ";

                case Condition.NOTIN:
                    return " NOT IN ";

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        ///     Checks if the value is a number type
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>True if the object is a number type</returns>
        private static bool IsNumber(object value)
        {
            if (value == null)
            {
                return false;
            }

            return value is double ||
                value is int ||
                value is short ||
                value is long ||
                value is decimal;
        }

        private static object GetData(object value, bool isLower = false)
        {
            object data;

            if (IsNumber(value))
            {
                if (value is double)
                {
                    data = double.Parse(value.ToString(), CultureInfo.InvariantCulture);
                }
                else if (value is float)
                {
                    data = float.Parse(value.ToString(), CultureInfo.InvariantCulture);
                }
                else
                {
                    data = value;
                }
            }
            else if (value == DBNull.Value)
            {
                data = "NULL";
            }
            else if (value == null)
            {
                data = "''";
            }
            else if (value is DateTime)
            {
                data = "TO_TIMESTAMP('" + ((DateTime)value).ToString("yyyyMMdd hh:mm:ss tt", CultureInfo.InvariantCulture) + "', 'yyyymmdd hh:mi:ss pm')";
            }
            else if (value is bool)
            {
                data = Convert.ToBoolean(value) ? "'1'" : "'0'";
            }
            else
            {
                string encodedValue = string.Empty;
                encodedValue = value.ToString().Replace("<", "&lt;");
                if (isLower)
                {
                    data = "$cmwqv$" + encodedValue.ToString().ToLower() + "$cmwqv$";
                }
                else
                {
                    data = "$cmwqv$" + encodedValue + "$cmwqv$";
                }
            }

            return data;
        }

        #endregion Private Methods
    }
}