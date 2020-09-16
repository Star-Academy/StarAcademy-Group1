using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Network
{
    public class Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> : IGraph<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        public Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>> Adj { get; set; }
        private readonly Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>> reverseAdj;

        public List<TNodeId> GetNeighbors(TNodeData data)
        {
            return ReadNeighbors(data.Id);
        }

        public Graph(Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>> Adj)
        {
            this.Adj = Adj;
            reverseAdj = new Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>>();
            foreach (var item in Adj)
                reverseAdj[item.Key] = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();
            foreach (var item in Adj)
            {
                foreach (var edge in item.Value)
                {
                    reverseAdj[edge.Target].Add(edge);
                }
            }
        }

        private List<TNodeId> ReadNeighbors(TNodeId id)
        {
            var set = new HashSet<TNodeId>();
            foreach (var edge in Adj[id])
            {
                set.Add(edge.Target);
            }

            return set.ToList();
        }

        public List<TNodeId> GetNeighbors(TNodeId id)
        {
            return ReadNeighbors(id);
        }

        public List<TNodeId> GetOpositeNeighbors(TNodeId data)
        {
            var set = new HashSet<TNodeId>();
            foreach (var edge in reverseAdj[data])
            {
                set.Add(edge.Source);
            }

            return set.ToList();
        }

        internal List<Edge<TEdgeData, TEdgeId, TNodeId>> GetEdges(TNodeId id1, TNodeId id2)
        {
            var ret = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();
            foreach (var item in Adj[id1])
                if (item.Target.Equals(id2))
                {
                    ret.Add(item);
                }
            return ret;
        }

        public void AddEdgeForFlow(TNodeId u, TNodeId v, Int64 amount)
        {
            var edge1 = new Edge<TEdgeData, TEdgeId, TNodeId>(u, v, 0, amount, Adj[v].Count);
            var edge2 = new Edge<TEdgeData, TEdgeId, TNodeId>(v, u, 0, 0, Adj[u].Count);

            Adj[u].Add(edge1);
            Adj[v].Add(edge2);
        }
    }
}