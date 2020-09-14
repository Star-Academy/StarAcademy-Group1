using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using Elastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.Analyser
{
    class MaxFlow<NID, NDATA, EID, EDATA>
        where NDATA : Entity<NID>
        where EDATA : Entity<EID>
    {

        private const Int64 inf = 1_000_000_000_000_000_000;

        private readonly Graph<NID, NDATA, EID, EDATA> graph;
        private Dictionary<NID, int> level;
        public MaxFlow()
        {
            graph = new Graph<NID, NDATA, EID, EDATA>();
            level = new Dictionary<NID, int>();
        }

        public int DinicMaxFlow(NID source, NID target)
        {
            if (source.Equals(target))
                return -1;

            Int64 result = 0;

            while (BFS(source, target))
            {
                var start = new Dictionary<NID, int>();

                {
                    Int64 flow = 0;
                    do
                    {
                        flow = SendFlow(source, inf, target, ref start);
                        result += flow;
                    } while (flow > 0);
                }
            }

            return 0;
        }

        private Int64 SendFlow(NID v, Int64 flow, NID target, ref Dictionary<NID, int> start)
        {
            if (v.Equals(target))
                return flow;
            var u = graph.IDToNode[v];
            for (; start[v] < graph.Adj[u].Count; start[v]++)
            {
                var edge = graph.Adj[u][start[v]];
                if (level[edge.Target.Id] == level[v] + 1 && edge.Flow < edge.Amount)
                {
                    Int64 currFlow = Math.Min(flow, edge.Amount - edge.Flow);
                    Int64 tempFlow = SendFlow(edge.Target.Id, currFlow, target, ref start);
                    if (tempFlow > 0)
                    {
                        edge.Flow += tempFlow;
                        graph.Adj[edge.Target][edge.Address].Flow -= tempFlow;
                        return tempFlow;
                    }
                }
            }
            return 0;
        }


        private bool BFS(NID source, NID target)
        {
            foreach (var item in graph.Adj)
                level[item.Key.Id] = -1;

            level[source] = 0;
            var q = new List<NID>();
            q.Add(source);

            while (q.Any())
            {
                var node = graph.IDToNode[q.Last()];
                q.RemoveAt(q.Count - 1);
                foreach (var edge in graph.Adj[node])
                {
                    var neighbor = edge.Target.Id;
                    if (level[neighbor] < 0 && edge.Flow < edge.Amount)
                    {
                        level[neighbor] = level[node.Id] + 1;
                        q.Add(neighbor);
                    }
                }
            }

            return level[target] != -1;
        }

        public void AddEdge(Node<NID, NDATA> u, Node<NID, NDATA> v, Int64 amount)
        {
            var edge1 = new Edge<EID, EDATA, Node<NID, NDATA>>(u, v, 0, amount, graph.Adj[v].Count);
            var edge2 = new Edge<EID, EDATA, Node<NID, NDATA>>(v, u, 0, 0, graph.Adj[u].Count);

            graph.Adj[u].Add(edge1);
            graph.Adj[v].Add(edge2);
        }

    }
}
