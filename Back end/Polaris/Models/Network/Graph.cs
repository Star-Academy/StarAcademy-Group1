// In The Name Of GOD

using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

        public Graph(GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> container)
        {
            Adj = new Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>>();
            reverseAdj = new Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>>();
            foreach (var node in container.Nodes) 
            {
                Adj[node.Id] = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();
                reverseAdj[node.Id] = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();
            }
            foreach (var edge in container.Edges)
            {
                Adj[edge.Source].Add(edge);
                reverseAdj[edge.Target].Add(edge);
            }
        }

        public Graph(Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>> Adj)
        {
            this.Adj = Adj;
            reverseAdj = new Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>>();

            foreach (var item in Adj)
                reverseAdj[item.Key] = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();

            foreach (var item in Adj)
                foreach (var edge in item.Value)
                    reverseAdj[edge.Target].Add(edge);
        }

        private List<TNodeId> ReadNeighbors(TNodeId id)
        {
            var set = new HashSet<TNodeId>();

            foreach (var edge in Adj[id])
                set.Add(edge.Target);

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

        public List<Edge<TEdgeData, TEdgeId, TNodeId>> GetEdges(TNodeId id1, TNodeId id2)
        {
            var ret = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();
            foreach (var item in Adj[id1])
                if (item.Target.Equals(id2))
                {
                    ret.Add(item);
                }
            return ret;
        }
    }
}