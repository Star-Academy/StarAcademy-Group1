using Models;
using Analysis.GraphStructure.Structures;
using System.Collections.Generic;

namespace Analysis.GraphStructure
{
    public interface IGraph<IN, EN, IE, EE>
    where EN : Entity<IN>
    where EE : Entity<IE>
    {
        Dictionary<Node<NODEID, NODEDATA>, List<Edge<EDGEID, EDGEDATA, Node<NODEID, NODEDATA>>>> Adj { get; set; }

        public void AddEdgeForFlow(Node<NODEID, NODEDATA> u, Node<NODEID, NODEDATA> v, long amount);
        List<Node<NODEID, NODEDATA>> GetNeighbors(NODEDATA node);

        LinkedList<EN> GetNeighbors(IN nodeId);
    }
}