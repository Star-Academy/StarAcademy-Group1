using System;

namespace Elastic.Exceptions
{
    public class ElasticClientException : Exception
    {
        public ElasticClientException(string message) : base(message)
        {
        }
    }
}