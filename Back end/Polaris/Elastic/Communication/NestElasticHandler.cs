using Nest;
using System.Collections.Generic;

using Models;

namespace Elastic.Communication
{
    public class NestElaticHandler<M> : IElasticHandler<M> where M : class, IModel
    {
        private IElasticClient elasticClient = ElasticClientFactory.GetElasticClient();

        public void BulkInsert(IEnumerable<M> models, string indexName)
        {
            ValidateIndex(indexName, false);
            var bulk = new BulkDescriptor();
            foreach (var model in models)
            {
                bulk.Index<M>(x => x.Index(indexName).Document(model));
            }
            elasticClient.Bulk(bulk);
        }

        public IEnumerable<M> FetchAll(string indexName)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(M model, string indexName)
        {
            throw new System.NotImplementedException();
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
            elasticClient.Indices.Create(indexName, i => i.Map<M>(x => x.AutoMap()));
            // Todo Custom mapping
        }

        public IEnumerable<M> RetrieveQuery(
            QueryContainer container,
            string indexName,
            int pageIndex,
            int pageSize
        )
        {
            return elasticClient.Search<M>(s => s
                .Index(indexName)
                .Query(q => container)
                .Size(pageSize)
                .From(pageIndex * pageSize)).Documents;
        }
    }
}