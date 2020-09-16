using Models;
using Analysis.GraphStructure.Structures;
using System.Collections.Generic;

namespace Analysis.GraphStructure
{
    public interface IGraph<NID, NDATA, EID, EDATA>
    where NDATA : Entity<NID>
    where EDATA : Entity<EID>
    {
        Dictionary<Node<NID, NDATA>, List<Edge<EID, EDATA, Node<NID, NDATA>>>> Adj { get; set; }

        public void AddEdgeForFlow(Node<NID, NDATA> u, Node<NID, NDATA> v, long amount);
        List<Node<NID, NDATA>> GetNeighbors(NDATA node);

        List<Node<NID, NDATA>> GetNeighbors(NID nodeId);
    }
}