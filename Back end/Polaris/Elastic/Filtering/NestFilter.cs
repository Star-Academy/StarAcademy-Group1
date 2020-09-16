using System;
using System.Collections.Generic;

using Elastic.Filtering.Criteria;
using Nest;

namespace Elastic.Filtering
{
    public class NestFilter : INestInterpretable
    {
        private List<NestCriteria> criterias;
        private Dictionary<string, string> mapping;

        public NestFilter(string[] filterQueries, Dictionary<string, string> mapping)
        {
            criterias = new List<NestCriteria>();
            BuildCriterias(filterQueries);
            this.mapping = mapping;
        }

        public QueryContainer Interpret()
        {
            throw new NotImplementedException();
        }

        private void BuildCriterias(string[] filterQueries)
        {
            throw new NotImplementedException();
        }
    }
}