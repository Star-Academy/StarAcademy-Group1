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
        private static Dictionary<string, MethodInfo> registry = Init();

        private static Dictionary<string, Func<QueryContainer>> Init()
        {
            var nnc = new NumericNestCriteria("field", "gte", "value");
            
        }


        public NumericNestCriteria(string field, string @operator, string value) : base(field, @operator, value)
        {
        }

        public override QueryContainer Interpret()
        {
            // QueryContainer query = new NumericRangeQuery();
            // typeof(NumericNestCriteria).GetMethod("method").Invoke(null, new object[]{});
            // var invokable = new MethodInfo();
            // invokable.invoke();
            // Dictionary<string, >
            // foreach (var method in methods)
            // {
            // }
            // return query;
        }

        private static void RegisterMethod(string methodName)
        {

            var input = Expression.Parameter(typeof(object), "input");
            var method = NumericNestCriteria.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);
            //you should check for null *and* make sure the return type is string here.
            Assert.IsFalse(method == null && !method.ReturnType.Equals(typeof(string)));

            //now build a dynamic bit of code that does this:
            //(object o) => ((TestType)o).GetName();
            Func<object, string> result = Expression.Lambda<Func<object, string>>(
                Expression.Call(Expression.Convert(input, o.GetType()), method), input).Compile();

            string str = result(o);
            Assert.AreEqual("hello world!", str);
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
    }
}