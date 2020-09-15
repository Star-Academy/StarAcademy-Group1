using Analysis.Analyser;
using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Analysis.Test
{
    public class MaxFlow
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
            AddEdge(0, 1);
            AddEdge(0, 2);
            AddEdge(1, 4);
            AddEdge(1, 3);
            AddEdge(3, 5);
            AddEdge(2, 4);
            AddEdge(3, 1);
            graph = new Graph<int, Data, int, Data>(dic);
        }

        private void AddEdge(int x, int y, Int64 amount)
        {
            var edge = getEdge(x, y, amount);
            dic[edge.Source].Add(edge);
        }

        private Edge<int, Data, Node<int, Data>> getEdge(int src, int tar, Int64 amount)
        {
            var edge = new Edge<int, Data, Node<int, Data>>();
            var node = new Node<int, Data>();
            var node2 = new Node<int, Data>();
            node.Data = new Data(src);
            node2.Data = new Data(tar);
            edge.Source = node;
            edge.Target = node2;
            edge.Data = new Data(new Random().Next());
            return edge;
        }

        [Fact]
        public void Test1()
        {
            Init();
            var src = new Node<int, Data>();
            var tar = new Node<int, Data>();
            src.Data = new Data(0);
            tar.Data = new Data(5);
        }
    }
}
