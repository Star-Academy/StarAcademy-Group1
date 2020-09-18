using System;

namespace Elastic.Exceptions
{
    public class InvalidNestFilterException : Exception
    {
        public InvalidNestFilterException(string message) : base(message)
        {
        }
    }
}