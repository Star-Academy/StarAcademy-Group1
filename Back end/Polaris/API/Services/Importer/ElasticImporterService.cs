using Elastic.Communication;
using Models;
using API.Services.Utils;

namespace API.Services.Importer
{
    public class ElasticImporterService<TModel> : IImporterService<TModel> where TModel : class, IModel
    {
        private readonly IElasticHandler<TModel> _handler;

        public ElasticImporterService(IElasticHandler<TModel> handler)
        {
            _handler = handler;
        }

        public void Import(string source, IStringParser<TModel> stringParser, string indexName)
        {
            var list = stringParser.Parse(source);
            _handler.BulkInsert(list, indexName);
        }
    }
}