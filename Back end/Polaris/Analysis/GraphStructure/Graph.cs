// In The Name Of GOD

using Analysis.GraphStructure.Structures;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.GraphStructure
{
    public class Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> : IGraph<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : Entity<TEdgeId>
    {
        public Dictionary<Node<TNodeId, TNodeData>, List<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>>> Adj { get; set; }
        private readonly Dictionary<Node<TNodeId, TNodeData>, List<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>>> reverseAdj;

        public Dictionary<TNodeId, Node<TNodeId, TNodeData>> IDToNode { get; set; }
        public Dictionary<TNodeData, Node<TNodeId, TNodeData>> DataToNode { get; set; }
        public List<Node<TNodeId, TNodeData>> GetNeighbors(TNodeData data)
        {
            var node = DataToNode[data];
            return ReadNeighbors(node);
        }

        public Graph(Dictionary<Node<TNodeId, TNodeData>, List<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>>> Adj)
        {
            this.Adj = Adj;
            IDToNode = new Dictionary<TNodeId, Node<TNodeId, TNodeData>>();
            DataToNode = new Dictionary<TNodeData, Node<TNodeId, TNodeData>>();
            reverseAdj = new Dictionary<Node<TNodeId, TNodeData>, List<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>>>();
            foreach (var item in Adj)
                reverseAdj[item.Key] = new List<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>>();
            foreach (var item in Adj)
            {
                IDToNode[item.Key.Id] = item.Key;
                DataToNode[item.Key.Data] = item.Key;
                foreach (var edge in item.Value)
                {
                    reverseAdj[edge.Target].Add(edge);
                }
            }
        }

        private List<Node<TNodeId, TNodeData>> ReadNeighbors(Node<TNodeId, TNodeData> node)
        {
            var set = new HashSet<Node<TNodeId, TNodeData>>();
            foreach (var edge in Adj[node])
            {
                set.Add(edge.Target);
            }

            return set.ToList();
        }

        public List<Node<TNodeId, TNodeData>> GetNeighbors(TNodeId id)
        {
            var node = IDToNode[id];
            return ReadNeighbors(node);
        }

        public List<Node<TNodeId, TNodeData>> GetOpositeNeighbors(TNodeId id)
        {
            var node = IDToNode[id];

            var set = new HashSet<Node<TNodeId, TNodeData>>();
            foreach (var edge in reverseAdj[node])
            {
                set.Add(edge.Source);
            }

            return set.ToList();
        }

        internal List<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>> GetEdges(TNodeId id1, TNodeId id2)
        {
            var ret = new List<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>>();
            var node = IDToNode[id1];
            foreach (var item in Adj[node])
                if (item.Target.Id.Equals(id2))
                {
                    ret.Add(item);
                }
            return ret;
        }

        public void AddEdgeForFlow(Node<TNodeId, TNodeData> u, Node<TNodeId, TNodeData> v, Int64 amount)
        {
            var edge1 = new Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>(u, v, 0, amount, Adj[v].Count);
            var edge2 = new Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>(v, u, 0, 0, Adj[u].Count);

            Adj[u].Add(edge1);
            Adj[v].Add(edge2);
        }
    }
}