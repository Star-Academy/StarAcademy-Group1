using System.Linq;
using Nest;

using Models;
using Elastic.Exceptions;

namespace Elastic.Communication.Nest
{
    public class NestEntityHandler<TType> : NestElasticHandler<Entity<TType>>, IEntityHandler<TType>
    {
        private static IElasticClient elasticClient = NestClientFactory.GetInstance().GetElasticClient();
        public void DeleteEntity(TType id, string indexName)
        {
            var entityId_ = GetEntityId_(id, indexName);
            DeleteById_(entityId_, indexName);
        }

        public Entity<TType> GetEntity(TType id, string indexName)
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
            return response.ToList()[0];
        }

        public void UpdateEntity(Entity<TType> newEntity, string indexName)
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