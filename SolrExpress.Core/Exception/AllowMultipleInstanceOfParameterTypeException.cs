﻿namespace SolrExpress.Core.Exception
{
    public class AllowMultipleInstanceOfParameterTypeException : System.Exception
    {
        public AllowMultipleInstanceOfParameterTypeException(string parameterType) :
            base($"Parameter \"{parameterType}\" is not allowed because another instance of the same type was added")
        {
        }
    }
}
