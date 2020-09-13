using System.Collections.Generic;

namespace Elastic.Communication
{
    public interface IElasticHandler<TModel>
    {
        void CheckIndex(string indexName, bool recreate);

        void BulkInsert(IEnumerable<TModel> models, string indexName);

        void Insert(TModel model, string indexName);

        IEnumerable<TModel> FetchAll(string indexName);
    }
}