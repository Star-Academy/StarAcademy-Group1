using Nest;
using System.Collections.Generic;
using System.Linq;

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
            var queryContainer = new MatchAllQuery();
            var response = NestScrollSearch(queryContainer, indexName);
            var result = new List<M>();
            var anyDocumentLeft = true;
            string scrollId;
            while(anyDocumentLeft)
            {
                if (response.IsValid)
                {
                    result.AddRange(response.Documents);
                    scrollId = response.ScrollId;
                    response = elasticClient.Scroll<M>("2m", scrollId);
                }
                anyDocumentLeft = response.Documents.Any();
            }
            return result;
        }

        public void Insert(M model, string indexName)
        {
            elasticClient.Index<M>(model, i => i.Index(indexName));
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

        private ISearchResponse<M> NestScrollSearch(
            QueryContainer container,
            string indexName,
            string scrollTimeout = "2m",
            int scrollSize = 10000
        )
        {
            return elasticClient.Search<M>(s => s
                .Index(indexName)
                .From(0)
                .Take(scrollSize)
                .Query(q => container)
                .Scroll(scrollTimeout)
            );
        }
    }
}