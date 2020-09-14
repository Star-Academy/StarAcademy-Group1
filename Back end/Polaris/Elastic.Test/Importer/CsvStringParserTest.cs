using Xunit;

using Elastic.Importer;
using Elastic.Models;
using System;
using System.Linq;
using System.Text;

namespace Elastic.Test.Importer
{
    public class CsvStringParserTest
    {
        public class Foo : Entity<int>
        {
            public string Name { get; set; }

            public Foo(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override bool Equals(object obj)
            {
                return obj is Foo foo &&
                       Id == foo.Id &&
                       Name == foo.Name;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(base.GetHashCode(), Id, Name);
            }
        }
        [Fact]
        public void ParseTest()
        {
            var firstActual = new Foo(1, "John");
            var secondActual = new Foo(10, "Dalton");
            var parser = new CsvStringParser<Foo, int>();
            var csvString = new StringBuilder();
            csvString.AppendLine("Id,Name");
            csvString.AppendLine($"{firstActual.Id},{firstActual.Name}");
            csvString.AppendLine($"{secondActual.Id},{secondActual.Name}");
            var parsedFoo = (parser.Parse(csvString.ToString()));
            Assert.Equal(2, parsedFoo.Count());
            Assert.Equal(firstActual, parsedFoo[0]);
            Assert.Equal(secondActual, parsedFoo[1]);
        }
    }
}