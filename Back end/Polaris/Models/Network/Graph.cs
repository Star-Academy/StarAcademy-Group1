// In The Name Of GOD

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
        public Dictionary<TEdgeId, Edge<TEdgeData, TEdgeId, TNodeId>> EdgeIdToEdge { get; set; }
        public Dictionary<TNodeId, Node<TNodeData, TNodeId>> NodeIdToNode { get; set; }

        public List<TNodeId> GetNeighbors(TNodeData data)
        {
            return ReadNeighbors(data.Id);
        }

        public Graph(GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> container)
        {
            NodeIdToNode = new Dictionary<TNodeId, Node<TNodeData, TNodeId>>();
            EdgeIdToEdge = new Dictionary<TEdgeId, Edge<TEdgeData, TEdgeId, TNodeId>>();
            Adj = new Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>>();
            reverseAdj = new Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>>();
            foreach (var node in container.Nodes)
            {
                NodeIdToNode[node.Id] = node;
                Adj[node.Id] = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();
                reverseAdj[node.Id] = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();
            }
            foreach (var edge in container.Edges)
            {
                EdgeIdToEdge[edge.Id] = edge;
                Adj[edge.Source].Add(edge);
                reverseAdj[edge.Target].Add(edge);
            }
        }

        public Graph(Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>> Adj)
        {
            this.Adj = Adj;
            reverseAdj = new Dictionary<TNodeId, List<Edge<TEdgeData, TEdgeId, TNodeId>>>();
            NodeIdToNode = new Dictionary<TNodeId, Node<TNodeData, TNodeId>>();
            EdgeIdToEdge = new Dictionary<TEdgeId, Edge<TEdgeData, TEdgeId, TNodeId>>();
            foreach (var item in Adj)
                reverseAdj[item.Key] = new List<Edge<TEdgeData, TEdgeId, TNodeId>>();
            foreach (var item in Adj)
                foreach (var edge in item.Value)
                {
                    reverseAdj[edge.Target].Add(edge);
                    EdgeIdToEdge[edge.Id] = edge;
                }
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

        public List<TEdgeId> GetEdges(TNodeId id1, TNodeId id2)
        {
            var ret = new List<TEdgeId>();
            foreach (var item in Adj[id1])
                if (item.Target.Equals(id2))
                {
                    ret.Add(item.Id);
                }
            return ret;
        }
    }
}