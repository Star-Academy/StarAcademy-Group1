using Elastic.Communication;
using Models;

namespace Elastic.Importer
{
    public class Importer<M> where M : class, IModel
    {
        private NestElaticHandler<M> elasticImporter = new NestElaticHandler<M>();

        public void ImportToElastic(string source, IStringParser<M> stringParser, string elasticIndexName)
        {
            var list = stringParser.Parse(source);
            elasticImporter.BulkInsert(list, elasticIndexName);
        }
    }
}