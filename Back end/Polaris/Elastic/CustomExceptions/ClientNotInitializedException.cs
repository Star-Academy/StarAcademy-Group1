using System;

namespace Elastic.CustomExceptions
{
    public class ClientNotInitializedException : Exception
    {
        public ClientNotInitializedException() : 
            base("Initialize elastic client before using it.")
        {
        }
    }
}