using System;
using Nest;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Elastic.Filtering.Attributes;
using Elastic.Exceptions;


namespace Elastic.Filtering.Criteria
{
    using OperatorToFunctionDict = Dictionary<string, Func<NumericNestCriteria, string, string, QueryContainer>>;

    public class NumericNestCriteria : NestCriteria
    {
        private static OperatorToFunctionDict registry = GetRegistry<NumericNestCriteria>();
        protected static readonly Regex ValuePattern = new Regex(
            @"^[+-]?([1-9][0-9]*(\.[0-9]+)?)|(0\.[0-9]+)$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        public NumericNestCriteria(string field, string @operator, string value) : base(field, @operator, value)
        {
            if(ValuePattern.Match(value) != null)
                throw new InvalidNestFilterException($"\"{value}\" is invalid for TextCriteria");
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
            if(registry.ContainsKey(Operator))
                throw new InvalidNestFilterException($"Operator: \"{Operator}\" is not registered in NumericCriteria");
            return registry[Operator].Invoke(null, Field, Value);
        }
    }
}