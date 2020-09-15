using Models;

namespace Elastic.Communication
{
    public interface IEntityHandler<TType> : IElasticHandler<Entity<TType>>
    {
        Entity<TType> GetEntity(TType id, string indexName);
        void UpdateEntity(Entity<TType> newEntity, string indexName);
        void DeleteEntity(TType id, string indexName);
    }
}