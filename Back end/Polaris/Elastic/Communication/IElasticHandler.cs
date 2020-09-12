using System.Collections.Generic;

namespace Elastic.Communication
{
    public interface IElasticHandler<M>
    {
         void ValidateIndex(string indexName, bool recreate);
         
         void BulkInsert(IEnumerable<M> models, string indexName);

         void Insert(M model, string indexName);

        IEnumerable<M> FetchAll(string indexName);
    }
}