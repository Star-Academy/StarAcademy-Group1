using System.Collections.Generic;

using Models;

namespace API.Services.Importer
{
    public interface IStringParser<M> where M : class, IModel
    {
        IEnumerable<M> Parse(string source);
    }
}