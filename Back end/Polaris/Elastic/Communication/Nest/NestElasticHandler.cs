using Nest;
using System.Collections.Generic;
using System.Linq;

using Models;

namespace Elastic.Communication.Nest
{
    public class NestElasticHandler<TModel> : IElasticHandler<TModel> where TModel : class, IModel
    {
        private IElasticClient elasticClient = NestClientFactory.GetInstance().GetElasticClient();

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
            elasticClient.Indices.Create(indexName, i => i.Map<TModel>(x => x.AutoMap()));
            // Todo Custom mapping
        }

        public void BulkInsert(IEnumerable<TModel> models, string indexName)
        {
            ValidateIndex(indexName, false);
            var bulk = new BulkDescriptor();
            foreach (var model in models)
            {
                bulk.Index<TModel>(x => x.Index(indexName).Document(model));
            }
            elasticClient.Bulk(bulk);
        }

        public IEnumerable<TModel> FetchAll(string indexName)
        {
            var queryContainer = new MatchAllQuery();
            var response = NestScrollSearch(queryContainer, indexName);
            var result = new List<TModel>();
            var anyDocumentLeft = true;
            string scrollId = response.ScrollId;
            while (anyDocumentLeft)
            {
                if (response.IsValid)
                {
                    result.AddRange(response.Documents);
                    scrollId = response.ScrollId;
                    response = elasticClient.Scroll<TModel>("2m", scrollId);
                }
                anyDocumentLeft = response.Documents.Any();
            }
            elasticClient.ClearScroll(new ClearScrollRequest(scrollId));
            return result;
        }

        public void Insert(TModel model, string indexName)
        {
            elasticClient.Index<TModel>(model, i => i.Index(indexName));
        }

        protected ISearchResponse<TModel> RetrieveQueryResponse(
            QueryContainer container,
            string indexName,
            int pageIndex,
            int pageSize
        )
        {
            return elasticClient.Search<TModel>(s => s
                .Index(indexName)
                .Query(q => container)
                .Size(pageSize)
                .From(pageIndex * pageSize));
        }

        public IReadOnlyCollection<IHit<TModel>> RetrieveQueryHits(
            QueryContainer container,
            string indexName,
            int pageIndex = 0,
            int pageSize = 1
        )
        {
            return RetrieveQueryResponse(container, indexName, pageIndex, pageSize).Hits;
        }

        public IEnumerable<TModel> RetrieveQueryDocuments(
            QueryContainer container,
            string indexName,
            int pageIndex = 0,
            int pageSize = 1
        )
        {
            return RetrieveQueryResponse(container, indexName, pageIndex, pageSize).Documents;
        }

        private ISearchResponse<TModel> NestScrollSearch(
            QueryContainer container,
            string indexName,
            string scrollTimeout = "2m",
            int scrollSize = 10000
        )
        {
            return elasticClient.Search<TModel>(s => s
                .Index(indexName)
                .From(0)
                .Take(scrollSize)
                .Query(q => container)
                .Scroll(scrollTimeout)
            );
        }

        public void DeleteById_(string id_, string indexName)
        {
            var response = elasticClient.Delete<TModel>(id_, dd => dd.Index(indexName));
        }

        public void UpdateById_(string id_, string indexName, TModel newModel)
        {
            var response = elasticClient.Update<TModel>(id_, u => u.Index(indexName).Doc(newModel));
        }
    }
}