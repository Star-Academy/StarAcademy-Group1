using System.Linq;
using System.Collections.Generic;

using Elastic.Exceptions;
using Elastic.Filtering.Criteria;
using Nest;

using System.Text.RegularExpressions;

namespace Elastic.Filtering
{
    public class NestFilter : INestInterpretable
    {
        static readonly Regex FilterPattern = new Regex(
            @"\s*(?<field>\S+?)\s+(?<operator>\S+?)\s+(?<value>\S+?)\s*",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        private List<NestCriteria> criterias;
        private Dictionary<string, string> mapping;

        public NestFilter(string[] filterQueries, Dictionary<string, string> mapping)
        {
            this.mapping = mapping;
            criterias = new List<NestCriteria>();
            BuildCriterias(filterQueries);
        }

        public QueryContainer Interpret()
        {
            return (QueryContainer) new BoolQuery
            {
                Must = this.criterias.Select(criteria => criteria.Interpret()).ToList()
            };
        }

        private void BuildCriterias(string[] filterQueries)
        {
            foreach (var query in filterQueries)
                criterias.Add(BuildCriteria(query));
        }

        private NestCriteria BuildCriteria(string filterQuery)
        {
            var match = FilterPattern.Match(filterQuery);
            var selectedField = match.Groups["field"].Value;
            string @operator, value;

            switch (mapping[selectedField])
            {
                case "text":
                    @operator = match.Groups["operator"].Value;
                    value = match.Groups["value"].Value;
                    return new TextNestCriteria(selectedField, @operator, value);
                case "numeric":
                    @operator = match.Groups["operator"].Value;
                    value = match.Groups["value"].Value;
                    return new NumericNestCriteria(selectedField, @operator, value);
                default:
                    throw new InvalidNestFilterException($"Field: \"{selectedField}\" not in valid fields: [{mapping.Keys}]");
            }
        }
    }
}