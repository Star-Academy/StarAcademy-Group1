using Elastic.Models;
using System.Collections.Generic;

namespace Elastic.Importer
{
    public interface IStringParser<E, T> where E : Entity<T>
    {
        List<E> Parse(string source);
    }
}