using Models;
using System.Collections.Generic;

namespace API.Services.Utils
{
    public interface IStringParser<M> where M : class, IModel
    {
        IEnumerable<M> Parse(string source);
    }
}