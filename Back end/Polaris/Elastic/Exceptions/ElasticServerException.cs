using System;

namespace Elastic.Exceptions
{
    public class ElasticServerException : Exception
    {
        public ElasticServerException(string message) : base(message)
        {
        }
    }
}