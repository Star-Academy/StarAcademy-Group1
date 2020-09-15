using System;

namespace Elastic.Exceptions
{
    public class ElasticApiException : Exception
    {
        public ElasticApiException(string message) : base(message)
        {
        }
    }
}