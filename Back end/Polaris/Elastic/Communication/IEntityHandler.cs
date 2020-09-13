using Models;

namespace Elastic.Communication
{
    public interface IEntityHandler<TEntity, TType>
    where TEntity: Entity<TType>
    {
        TEntity GetEntity(TType id, string indexName);
        void UpdateEntity(TEntity newEntity, string indexName);
        void DeleteEntity(TType id, string indexName);
    }
}