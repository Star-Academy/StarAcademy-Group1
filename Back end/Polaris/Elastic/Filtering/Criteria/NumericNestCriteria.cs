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
            var query = new NumericRangeQuery
            {
                Field = field,
                GreaterThanOrEqualTo = Convert.ToDouble(value)
            };
            return query;
        }

        [NestOperator("gt")]
        public static QueryContainer GreaterThan(string field, string value)
        {
            var query = new NumericRangeQuery
            {
                Field = field,
                GreaterThan = Convert.ToDouble(value)
            };
            return query;
        }

        [NestOperator("lte")]
        public static QueryContainer LessThanOrEqual(string field, string value)
        {
            var query = new NumericRangeQuery
            {
                Field = field,
                LessThanOrEqualTo = Convert.ToDouble(value)
            };
            return query;
        }

        [NestOperator("lt")]
        public static QueryContainer LessThan(string field, string value)
        {
            var query = new NumericRangeQuery
            {
                Field = field,
                LessThan = Convert.ToDouble(value)
            };
            return query;
        }

        [NestOperator("eq")]
        public static QueryContainer Equal(string field, string value)
        {
            var query = new MatchQuery
            {
                Field = field,
                Query = value
            };
            return query;
        }

        [NestOperator("nq")]
        public static QueryContainer NotEqual(string field, string value)
        {
            var query = new BoolQuery
            {
                MustNot = new List<QueryContainer>
                {
                    new MatchQuery
                    {
                        Field = field,
                        Query = value
                    }
                }
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