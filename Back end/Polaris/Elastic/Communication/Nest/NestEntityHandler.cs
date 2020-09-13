using System.Linq;
using Nest;

using Models;

namespace Elastic.Communication.Nest
{
    public class NestEntityHandler<TType> : NestElasticHandler<Entity<TType>>, IEntityHandler<TType>
    {
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
			var response = this.RetrieveQueryDocuments(queryContainer, indexName).ToList()[0];
            return response;
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
            return this.RetrieveQueryHits(queryContainer, indexName).ToList()[0].Id;
        }
    }
}