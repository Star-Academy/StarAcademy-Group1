using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Xunit;
using Analysis.Analyser;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Analysis.Test
{
    public class BFS_TEST
    {

        Graph<int, Data, int, Data> graph;
        Dictionary<Node<int, Data>, List<Edge<int, Data, Node<int, Data>>>> dic =
            new Dictionary<Node<int, Data>, List<Edge<int, Data, Node<int, Data>>>>();
        [AssemblyInitialize]
        private void Init()
        {
            for (int i = 0; i < 6; i++)
            {
                var node = new Node<int, Data>();
                node.Data = new Data(i);
                dic[node] = new List<Edge<int, Data, Node<int, Data>>>();
            }
            AddEdge(0, 1);
            AddEdge(0, 2);
            AddEdge(1, 4);
            AddEdge(1, 3);
            AddEdge(3, 5);
            AddEdge(2, 4);
            graph = new Graph<int, Data, int, Data>(dic);
        }

        private void AddEdge(int x, int y)
        {
            var edge = getEdge(x, y);
            dic[edge.Source].Add(edge);
        }

        private Edge<int, Data, Node<int, Data>> getEdge(int src, int tar)
        {
            var edge = new Edge<int, Data, Node<int, Data>>();
            var node = new Node<int, Data>();
            node.Data = new Data(src);
            edge.Source = node;
            node.Id = tar;
            edge.Target = node; 
            return edge;
        }

        [Fact]
        public void Test1()
        {
            var src = new Node<int, Data>();
            var tar = new Node<int, Data>();
            src.Data = new Data(0);
            tar.Data = new Data(5);
            var bfs = new BFS<int, Data, int, Data>(graph);
            var ret = bfs.BiDirectionalSearch(src, tar, null);
            Assert.IsTrue(ret.Contains(getEdge(0, 1))
                && ret.Contains(getEdge(1, 3))
                && ret.Contains(getEdge(3, 5))
                && ret.Count == 3
                );
        }
    }
}
