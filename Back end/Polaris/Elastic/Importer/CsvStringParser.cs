using System.Collections.Generic;
using System.IO;
using System.Globalization;
using CsvHelper;

using Elastic.Models;

namespace Elastic.Importer
{
    public class CsvStringParser<E, T> : IStringParser<E, T> where E : Entity<T>
    {
        public IEnumerable<E> Parse(string source)
        {
            using (var reader = new StringReader(source))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.PrepareHeaderForMatch = (header, index) => header.ToLower();
                return csv.GetRecords<E>();
            }
        }
    }
}