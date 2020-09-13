using CsvHelper;
using Elastic.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Elastic.Importer
{
    public class CsvStringParser<E, T> : IStringParser<E, T> where E : Entity<T>
    {
        public List<E> Parse(string source)
        {
            using (var reader = new StringReader(source))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.PrepareHeaderForMatch = (header, index) => header.ToLower();
                return csv.GetRecords<E>().ToList();
            }
        }
    }
}