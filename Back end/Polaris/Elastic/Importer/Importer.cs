using Elastic.Models;

namespace Elastic.Importer
{
    public class Importer<E, T> where E : Entity<T>
    {
        public void ImportToElastic(string source, IStringParser<E, T> stringParser) {
            var list = stringParser.Parse(source);
            // Todo : Send parsed list to elastic
        }
    }
}