﻿using Newtonsoft.Json.Linq;
using SolrExpress.Core;
using SolrExpress.Core.Extension.Internal;
using SolrExpress.Core.Query;
using SolrExpress.Core.Query.Parameter;
using SolrExpress.Solr5.Extension.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SolrExpress.Solr5.Query.Parameter
{
    public sealed class FacetRangeParameter<TDocument> : IFacetRangeParameter<TDocument>, IParameter<JObject>, IValidation
      where TDocument : IDocument
    {
        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get; } = true;

        /// <summary>
        /// Name of the alias added in the query
        /// </summary>
        public string AliasName { get; private set; }

        /// <summary>
        /// Expression used to find the property name
        /// </summary>
        public Expression<Func<TDocument, object>> Expression { get; private set; }

        /// <summary>
        /// Size of each range bucket to make the facet
        /// </summary>
        public string Gap { get; private set; }

        /// <summary>
        /// Lower bound to make the facet
        /// </summary>
        public string Start { get; private set; }

        /// <summary>
        /// Upper bound to make the facet
        /// </summary>
        public string End { get; private set; }

        /// <summary>
        /// Sort type of the result of the facet
        /// </summary>
        public FacetSortType? SortType { get; private set; }

        /// <summary>
        /// List of tags to exclude in facet calculation
        /// </summary>
        public string[] Excludes { get; private set; }

        /// <summary>
        /// Execute the creation of the parameter "sort"
        /// </summary>
        /// <param name="jObject">JSON object with parameters to request to SOLR</param>
        public void Execute(JObject jObject)
        {
            var facetObject = (JObject)jObject["facet"] ?? new JObject();

            var fieldName = this.Expression.GetFieldNameFromExpression();

            var array = new List<JProperty>
            {
                new JProperty("field", this.Excludes.GetSolrFacetWithExcludes(fieldName))
            };

            array.Add(new JProperty("mincount", 1));

            if (!string.IsNullOrWhiteSpace(this.Gap))
            {
                array.Add(new JProperty("gap", this.Gap));
            }
            if (!string.IsNullOrWhiteSpace(this.Start))
            {
                array.Add(new JProperty("start", this.Start));
            }
            if (!string.IsNullOrWhiteSpace(this.End))
            {
                array.Add(new JProperty("end", this.End));
            }

            array.Add(new JProperty("other", new JArray("before", "after")));

            if (this.SortType.HasValue)
            {
                string typeName;
                string sortName;

                this.SortType.Value.GetSolrFacetSort(out typeName, out sortName);

                array.Add(new JProperty("sort", new JObject(new JProperty(typeName, sortName))));
            }

            var value = new JProperty(this.AliasName, new JObject(new JProperty("range", new JObject(array.ToArray()))));

            facetObject.Add(value);

            jObject["facet"] = facetObject;
        }

        /// <summary>
        /// Check for the parameter validation
        /// </summary>
        /// <param name="isValid">True if is valid, otherwise false</param>
        /// <param name="errorMessage">The error message, if applicable</param>
        public void Validate(out bool isValid, out string errorMessage)
        {
            isValid = true;
            errorMessage = string.Empty;

            var solrFieldAttribute = this.Expression.GetSolrFieldAttributeFromPropertyInfo();

            if ((!solrFieldAttribute?.Indexed) ?? false)
            {
                isValid = false;
                errorMessage = Resource.FieldMustBeIndexedTrueToBeUsedInAFacetException;
            }
            else
            {
                var propertyType = this.Expression.GetPropertyTypeFromExpression();

                switch (propertyType.ToString())
                {
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Single":
                    case "System.Double":
                    case "System.Decimal":
                    case "System.DateTime":
                        break;
                    default:
                        isValid = false;
                        errorMessage = Resource.FieldMustBeNumericOrDateTimeToBeUsedInFacetRangeException;
                        break;
                }
            }
        }

        /// <summary>
        /// Configure current instance
        /// </summary>
        /// <param name="aliasName">Name of the alias added in the query</param>
        /// <param name="expression">Expression used to find the property name</param>
        /// <param name="gap">Size of each range bucket to make the facet</param>
        /// <param name="start">Lower bound to make the facet</param>
        /// <param name="end">Upper bound to make the facet</param>
        /// <param name="sortType">Sort type of the result of the facet</param>
        /// <param name="excludes">List of tags to exclude in facet calculation</param>
        public IFacetRangeParameter<TDocument> Configure(string aliasName, Expression<Func<TDocument, object>> expression, string gap, string start, string end, FacetSortType? sortType = null, params string[] excludes)
        {
            Checker.IsNullOrWhiteSpace(aliasName);
            Checker.IsNull(expression);
            Checker.IsNullOrWhiteSpace(gap);
            Checker.IsNullOrWhiteSpace(start);
            Checker.IsNullOrWhiteSpace(end);

            this.AliasName = aliasName;
            this.Expression = expression;
            this.Gap = gap;
            this.Start = start;
            this.End = end;
            this.SortType = sortType;
            this.Excludes = excludes;

            return this;
        }
    }
}
