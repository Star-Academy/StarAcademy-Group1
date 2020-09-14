// In The Name Of GOD
using Analysis.GraphStructure.Structures;
using Elastic.Models;
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
            foreach (var item in Adj)
            {
                IDToNode[item.Key.Id] = item.Key;
                DataToNode[item.Key.Data] = item.Key;
                foreach (var edge in item.Value)
                    reverseAdj[edge.Target].Add(edge);
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
    }
}