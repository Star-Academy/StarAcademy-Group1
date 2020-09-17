using Nest;
using System;
using System.Collections.Generic;
using Elastic.Filtering.Attributes;

namespace Elastic.Filtering.Criteria
{
    using OperatorToFunctionDict = Dictionary<string, Func<TextNestCriteria, string, string, QueryContainer>>;
    public class TextNestCriteria : NestCriteria
    {
        private static OperatorToFunctionDict registry = GetRegistry<TextNestCriteria>();

        public TextNestCriteria(string field, string @operator, string value) : base(field, @operator, value)
        {
        }

        [NestOperator("eq")]
        public static QueryContainer Equal(string field, string value)
        {
            return new MatchQuery
            {
                Field = field,
                Query = value
            };
        }

        [NestOperator("nq")]
        public static QueryContainer NotEqual(string field, string value)
        {
            return new BoolQuery
            {
                MustNot = new List<QueryContainer> { Equal(field, value) }
            };
        }

        [NestOperator("sw")]
        public static QueryContainer StartsWith(string field, string value)
        {
            return new PrefixQuery
            {
                Field = field,
                Value = value
            };
        }

        [NestOperator("ew")]
        public static QueryContainer EndsWith(string field, string value)
        {
            return new RegexpQuery
            {
                Field = field,
                Value = "*." + value
            };
        }

        [NestOperator("cnt")]
        public static QueryContainer Contains(string field, string value)
        {
            return new RegexpQuery
            {
                Field = field,
                Value = "*." + value + "*."
            };
        }

        public override QueryContainer Interpret()
        {
            foreach (var item in registry)
                Console.WriteLine(item.Key, item.Value);
            return registry[Operator].Invoke(null, Field, Value);
        }
    }
}