using Elastic.Communication.Nest;
using Models;
using API.Services.Utils;

namespace API.Services.Importer
{
    public class ElasticImporterService<TModel> : IImporterService<TModel> where TModel : class, IModel
    {
        private NestElasticHandler<TModel> handler = new NestElasticHandler<TModel>();

        public void Import(string source, IStringParser<TModel> stringParser, string indexName)
        {
            var list = stringParser.Parse(source);
            handler.BulkInsert(list, indexName);
        }
    }
}