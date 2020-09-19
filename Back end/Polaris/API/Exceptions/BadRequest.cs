using System;

namespace API.Exceptions
{
    public class BadRequest : Exception
    {
        public BadRequest(string message) : base(message)
        {
        }
    }
}