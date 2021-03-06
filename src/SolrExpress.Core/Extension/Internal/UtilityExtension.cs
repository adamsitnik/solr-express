﻿using SolrExpress.Core.Query.Parameter;
using SolrExpress.Core.Query.ParameterValue;
using System;
using System.Globalization;

namespace SolrExpress.Core.Extension.Internal
{
    /// <summary>
    /// Extension class used in generic methods
    /// </summary>
    internal static class UtilityExtension
    {
        /// <summary>
        /// Get the sort type and direction
        /// </summary>
        /// <param name="solrFacetSortType">Type used in match</param>
        /// <param name="typeName">Type name</param>
        /// <param name="sortName">Sort direction</param>
        internal static void GetSolrFacetSort(this FacetSortType solrFacetSortType, out string typeName, out string sortName)
        {
            switch (solrFacetSortType)
            {
                case FacetSortType.IndexAsc:
                    typeName = "index";
                    sortName = "asc";
                    break;
                case FacetSortType.IndexDesc:
                    typeName = "index";
                    sortName = "desc";
                    break;
                case FacetSortType.CountAsc:
                    typeName = "count";
                    sortName = "asc";
                    break;
                case FacetSortType.CountDesc:
                    typeName = "count";
                    sortName = "desc";
                    break;
                default:
                    throw new ArgumentException(nameof(solrFacetSortType));
            }
        }

        /// <summary>
        /// Get spatial formule
        /// </summary>
        /// <param name="functionType">Spatial function to use</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="centerPoint">Center point information</param>
        /// <param name="distance">Distance</param>
        /// <returns></returns>
        internal static string GetSolrSpatialFormule(this SolrSpatialFunctionType functionType, string fieldName, GeoCoordinate centerPoint, decimal distance)
        {
            return string.Format(
                "{{!{0} sfield={1} pt={2} d={3}}}",
                functionType.ToString().ToLower(),
                fieldName,
                centerPoint,
                distance.ToString("0.#", CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Get the filter with tag
        /// </summary>
        /// <param name="query">Query value</param>
        /// <param name="tagName">Tag name</param>
        internal static string GetSolrFilterWithTag(this string query, string aliasName)
        {
            return !string.IsNullOrWhiteSpace(aliasName) ? $"{{!tag={aliasName}}}{query}" : query;
        }
    }
}
