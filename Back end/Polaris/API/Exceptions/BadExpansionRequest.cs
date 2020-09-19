using System;

namespace API.Exceptions
{
    public class BadExpansionRequest : BadRequest
    {
        public BadExpansionRequest(string message) : base(message)
        {
        }
    }
}