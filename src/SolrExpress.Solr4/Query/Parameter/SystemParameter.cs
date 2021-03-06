﻿using SolrExpress.Core.Query.Parameter;
using System.Collections.Generic;

namespace SolrExpress.Solr4.Query.Parameter
{
    /// <summary>
    /// Internal use
    /// </summary>
    internal class SystemParameter : ISystemParameter, IParameter<List<string>>
    {
        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get; } = false;

        /// <summary>
        /// Configure current instance
        /// </summary>
        public ISystemParameter Configure()
        {
            return this;
        }

        /// <summary>
        /// Execute the creation of the parameter
        /// </summary>
        /// <param name="container">Container to parameters to request to SOLR</param>
        public void Execute(List<string> container)
        {
            var parameters = new[] {
                "echoParams=none",
                "wt=json",
                "indent=off",
                "defType=edismax",
                "fl=*,score",
                "q.alt=*:*",
                "sort=score asc",
                "df=id",
                "q=*:*"
            };

            foreach (var parameter in parameters)
            {
                if (!container.Contains(parameter))
                {
                    container.Add(parameter);
                }
            }
        }
    }
}
