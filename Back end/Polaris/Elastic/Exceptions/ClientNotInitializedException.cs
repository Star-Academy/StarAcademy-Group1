using System;

namespace Elastic.Exceptions
{
    public class ClientNotInitializedException : Exception
    {
        public ClientNotInitializedException() : 
            base("Initialize elastic client before using it.")
        {
        }
    }
}