using System;
using Elastic.Filtering;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Main
{
    class MyAttr : System.Attribute
    {
        public MyAttr(string name)
        {
            Name = name;
        }

        public string Name{get;}
    }

    class MyClass
    {
        public MyClass(int a, int b)
        {
            A = a;
            B = b;
        }

        public int A{get; set;}        
        public int B{get; set;}


        [MyAttr("Magic")]
        public static void Method(int a)
        {
            System.Console.WriteLine(a);
        }

        public static void AnotherNonStaticPublicMethod(int a, int b)
        {
            System.Console.WriteLine(a + b);
        }

        public static void AnotherStaticMethod(int a, int b)
        {
            System.Console.WriteLine(a + b);
        }

        private void AnotherPrivateMethod(int a, int b)
        {
            System.Console.WriteLine(a + b);
        }

        private static void AnotherPrivateStaticMethod(int a, int b)
        {
            System.Console.WriteLine(a + b);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // var obj = new MyClass(1,2);
            // var methods = typeof(MyClass).GetMethods(BindingFlags.Public | BindingFlags.Static);
            // foreach(var m in methods)
            //     foreach(var mprime in m.GetCustomAttributes(false))
            //         System.Console.WriteLine(mprime is MyAttr);


            // var AInput = Expression.Parameter(typeof(int), "field");
            // var BInput = Expression.Parameter(typeof(int), "value");
            // var method = typeof(MyClass).GetMethod("Method", BindingFlags.Static | BindingFlags.Public);
            // Action<int, int> result = Expression.Lambda<Action<int, int>>(
            //     Expression.Call(
            //         Expression.Convert(obj, obj.GetType()), method),
            //         AInput,
            //         BInput
            //     )
            //     .Compile();
            // result(null, 1, 2);
            
            
            var input = Expression.Parameter(typeof(MyClass), "input");
            var aInput = Expression.Parameter(typeof(int), "aInput");
            var method = typeof(MyClass).GetMethod("Method", BindingFlags.Static | BindingFlags.Public);
            //you should check for null *and* make sure the return type is string here.
            // Assert.IsFalse(method == null && !method.ReturnType.Equals(typeof(string)));

            // Action<object> result = Expression.Lambda<Action<object>>(Expression.Call(Expression.Convert(input, typeof(MyClass)), method), input).Compile();

            // string str = result(o);
            // Assert.AreEqual("hello world!", str);
            // var o = new MyClass(1,2);
            // System.Console.WriteLine(result(o));
                
            var d = Expression.Lambda<Action<MyClass, int>>(Expression.Call(null, method, aInput), input, aInput).Compile();
            var mapping = new Dictionary<string, Action<MyClass, int>>();
            mapping["key"] = d;
            mapping["key"].Invoke(null, 1);
        }
    }
}
