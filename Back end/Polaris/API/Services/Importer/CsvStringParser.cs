using System.Collections.Generic;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Linq;

using Models;

namespace API.Services.Importer
{
    public class CsvStringParser<TModel> : IStringParser<TModel> where TModel : class, IModel
    {
        public IEnumerable<TModel> Parse(string source)
        {
            using (var reader = new StringReader(source))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ",";
                csv.Configuration.PrepareHeaderForMatch = (header, index) => header.ToLower();
                return csv.GetRecords<TModel>().ToList();
            }
        }
    }
}