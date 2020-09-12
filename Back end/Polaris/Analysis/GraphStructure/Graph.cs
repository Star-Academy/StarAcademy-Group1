// In The Name Of GOD
using Analysis.GraphStructure.Structures;
using Elastic.Models;
using System.Collections.Generic;

namespace Analysis.GraphStructure
{
    public class Graph<NODEID, NODEDATA, EDGEID, EDGEDATA> : IGraph<NODEID, NODEDATA, EDGEID, EDGEDATA>
    where NODEDATA : Entity<NODEID>
    where EDGEDATA : Entity<EDGEID>
    {
        public Dictionary<Node<NODEID, NODEDATA>, LinkedList<Edge<EDGEID, EDGEDATA, Node<NODEID, NODEDATA>>>> Adj { get; set; }

        public LinkedList<Node<NODEID, NODEDATA>> GetNeighbors(NODEDATA node)
        {
            return null;
        }

        public LinkedList<Node<NODEID, NODEDATA>> GetNeighbors(NODEID nodeId)
        {
            return null;
        }
    }
}