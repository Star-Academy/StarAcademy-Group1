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
        public Dictionary<Node<NID, NDATA>, LinkedList<Edge<EID, EDATA, Node<NID, NDATA>>>> Adj { get; set; }

        public List<Node<NID, NDATA>> GetNeighbors(NDATA data)
        {
            var node = SearchByData(data);
            return ReadNeighbors(node);
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
            var node = SearchByID(id);
            return ReadNeighbors(node);
        }

        private Node<NID, NDATA> SearchByID(NID id)
        {
            Node<NID, NDATA> ret = null;
            foreach (var it in Adj)
                if (it.Key.Id.Equals(id))
                {
                    ret = it.Key;
                    break;
                }
            return ret;
        }

        private Node<NID, NDATA> SearchByData(NDATA data)
        {
            Node<NID, NDATA> ret = null;
            foreach (var it in Adj)
                if (it.Key.Data.Equals(data))
                {
                    ret = it.Key;
                    break;
                }
            return ret;
        }
    }
}