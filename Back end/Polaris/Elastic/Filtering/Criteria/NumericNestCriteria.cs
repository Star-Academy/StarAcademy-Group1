using Nest;

namespace Elastic.Filtering.Criteria
{
    public class NumericNestCriteria : NestCriteria
    {
        public NumericNestCriteria(string field, string @operator, string value) : base(field, @operator, value)
        {
        }

        public override QueryContainer Interpret()
        {
            QueryContainer query = new NumericRangeQuery();
            

            return query;
        }
    }
}