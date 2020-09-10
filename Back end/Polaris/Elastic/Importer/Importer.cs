using Elastic.Importer.ElasticCumminucation;
using Elastic.Models;

namespace Elastic.Importer
{
    public class Importer<E, T> where E : Entity<T>
    {
        private ElasticImporter<E, T> elasticImporter = new ElasticImporter<E, T>();

        public void ImportToElastic(string source, IStringParser<E, T> stringParser, string elasticIndexName)
        {
            var list = stringParser.Parse(source);
            elasticImporter.BulkList(list, elasticIndexName);
        }
    }
}