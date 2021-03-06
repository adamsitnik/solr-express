﻿using Newtonsoft.Json.Linq;
using SolrExpress.Core.Query.Parameter;
using SolrExpress.Solr5.Query.Parameter.Internal;

namespace SolrExpress.Solr5.Query.Parameter
{
    public class RandomSortParameter : IRandomSortParameter, IParameter<JObject>
    {
        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get; } = true;

        /// <summary>
        /// True to ascendent order, otherwise false
        /// </summary>
        public bool Ascendent { get; private set; }

        /// <summary>
        /// Execute creation of parameter "sort"
        /// </summary>
        /// <param name="jObject">JSON object with parameters to request to SOLR</param>
        public void Execute(JObject jObject)
        {
            var command = new SortCommand();
            command.Execute("random", this.Ascendent, jObject);
        }

        /// <summary>
        /// Configure current instance
        /// </summary>
        /// <param name="ascendent">True to ascendent order, otherwise false</param>
        public IRandomSortParameter Configure(bool ascendent)
        {
            this.Ascendent = ascendent;

            return this;
        }
    }
}
