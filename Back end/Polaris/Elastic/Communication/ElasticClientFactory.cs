using Elastic.CustomExceptions;
using Nest;
using System;

namespace Elastic.Cumminucation
{
    public static class ElasticClientFactory
    {
        private static IElasticClient client = null;

        public static void CreateInitialClient(string address)
        {
            var uri = new Uri(address);
            var connectionSettings = new ConnectionSettings(uri);
            client = new ElasticClient(connectionSettings);
        }

        public static IElasticClient GetElasticClient()
        {
            if (client == null)
            {
                throw new ClientNotInitializedException();
            }
            return client;
        }
    }
}