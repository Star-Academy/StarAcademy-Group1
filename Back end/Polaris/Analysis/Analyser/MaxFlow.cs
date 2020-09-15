// In The Name Of GOD

using Analysis.GraphStructure;
using Elastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.Analyser
{
    public class MaxFlow<NID, NDATA, EID, EDATA>
        where NDATA : Entity<NID>
        where EDATA : Entity<EID>
    {
        private const Int64 inf = 1_000_000_000_000_000_000;

        private readonly Graph<NID, NDATA, EID, EDATA> graph;
        private Dictionary<NID, int> level;
        public MaxFlow(Graph<NID, NDATA, EID, EDATA> graph)
        {
            this.graph = graph;
            level = new Dictionary<NID, int>();
        }

        public Int64 DinicMaxFlow(NID source, NID target)
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

            return result;
        }

        private Int64 SendFlow(NID v, Int64 flow, NID target, ref Dictionary<NID, int> start)
        {
            if (v.Equals(target))
                return flow;
            var u = graph.IDToNode[v];
            if (!start.ContainsKey(v))
                start[v] = 0;
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
    }
}
