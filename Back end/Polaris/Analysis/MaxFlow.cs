// In The Name Of GOD

using Models;
using Models.Network;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis
{
    public class MaxFlow<TNodeId, TNodeData, TEdgeId, TEdgeData>
        where TNodeData : Entity<TNodeId>
        where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        private const Int64 inf = 1_000_000_000_000_000_000;

        private readonly Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph;
        private Dictionary<TNodeId, int> level;
        private MaxFlowResult<TEdgeId> Result { get; set; }
        public MaxFlow(Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph)
        {
            this.graph = graph;
            level = new Dictionary<TNodeId, int>();
        }

        public MaxFlow(Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph, List<Edge<TEdgeData, TEdgeId, TNodeId>> edges)
        {
            Result = new MaxFlowResult<TEdgeId>();
            foreach (var edge in edges)
                Result.EdgeToFlow.Add(edge.Id, 0);
            this.graph = graph;
            level = new Dictionary<TNodeId, int>();
            init();
        }

        private void init()
        {
            foreach (var adjList in graph.Adj)
                foreach (var edge in adjList.Value)
                {
                    var edge2 = new Edge<TEdgeData, TEdgeId, TNodeId>();
                    edge2.Source = edge.Target;
                    edge2.Target = edge.Source;
                    edge2.Amount = 0;
                    edge2.Flow = 0;
                    edge2.Address = graph.Adj[edge.Source].Count;
                    edge.Address = graph.Adj[edge.Target].Count;
                    graph.Adj[edge.Target].Add(edge2);
                }
        }

        public MaxFlowResult<TEdgeId> DinicMaxFlow(TNodeId source, TNodeId target)
        {
            Result = new MaxFlowResult<TEdgeId>();

            if (source.Equals(target))
            {
                Result.MaxFlowAmount = -1;
                return Result;
            }

            while (BFS(source, target))
            {
                var start = new Dictionary<TNodeId, int>();

                {
                    Int64 flow = 0;
                    do
                    {
                        flow = SendFlow(source, inf, target, ref start);
                        Result.MaxFlowAmount += flow;
                    } while (flow > 0);
                }
            }

            foreach(var adjList in graph.Adj)
                foreach(var edge in adjList.Value)
                    if (Result.EdgeToFlow.ContainsKey(edge.Id))
                    {
                        Result.EdgeToFlow[edge.Id] = edge.Flow;
                    }

            return Result;
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
