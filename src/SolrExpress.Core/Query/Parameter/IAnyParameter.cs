﻿namespace SolrExpress.Core.Query.Parameter
{
    /// <summary>
    /// Signatures to use any parameter
    /// </summary>
    public interface IAnyParameter : IParameter
    {
        /// <summary>
        /// Configure current instance
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">Value of the parameter</param>
        IAnyParameter Configure(string name, string value);

        /// <summary>
        /// Name of the parameter
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Value of the parameter
        /// </summary>
        string Value { get; }
    }
}
