using Nest;
using System.Collections.Generic;

using Elastic.Models;

namespace Elastic.Importer.ElasticCumminucation
{
    public class ElasticImporter<E, T> where E : Entity<T>
    {
        private IElasticClient elasticClient = ElasticClientFactory.GetElasticClient();

        public void BulkList(IEnumerable<E> list, string indexName)
        {
            ValidateIndex(indexName, false);
            var bulk = new BulkDescriptor();
            foreach (var item in list)
            {
                bulk.Index<E>(x => x.Index(indexName).Document(item));
            }
        }

        public void ValidateIndex(string indexName, bool recreate)
        {
            if (elasticClient.Indices.Exists(indexName).Exists)
            {
                if (recreate)
                {
                    elasticClient.Indices.Delete(indexName);
                }
                else
                {
                    return;
                }
            }
            elasticClient.Indices.Create(indexName, i => i.Map<E>(x => x.AutoMap()));
        }
    }
}