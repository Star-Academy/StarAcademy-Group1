using System;

namespace Elastic.Exceptions
{
    public class InvalidElasticIndexException : Exception
    {
        public InvalidElasticIndexException(string message) : base(message)
        {
        }
    }
}