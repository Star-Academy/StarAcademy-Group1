using Models;

namespace Elastic.Communication
{
    public interface IEntityHandler<TModel, TType> : IElasticHandler<TModel>
    where TModel : Entity<TType>
    {
        TModel GetEntity(TType id, string indexName);
        void UpdateEntity(TModel newEntity, string indexName);
        void DeleteEntity(TType id, string indexName);
    }
}