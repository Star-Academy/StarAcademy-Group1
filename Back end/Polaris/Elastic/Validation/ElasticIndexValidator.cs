using Nest;
using Elastic.Communication.Nest;
using Elastic.Exceptions;

namespace Elastic.Validation
{
    public class ElasticIndexValidator
    {
        private static IElasticClient elasticClient = NestClientFactory.GetInstance().GetElasticClient();

        public static void ValidateIndex(string indexName)
        {
            if (elasticClient.Indices.Exists(indexName).Exists)
                return;
            throw new InvalidElasticIndexException($"\"{indexName}\" index does not exist");
        }
    }
}