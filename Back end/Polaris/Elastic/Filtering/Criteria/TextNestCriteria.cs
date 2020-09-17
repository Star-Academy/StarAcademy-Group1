using Nest;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Elastic.Filtering.Attributes;
using Elastic.Exceptions;


namespace Elastic.Filtering.Criteria
{
    using OperatorToFunctionDict = Dictionary<string, Func<TextNestCriteria, string, string, QueryContainer>>;
    public class TextNestCriteria : NestCriteria
    {
        private static OperatorToFunctionDict registry = GetRegistry<TextNestCriteria>();
        protected static readonly Regex ValuePattern = new Regex(
            @"^\S+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        public TextNestCriteria(string field, string @operator, string value) : base(field, @operator, value)
        {
            if(ValuePattern.Match(value) != null)
                throw new InvalidNestFilterException($"\"{value}\" is invalid for TextCriteria");
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
            return new PrefixQuery {
                Field = field,
                Value = value
            };
        }

        [NestOperator("ew")]
        public static QueryContainer EndsWith(string field, string value)
        {
            return new RegexpQuery {
                Field = field,
                Value = "*." + value
            };
        }

        public override QueryContainer Interpret()
        {
            if(registry.ContainsKey(Operator))
                throw new InvalidNestFilterException($"Operator: \"{Operator}\" is not registered in TextCriteria");
            return registry[Operator].Invoke(null, Field, Value);
        }
    }
}