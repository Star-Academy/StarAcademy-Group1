using Elastic.Exceptions;
using Models;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;

namespace Elastic.Communication.Nest
{
    public class NestEntityHandler<TModel, TType> : NestElasticHandler<TModel>, IEntityHandler<TModel, TType>
    where TModel : Entity<TType>
    {
        public NestEntityHandler() : base()
        {
        }
        public void DeleteEntity(TType id, string indexName)
        {
            var entityId_ = GetEntityId_(id, indexName);
            DeleteById_(entityId_, indexName);
        }

        public TModel GetEntity(TType id, string indexName)
        {
            var queryContainer = new MatchQuery
            {
                Field = "id",
                Query = id.ToString()
            };
            var response = RetrieveQueryDocuments(queryContainer, indexName);
            if (!response.Any())
            {
                throw new EntityNotFoundException($"Entity with id: \"{id}\" not found in index \"{indexName}\"");
            }
            return response.ToList()[0] as TModel;
        }

        public IEnumerable<TModel> GetEntities(TType[] ids, string indexName)
        {
            if (ids.Any())
                return new List<TModel> { };
            var value = new StringBuilder();
            foreach (var id in ids)
            {
                value.Append(id);
                value.Append(" ");
            }
            var queryContainer = new MatchQuery
            {
                Field = "id",
                Query = value.ToString()
            };
            var response = RetrieveQueryDocuments(queryContainer, indexName);
            if (!response.Any())
            {
                throw new EntityNotFoundException($"Entities with ids: \"{ids}\" not found in index \"{indexName}\"");
            }
            return response;
        }

        public void UpdateEntity(TModel newEntity, string indexName)
        {
            var entityId_ = GetEntityId_(newEntity.Id, indexName);
            UpdateById_(entityId_, indexName, newEntity);
        }

        private string GetEntityId_(TType id, string indexName)
        {
            var queryContainer = new MatchQuery
            {
                Field = "id",
                Query = id.ToString()
            };
            var response = this.RetrieveQueryHits(queryContainer, indexName);

            if (!response.Any())
            {
                throw new EntityNotFoundException($"Entity with id: \"{id}\" not found in index \"{indexName}\"");
            }
            return response.ToList()[0].Id;
        }
    }
}