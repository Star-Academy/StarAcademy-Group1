using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit;

namespace Analysis.Test
{
    public class BFS_TEST
    {

        Graph<int, Data, int, Data> graph;
        [AssemblyInitialize]
        private void Init()
        {
            var dic = new Dictionary<Node<int, Data>, List<Edge<int, Data, Node<int, Data>>>>();
            var node = new Node<int, Data>();
            Edge<int, Data, Node<int, Data>> edge = new Edge<int, Data, Node<int, Data>>();

            for (int i = 0; i < 6; i++)
            {
                node.Id = i;
                dic[node] = new List<Edge<int, Data, Node<int, Data>>>();
            }

            node.Id = 1;
            edge.Source = node;
            node.Id = 2;
            edge.Target = node;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
