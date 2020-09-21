using Elastic.Exceptions;
using Elastic.Filtering.Attributes;
using Nest;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            value = value.Trim();
            if (ValuePattern.Match(value) is null)
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
                Value = ".*" + value
            };
        }

        [NestOperator("cnt")]
        public static QueryContainer Contains(string field, string value)
        {
            return new RegexpQuery
            {
                Field = field,
                Value = ".*" + value + ".*"
            };
        }

        [NestOperator("gt")]
        public static QueryContainer GreaterThan(string field, string value)
        {
            return new ScriptQuery
            {
                Script = new InlineScript($"doc['{field}'].value > params.stringQuery")
                {
                    Params = new Dictionary<string, object>
                    {
                        { "stringQuery", value }
                    }
                },
            };
        }

        [NestOperator("gte")]
        public static QueryContainer GreaterThanOrEqual(string field, string value)
        {
            return new ScriptQuery
            {
                Script = new InlineScript($"doc['{field}'].value >= params.stringQuery")
                {
                    Params = new Dictionary<string, object>
                    {
                        { "stringQuery", value }
                    }
                }
            };
        }

        [NestOperator("lt")]
        public static QueryContainer LessThan(string field, string value)
        {
            return new ScriptQuery
            {
                Script = new InlineScript($"doc['{field}'].value < params.stringQuery")
                {
                    Params = new Dictionary<string, object>
                    {
                        { "stringQuery", value }
                    }
                }
            };
        }

        [NestOperator("lte")]
        public static QueryContainer LessThanOrEqual(string field, string value)
        {
            return new ScriptQuery
            {
                Script = new InlineScript($"doc['{field}'].value <= params.stringQuery")
                {
                    Params = new Dictionary<string, object>
                    {
                        { "stringQuery", value }
                    }
                }
            };
        }

        public override QueryContainer Interpret()
        {
            if (!registry.ContainsKey(Operator))
                throw new InvalidNestFilterException($"Operator: \"{Operator}\" is not registered in TextCriteria");
            return registry[Operator].Invoke(null, Field, Value);
        }
    }
}