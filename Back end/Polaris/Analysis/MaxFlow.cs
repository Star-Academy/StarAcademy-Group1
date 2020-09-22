// In The Name Of GOD

using Models;
using Models.Network;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis
{
    public class MaxFlow<TNodeId, TNodeData, TEdgeId, TEdgeData>
        where TNodeData : Entity<TNodeId>
        where TEdgeData : AmountedEntity<TEdgeId, TNodeId>, IModel, new()
    {
        private const Int64 inf = 1000000000000000;

        private readonly Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph;
        private Dictionary<TNodeId, int> level, start;
        private MaxFlowResult<TNodeId, TNodeData, TEdgeId, TEdgeData> Result { get; set; }
        public MaxFlow(Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph)
        {
            this.graph = graph;
            level = new Dictionary<TNodeId, int>();
            start = new Dictionary<TNodeId, int>();

        }

        public MaxFlow(Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph, List<Edge<TEdgeData, TEdgeId, TNodeId>> edges)
        {
            Result = new MaxFlowResult<TNodeId, TNodeData, TEdgeId, TEdgeData>();
            foreach (var edge in edges)
                Result.EdgeToFlow[edge.Id] = 0;
            this.graph = graph;
            level = new Dictionary<TNodeId, int>();
            init();
        }

        private void init()
        {
            foreach (var adjList in graph.Adj)
            {
                int counter = 0;
                foreach (var edge in adjList.Value)
                {
                    var edge2 = new Edge<TEdgeData, TEdgeId, TNodeId>
                    {
                        Data = new TEdgeData(),
                        Source = edge.Target,
                        Target = edge.Source,
                        Amount = 0,
                        Flow = 0,
                        Address = counter++
                    };
                    edge.Address = graph.Adj[edge.Target].Count;
                    graph.Adj[edge.Target].Add(edge2);
                }
            }
        }

        public MaxFlowResult<TNodeId, TNodeData, TEdgeId, TEdgeData> DinicMaxFlow(TNodeId source, TNodeId target, int maxLength)
        {
            if (source.Equals(target))
            {
                Result.MaxFlowAmount = -1;
                return Result;
            }

            maxLength = 2000;// we don't need to shorten the flow lengths now.
            while (BFS(source, target, maxLength))
            {
                start = new Dictionary<TNodeId, int>();
                foreach (var item in graph.Adj)
                    start[item.Key] = 0;
                {
                    long flow;
                    do
                    {
                        flow = SendFlow(source, inf, target);
                        Result.MaxFlowAmount += flow;
                    } while (flow > 0);
                }
            }

            foreach (var adjList in graph.Adj)
                foreach (var edge in adjList.Value)
                    if (edge.Id != null && Result.EdgeToFlow.ContainsKey(edge.Id))
                    {
                        Result.EdgeToFlow[edge.Id] = edge.Flow;
                    }

            return Result;
        }

        private Int64 SendFlow(TNodeId v, Int64 flow, TNodeId target)
        {
            if (v.Equals(target))
                return flow;
            for (; start[v] < graph.Adj[v].Count; start[v]++)
            {
                var edge = graph.Adj[v][start[v]];
                if (level[edge.Target] == level[v] + 1 && edge.Flow < edge.Amount)
                {
                    Int64 currFlow = flow < edge.Amount - edge.Flow ? flow : edge.Amount - edge.Flow;
                    Int64 tempFlow = SendFlow(edge.Target, currFlow, target);
                    if (tempFlow > 0)
                    {
                        graph.Adj[v][start[v]].Flow += tempFlow;
                        graph.Adj[edge.Target][edge.Address].Flow -= tempFlow;
                        return tempFlow;
                    }
                }
            }
            return 0;
        }


        private bool BFS(TNodeId source, TNodeId target, int maxLenghth)
        {
            foreach (var item in graph.Adj)
                level[item.Key] = -1;

            level[source] = 0;
            var q = new LinkedList<TNodeId>();
            q.AddLast(source);

            while (q.Any())
            {
                var nodeId = q.First();
                q.RemoveFirst();

                foreach (var edge in graph.Adj[nodeId])
                {
                    var neighbor = edge.Target;
                    if (level[neighbor] < 0 && edge.Flow < edge.Amount)
                    {
                        level[neighbor] = level[nodeId] + 1;
                        q.AddLast(neighbor);
                    }
                }
            }
            bool ret = level[target] < 0 ? false : true;
            return ret && level[target] <= maxLenghth;
        }
    }
}
