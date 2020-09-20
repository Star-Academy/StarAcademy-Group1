using System.Collections.Generic;

using Models;

namespace API.Services.Utils
{
    public interface IStringParser<M> where M : class, IModel
    {
        IEnumerable<M> Parse(string source);
    }
}