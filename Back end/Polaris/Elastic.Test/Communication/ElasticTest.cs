using Xunit;
using System.Collections.Generic;

using Elastic.Communication.Nest;
using Elastic.Test.Importer;

namespace Elastic.Test.Communication
{
    public class ElasticTest
    {
        [Fact]
        public void InitClient()
        {
            var nestClientFactory = NestClientFactory.GetInstance();
            nestClientFactory.CreateInitialClient("http://localhost:9200");
            var client = nestClientFactory.GetElasticClient();
            var response = client.Ping();
            Assert.True(response.IsValid);
        }

        public void ElasticImporterTest()
        {
            InitClient();
            var list = new List<CsvStringParserTest.Foo>();
            list.Add(new CsvStringParserTest.Foo(1, "John Dalton"));
            var importer = new NestElasticHandler<CsvStringParserTest.Foo>();
            importer.BulkInsert(list, "xunit");
        }
    }
}