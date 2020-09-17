using System;
using Nest;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;
using Elastic.Filtering.Attributes;


namespace Elastic.Filtering.Criteria
{
    public abstract class NestCriteria : INestInterpretable
    {
        protected NestCriteria(string field, string @operator, string value)
        {
            Field = field;
            Operator = @operator;
            Value = value;
        }

        protected string Field { get; set; }
        protected string Operator { get; set; }
        protected string Value { get; set; }

        public abstract QueryContainer Interpret();

        public static Dictionary<string, Func<TNestCriteria, string, string, QueryContainer>> GetRegistry<TNestCriteria>()
        where TNestCriteria : NestCriteria
        {
            var registry = new Dictionary<string, Func<TNestCriteria, string, string, QueryContainer>>();
            var methods = typeof(TNestCriteria)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.GetCustomAttributes(typeof(NestOperator), false).Length > 0);
            foreach(var method in methods){
                var pair = BuildMethodDelegate<TNestCriteria>(method);
                registry[pair.Key] = pair.Value;
            }

            return registry;
        }

        private static KeyValuePair<string, Func<TNestCriteria, string, string, QueryContainer>> BuildMethodDelegate<TNestCriteria>(MethodInfo method)
        where TNestCriteria : NestCriteria
        {
            var objectInput = Expression.Parameter(typeof(TNestCriteria), "criteria");
            var fieldInput = Expression.Parameter(typeof(string), "field");
            var valueInput = Expression.Parameter(typeof(string), "value");
            var lambdaExpression = Expression.Lambda<Func<TNestCriteria, string, string, QueryContainer>>(
                Expression.Call(null, method, fieldInput, valueInput), objectInput, fieldInput, valueInput)
                .Compile();

            return new KeyValuePair<string, Func<TNestCriteria, string, string, QueryContainer>>(
                ((NestOperator)method.GetCustomAttribute(typeof(NestOperator), false)).Abbrv,
                lambdaExpression
            );
        }

    }
}