// In The Name Of GOD
using Analysis.GraphStructure.Structures;
using Elastic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace Analysis.GraphStructure
{
    public class Graph<NID, NDATA, EID, EDATA> : IGraph<NID, NDATA, EID, EDATA>
    where NDATA : Entity<NID>
    where EDATA : Entity<EID>
    {
        public Dictionary<Node<NID, NDATA>, LinkedList<Edge<EID, EDATA, Node<NID, NDATA>>>> Adj { get; set; }

        public List<Node<NID, NDATA>> GetNeighbors(NDATA data)
        {
            var set = new HashSet<Node<NID, NDATA>>();

            foreach(var it in Adj)
                if (it.Key.Data.Equals(data))
                {
                    foreach (var edge in it.Value)
                    {
                        set.Add(edge.Target);
                    }
                    break;
                }

            return set.ToList();
        }

        public List<Node<NID, NDATA>> GetNeighbors(NID id)
        {
            var set = new HashSet<Node<NID, NDATA>>();

            foreach (var it in Adj)
                if (it.Key.Data.Equals(id))
                {
                    foreach (var edge in it.Value)
                    {
                        set.Add(edge.Target);
                    }
                    break;
                }

            return set.ToList();
        }
    }
}