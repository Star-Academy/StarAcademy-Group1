using System;
using Elastic.Filtering;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text.Json;
using Nest;

namespace Main
{
    class Person
    {
        public int Age{get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            var queries = new string[]{
                "age gte 1000"
            };

            var mapping = new Dictionary<string, string>{
                {"age", "numeric"}
            };

            var filter = new NestFilter(queries, mapping);
            var interpreted = filter.Interpret();
            Console.WriteLine(interpreted.GetType());
            Console.WriteLine(JsonSerializer.Serialize(interpreted));

            // var json = elasticClient.RequestResponseSerializer.SerializeToString(request);
        }
    }
}
