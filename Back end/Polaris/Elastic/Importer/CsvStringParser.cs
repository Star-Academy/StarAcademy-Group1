using System.Collections.Generic;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Linq;

using Models;

namespace Elastic.Importer
{
    public class CsvStringParser<M> : IStringParser<M> where M : class, IModel
    {
        public IEnumerable<M> Parse(string source)
        {
            using (var reader = new StringReader(source))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.PrepareHeaderForMatch = (header, index) => header.ToLower();
                return csv.GetRecords<M>().ToList();
            }
        }
    }
}