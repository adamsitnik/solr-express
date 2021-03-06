﻿using SolrExpress.Core;
using SolrExpress.Core.Query.Parameter;
using System.Collections.Generic;

namespace SolrExpress.Solr4.Query.Parameter
{
    public sealed class MinimumShouldMatchParameter : IMinimumShouldMatchParameter, IParameter<List<string>>
    {
        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get; } = false;

        /// <summary>
        /// Expression used to make the mm parameter
        /// </summary>
        public string Expression { get; private set; }

        /// <summary>
        /// Execute the creation of the parameter "query field"
        /// </summary>
        /// <param name="container">Container to parameters to request to SOLR</param>
        public void Execute(List<string> container)
        {
            container.Add($"mm={this.Expression}");
        }

        /// <summary>
        /// Configure current instance
        /// </summary>
        /// <param name="expression">Expression used to make the mm parameter</param>
        public IMinimumShouldMatchParameter Configure(string expression)
        {
            Checker.IsNullOrWhiteSpace(expression);

            this.Expression = expression;

            return this;
        }
    }
}
