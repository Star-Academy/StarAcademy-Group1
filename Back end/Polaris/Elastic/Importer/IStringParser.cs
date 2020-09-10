using System.Collections.Generic;

using Elastic.Models;

namespace Elastic.Importer
{
    public interface IStringParser<E, T> where E : Entity<T>
    {
        List<E> Parse(string source);
    }
}