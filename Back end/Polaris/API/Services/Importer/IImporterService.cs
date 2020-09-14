using Models;

using API.Services.Utils;

namespace API.Services.Importer
{
    public interface IImporterService<TModel>
    where TModel : class, IModel
    {
        void Import(string source, IStringParser<TModel> stringParser, string sourceName);
    }
}