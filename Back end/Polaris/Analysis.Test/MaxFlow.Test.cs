// In The Name Of GOD

using Analysis.Analyser;
using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Analysis.Test
{
    public class MaxFlow_Test
    {

        Graph<int, Data, int, Data> graph;
        Dictionary<Node<int, Data>, List<Edge<int, Data, Node<int, Data>>>> dic =
            new Dictionary<Node<int, Data>, List<Edge<int, Data, Node<int, Data>>>>();
        private void Init()
        {
            for (int i = 0; i < 6; i++)
            {
                var node = new Node<int, Data>();
                node.Data = new Data(i);
                dic[node] = new List<Edge<int, Data, Node<int, Data>>>();
            }
        }

        private void AddEdge(int src, int tar, Int64 amount)
        {
            var node = new Node<int, Data>();
            var node2 = new Node<int, Data>();
            node.Data = new Data(src);
            node2.Data = new Data(tar);
            AddEdgeForFlow(node, node2, amount);
        }

        private void AddEdgeForFlow(Node<int, Data> u, Node<int, Data> v, Int64 amount)
        {
            var edge1 = new Edge<int, Data, Node<int, Data>>(u, v, 0, amount, dic[v].Count);
            var edge2 = new Edge<int, Data, Node<int, Data>>(v, u, 0, 0, dic[u].Count);

            dic[u].Add(edge1);
            dic[v].Add(edge2);
        }

        [Fact]
        public void Test1()
        {
            Init();
            AddEdge(0, 1, 16);
            AddEdge(0, 2, 13);
            AddEdge(1, 2, 10);
            AddEdge(1, 3, 12);
            AddEdge(2, 1, 4);
            AddEdge(2, 4, 14);
            AddEdge(3, 2, 9);
            AddEdge(3, 5, 20);
            AddEdge(4, 3, 7);
            AddEdge(4, 5, 4);
            graph = new Graph<int, Data, int, Data>(dic);
            var flow = new MaxFlow<int, Data, int, Data>(graph);
            Assert.AreEqual(23, flow.DinicMaxFlow(0, 5));
        }

        [Fact]
        public void Test2()
        {
            Init();
            AddEdge(0, 1, 3);
            AddEdge(0, 2, 7);
            AddEdge(1, 3, 9);
            AddEdge(1, 4, 9);
            AddEdge(2, 1, 9);
            AddEdge(2, 4, 9);
            AddEdge(2, 5, 4);
            AddEdge(3, 5, 3);
            AddEdge(4, 5, 7);
            AddEdge(0, 4, 10);
            graph = new Graph<int, Data, int, Data>(dic);
            var flow = new MaxFlow<int, Data, int, Data>(graph);
            Assert.AreEqual(14, flow.DinicMaxFlow(0, 5));
        }

        [Fact]
        public void Test3()
        {
            Init();
            AddEdge(0, 1, 10);
            AddEdge(0, 2, 10);
            AddEdge(1, 3, 4);
            AddEdge(1, 4, 8);
            AddEdge(1, 2, 2);
            AddEdge(2, 4, 9);
            AddEdge(3, 5, 10);
            AddEdge(4, 3, 6);
            AddEdge(4, 5, 10);
            graph = new Graph<int, Data, int, Data>(dic);
            var flow = new MaxFlow<int, Data, int, Data>(graph);
            Assert.AreEqual(19, flow.DinicMaxFlow(0, 5));
        }
    }
}
