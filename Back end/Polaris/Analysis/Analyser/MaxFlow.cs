// In The Name Of GOD

using Models;
using Models.Network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.Analyser
{
    public class MaxFlow<TNodeId, TNodeData, TEdgeId, TEdgeData>
        where TNodeData : Entity<TNodeId>
        where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        private const Int64 inf = 1_000_000_000_000_000_000;

        private readonly Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph;
        private Dictionary<TNodeId, int> level;
        public MaxFlow(Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph)
        {
            this.graph = graph;
            level = new Dictionary<TNodeId, int>();
        }

        public Int64 DinicMaxFlow(TNodeId source, TNodeId target)
        {
            if (source.Equals(target))
                return -1;

            Int64 result = 0;

            while (BFS(source, target))
            {
                var start = new Dictionary<TNodeId, int>();

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

        private Int64 SendFlow(TNodeId v, Int64 flow, TNodeId target, ref Dictionary<TNodeId, int> start)
        {
            if (v.Equals(target))
                return flow;
            if (!start.ContainsKey(v))
                start[v] = 0;
            for (; start[v] < graph.Adj[v].Count; start[v]++)
            {
                var edge = graph.Adj[v][start[v]];
                if (level[edge.Target] == level[v] + 1 && edge.Flow < edge.Amount)
                {
                    Int64 currFlow = (Int64)Math.Min(flow, edge.Amount - edge.Flow);
                    Int64 tempFlow = SendFlow(edge.Target, currFlow, target, ref start);
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


        private bool BFS(TNodeId source, TNodeId target)
        {
            foreach (var item in graph.Adj)
                level[item.Key] = -1;

            level[source] = 0;
            var q = new List<TNodeId>();
            q.Add(source);

            while (q.Any())
            {
                var nodeId = q.Last();
                q.RemoveAt(q.Count - 1);
                foreach (var edge in graph.Adj[nodeId])
                {
                    var neighbor = edge.Target;
                    if (level[neighbor] < 0 && edge.Flow < edge.Amount)
                    {
                        level[neighbor] = level[nodeId] + 1;
                        q.Add(neighbor);
                    }
                }
            }

            return level[target] != -1;
        }
    }
}
