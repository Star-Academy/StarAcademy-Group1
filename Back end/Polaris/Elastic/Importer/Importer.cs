using Elastic.Communication.Nest;
using Models;

namespace Elastic.Importer
{
    public class Importer<TModel> where TModel : class, IModel
    {
        private NestElasticHandler<TModel> elasticImporter = new NestElasticHandler<TModel>();

        public void ImportToElastic(string source, IStringParser<TModel> stringParser, string elasticIndexName)
        {
            var list = stringParser.Parse(source);
            elasticImporter.BulkInsert(list, elasticIndexName);
        }
    }
}