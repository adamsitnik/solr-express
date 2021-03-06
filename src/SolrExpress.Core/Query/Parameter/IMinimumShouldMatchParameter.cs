﻿namespace SolrExpress.Core.Query.Parameter
{
    /// <summary>
    /// Signatures to use in minimum should match parameter
    /// </summary>
    public interface IMinimumShouldMatchParameter : IParameter
    {
        /// <summary>
        /// Configure current instance
        /// </summary>
        /// <param name="expression">Expression used to make the mm parameter</param>
        IMinimumShouldMatchParameter Configure(string expression);

        /// <summary>
        /// Expression used to make the mm parameter
        /// </summary>
        string Expression { get; }
    }
}
