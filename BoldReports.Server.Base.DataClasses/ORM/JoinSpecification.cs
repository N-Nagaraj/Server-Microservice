﻿namespace BoldReports.Server.Base.DataClasses
{
    using System.Collections.Generic;

    /// <summary>
    ///     Model class for Join specification
    /// </summary>
    public class JoinSpecification
    {
        /// <summary>
        ///     Gets or sets the Mapping columns for join
        /// </summary>
        public List<JoinColumn> Column
        {
            get;
            set;
        }

        public string JoinTableAliasName
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets the Join Type
        /// </summary>
        public JoinType JoinType
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets the joined tables collection
        /// </summary>
        public string Table
        {
            get;
            set;
        }
    }
}