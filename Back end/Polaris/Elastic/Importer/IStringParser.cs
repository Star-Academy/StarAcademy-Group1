using System.Collections.Generic;

using Models;

namespace Elastic.Importer
{
    public interface IStringParser<M> where M : class, IModel
    {
        IEnumerable<M> Parse(string source);
    }
}