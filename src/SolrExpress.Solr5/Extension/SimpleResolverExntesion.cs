﻿using SolrExpress.Core;
using SolrExpress.Core.Query;
using SolrExpress.Core.Query.Parameter;
using SolrExpress.Core.Query.Result;
using SolrExpress.Core.Update;
using SolrExpress.Solr5.Query;
using SolrExpress.Solr5.Query.Parameter;
using SolrExpress.Solr5.Query.Result;
using SolrExpress.Solr5.Update;

namespace SolrExpress.Solr5.Extension
{
    /// <summary>
    /// Extension class used to manipulate SimpleResolver
    /// </summary>
    public static class SimpleResolverExntesion
    {
        public static SimpleResolver Configure(this SimpleResolver resolver)
        {
            resolver.Mappings.Add(typeof(IAnyParameter), typeof(AnyParameter));
            resolver.Mappings.Add(typeof(IFacetFieldParameter<>), typeof(FacetFieldParameter<>));
            resolver.Mappings.Add(typeof(IFacetLimitParameter), typeof(FacetLimitParameter));
            resolver.Mappings.Add(typeof(IFacetQueryParameter<>), typeof(FacetQueryParameter<>));
            resolver.Mappings.Add(typeof(IFacetRangeParameter<>), typeof(FacetRangeParameter<>));
            resolver.Mappings.Add(typeof(IFacetSpatialParameter<>), typeof(FacetSpatialParameter<>));
            resolver.Mappings.Add(typeof(IFieldsParameter<>), typeof(FieldsParameter<>));
            resolver.Mappings.Add(typeof(IFilterParameter<>), typeof(FilterParameter<>));
            resolver.Mappings.Add(typeof(ILimitParameter), typeof(LimitParameter));
            resolver.Mappings.Add(typeof(IMinimumShouldMatchParameter), typeof(MinimumShouldMatchParameter));
            resolver.Mappings.Add(typeof(IOffsetParameter), typeof(OffsetParameter));
            resolver.Mappings.Add(typeof(IQueryFieldParameter), typeof(QueryFieldParameter));
            resolver.Mappings.Add(typeof(IQueryParameter<>), typeof(QueryParameter<>));
            resolver.Mappings.Add(typeof(ISortParameter<>), typeof(SortParameter<>));
            resolver.Mappings.Add(typeof(IRandomSortParameter), typeof(RandomSortParameter));
            resolver.Mappings.Add(typeof(ISpatialFilterParameter<>), typeof(SpatialFilterParameter<>));
            resolver.Mappings.Add(typeof(IBoostParameter<>), typeof(BoostParameter<>));

            resolver.Mappings.Add(typeof(IDocumentResult<>), typeof(DocumentResult<>));
            resolver.Mappings.Add(typeof(IFacetFieldResult<>), typeof(FacetFieldResult<>));
            resolver.Mappings.Add(typeof(IFacetQueryResult<>), typeof(FacetQueryResult<>));
            resolver.Mappings.Add(typeof(IFacetRangeResult<>), typeof(FacetRangeResult<>));
            resolver.Mappings.Add(typeof(IInformationResult<>), typeof(InformationResult<>));

            resolver.Mappings.Add(typeof(IAtomicUpdate<>), typeof(AtomicUpdate<>));
            resolver.Mappings.Add(typeof(IAtomicDelete<>), typeof(AtomicDelete<>));

            resolver.Mappings.Add(typeof(IParameterContainer), typeof(ParameterContainer));

            resolver.Mappings.Add(typeof(ISystemParameter), typeof(SystemParameter));

            return resolver;
        }
    }
}
