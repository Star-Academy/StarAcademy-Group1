// In The Name Of GOD

using Analysis.GraphStructure.Structures;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.GraphStructure
{
    public class Graph<NID, NDATA, EID, EDATA> : IGraph<NID, NDATA, EID, EDATA>
    where NDATA : Entity<NID>
    where EDATA : Entity<EID>
    {
        public Dictionary<Node<NID, NDATA>, List<Edge<EID, EDATA, Node<NID, NDATA>>>> Adj { get; set; }
        private readonly Dictionary<Node<NID, NDATA>, List<Edge<EID, EDATA, Node<NID, NDATA>>>> reverseAdj;

        public Dictionary<NID, Node<NID, NDATA>> IDToNode { get; set; }
        public Dictionary<NDATA, Node<NID, NDATA>> DataToNode { get; set; }
        public List<Node<NID, NDATA>> GetNeighbors(NDATA data)
        {
            var node = DataToNode[data];
            return ReadNeighbors(node);
        }

        public Graph(Dictionary<Node<NID, NDATA>, List<Edge<EID, EDATA, Node<NID, NDATA>>>> Adj)
        {
            this.Adj = Adj;
            IDToNode = new Dictionary<NID, Node<NID, NDATA>>();
            DataToNode = new Dictionary<NDATA, Node<NID, NDATA>>();
            reverseAdj = new Dictionary<Node<NID, NDATA>, List<Edge<EID, EDATA, Node<NID, NDATA>>>>();
            foreach (var item in Adj)
                reverseAdj[item.Key] = new List<Edge<EID, EDATA, Node<NID, NDATA>>>();
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

        private List<Node<NID, NDATA>> ReadNeighbors(Node<NID, NDATA> node)
        {
            var set = new HashSet<Node<NID, NDATA>>();
            foreach (var edge in Adj[node])
            {
                set.Add(edge.Target);
            }

            return set.ToList();
        }

        public List<Node<NID, NDATA>> GetNeighbors(NID id)
        {
            var node = IDToNode[id];
            return ReadNeighbors(node);
        }

        public List<Node<NID, NDATA>> GetOpositeNeighbors(NID id)
        {
            var node = IDToNode[id];

            var set = new HashSet<Node<NID, NDATA>>();
            foreach (var edge in reverseAdj[node])
            {
                set.Add(edge.Source);
            }

            return set.ToList();
        }

        internal List<Edge<EID, EDATA, Node<NID, NDATA>>> GetEdges(NID id1, NID id2)
        {
            var ret = new List<Edge<EID, EDATA, Node<NID, NDATA>>>();
            var node = IDToNode[id1];
            foreach (var item in Adj[node])
                if (item.Target.Id.Equals(id2))
                {
                    ret.Add(item);
                }
            return ret;
        }

        public void AddEdgeForFlow(Node<NID, NDATA> u, Node<NID, NDATA> v, Int64 amount)
        {
            var edge1 = new Edge<EID, EDATA, Node<NID, NDATA>>(u, v, 0, amount, Adj[v].Count);
            var edge2 = new Edge<EID, EDATA, Node<NID, NDATA>>(v, u, 0, 0, Adj[u].Count);

            Adj[u].Add(edge1);
            Adj[v].Add(edge2);
        }
    }
}