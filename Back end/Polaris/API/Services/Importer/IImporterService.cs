using API.Services.Utils;
using Models;

namespace API.Services.Importer
{
    public interface IImporterService<TModel>
    where TModel : class, IModel
    {
        void Import(string source, IStringParser<TModel> stringParser, string sourceName);
    }
}