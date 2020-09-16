using System;
using Nest;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;

using Elastic.Filtering.Attributes;


namespace Elastic.Filtering.Criteria
{
    public class NumericNestCriteria : NestCriteria
    {
        private static Dictionary<string, Func<NumericNestCriteria, string, string, QueryContainer>> registry = GetRegistry();

        public NumericNestCriteria(string field, string @operator, string value) : base(field, @operator, value)
        {
        }

        public static Dictionary<string, Func<NumericNestCriteria, string, string, QueryContainer>> GetRegistry()
        {
            var registry = new Dictionary<string, Func<NumericNestCriteria, string, string, QueryContainer>>();
            var methods = typeof(NumericNestCriteria)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.GetCustomAttributes(typeof(NestOperator), false).Length > 0);
            foreach(var method in methods){
                var pair = BuildMethodDelegate(method);
                registry[pair.Key] = pair.Value;
            }

            return registry;
        }

        private static KeyValuePair<string, Func<NumericNestCriteria, string, string, QueryContainer>> BuildMethodDelegate(MethodInfo method)
        {
            var objectInput = Expression.Parameter(typeof(NumericNestCriteria), "criteria");
            var fieldInput = Expression.Parameter(typeof(string), "field");
            var valueInput = Expression.Parameter(typeof(string), "value");
            var lambdaExpression = Expression.Lambda<Func<NumericNestCriteria, string, string, QueryContainer>>(
                Expression.Call(null, method, fieldInput, valueInput), objectInput, fieldInput, valueInput)
                .Compile();

            return new KeyValuePair<string, Func<NumericNestCriteria, string, string, QueryContainer>>(
                ((NestOperator)method.GetCustomAttribute(typeof(NestOperator), false)).Abbrv,
                lambdaExpression
            );
        }

        [NestOperator("gte")]
        public static QueryContainer GreaterThanOrEqual(string field, string value)
        {
            return new NumericRangeQuery
            {
                Field = field,
                GreaterThanOrEqualTo = Convert.ToDouble(value)
            };
        }

        public override QueryContainer Interpret()
        {
            Console.WriteLine($"Entered invoke, {Operator}, {Field}, {Value}");
            foreach(var item in registry)
                Console.WriteLine(item.Key, item.Value);
            
            return registry[Operator].Invoke(null, Field, Value);
        }
    }
}