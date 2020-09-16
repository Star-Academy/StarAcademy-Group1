// In The Name Of GOD

using Analysis.Analyser;
using Models;
using Models.Network;
using System;
using System.Collections.Generic;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Analysis.Test
{
    public class BFS_TEST
    {

        Graph<int, Data, int, AmountedEntity<int, int>> graph;
        Dictionary<int, List<Edge<AmountedEntity<int, int>, int, int>>> dic =
            new Dictionary<int, List<Edge<AmountedEntity<int, int>, int, int>>>();
        private void AddEdges1()
        {
            AddEdge(0, 1);
            AddEdge(0, 2);
            AddEdge(1, 4);
            AddEdge(1, 3);
            AddEdge(3, 5);
            AddEdge(2, 4);
            AddEdge(3, 1);
            graph = new Graph<int, Data, int, AmountedEntity<int, int>>(dic);
        }

        private void Init()
        {
            for (int i = 0; i < 6; i++)
            {
                dic[i] = new List<Edge<AmountedEntity<int, int>, int, int>>();
            }
        }

        private void AddEdges2()
        {
            AddEdge(0, 1);
            AddEdge(0, 2);
            AddEdge(1, 4);
            AddEdge(1, 3);
            AddEdge(3, 5);
            AddEdge(4, 5);
            AddEdge(2, 3);
            AddEdge(2, 4);

            AddEdge(2, 0);
            AddEdge(3, 1);
            AddEdge(4, 1);
            AddEdge(1, 0);
            AddEdge(5, 3);
            AddEdge(4, 2);
            AddEdge(5, 4);
            AddEdge(3, 2);

            graph = new Graph<int, Data, int, AmountedEntity<int, int>>(dic);
        }

        private void AddEdge(int x, int y)
        {
            var edge = getEdge(x, y);
            dic[edge.Source].Add(edge);
        }

        private Edge<AmountedEntity<int, int>, int, int> getEdge(int src, int tar)
        {
            var edge = new Edge<AmountedEntity<int, int>, int, int>();
            edge.Data = new AmountedData(src, tar, 0);
            edge.Id = new Random().Next();
            return edge;
        }

        [Fact]
        public void Test1()
        {
            Init();
            AddEdges1();
            int src = 0;
            int tar = 5;
            var bfs = new BFS<int, Data, int, AmountedEntity<int, int>>(graph);
            var ret = bfs.BiDirectionalSearch(src, tar);
            foreach (var item in ret)
            {
                item.Source = item.Source;
            }
            Assert.IsTrue(ret.Count == 3);
        }

        [Fact]
        public void Test2()
        {
            Init();
            AddEdges1();
            int src = 0;
            int tar = 1;
            var bfs = new BFS<int, Data, int, AmountedEntity<int, int>>(graph);
            var ret = bfs.BiDirectionalSearch(src, tar);
            foreach (var item in ret)
            {
                item.Source = item.Source;
            }
            Assert.IsTrue(ret.Count == 1);
        }

        [Fact]
        public void Test3()
        {
            Init();
            AddEdges1();
            int src = 4;
            int tar = 5;
            var bfs = new BFS<int, Data, int, AmountedEntity<int, int>>(graph);
            var ret = bfs.BiDirectionalSearch(src, tar);
            foreach (var item in ret)
            {
                item.Source = item.Source;
            }
            Assert.IsTrue(ret.Count == 0);
        }

        [Fact]
        public void Test4()
        {
            Init();
            AddEdges2();
            int src = 0;
            int tar = 5;
            var bfs = new BFS<int, Data, int, AmountedEntity<int, int>>(graph);
            var ret = bfs.BiDirectionalSearch(src, tar);
            foreach (var item in ret)
            {
                item.Source = item.Source;
            }
            Assert.IsTrue(ret.Count == 8);
        }
    }
}
