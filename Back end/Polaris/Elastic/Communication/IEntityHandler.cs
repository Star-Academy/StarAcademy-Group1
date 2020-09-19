using Models;
using System.Collections.Generic;


namespace Elastic.Communication
{
    public interface IEntityHandler<TModel, TType> : IElasticHandler<TModel>
    where TModel : Entity<TType>
    {
        TModel GetEntity(TType id, string indexName);
        IEnumerable<TModel> GetEntities(TType[] ids, string indexName);
        void UpdateEntity(TModel newEntity, string indexName);
        void DeleteEntity(TType id, string indexName);
    }
}