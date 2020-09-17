using System;
using Nest;
using System.Collections.Generic;
using Elastic.Filtering.Attributes;

namespace Elastic.Filtering.Criteria
{
    using OperatorToFunctionDict = Dictionary<string, Func<NumericNestCriteria, string, string, QueryContainer>>;

    public class NumericNestCriteria : NestCriteria
    {
        private static OperatorToFunctionDict registry = GetRegistry<NumericNestCriteria>();

        public NumericNestCriteria(string field, string @operator, string value) : base(field, @operator, value)
        {
        }

        [NestOperator("gte")]
        public static QueryContainer GreaterThanOrEqual(string field, string value)
        {
            NumericRangeQuery query = new NumericRangeQuery
            {
                Field = field,
                GreaterThanOrEqualTo = Convert.ToDouble(value)
            };
            return query;
        }

        public override QueryContainer Interpret()
        {
            foreach(var item in registry)
                Console.WriteLine(item.Key, item.Value);   
            return registry[Operator].Invoke(null, Field, Value);
        }
    }
}