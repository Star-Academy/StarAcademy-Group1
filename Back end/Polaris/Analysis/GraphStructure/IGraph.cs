// In The Name Of GOD

using Analysis.GraphStructure.Structures;
using Elastic.Models;
using System.Collections.Generic;

namespace Analysis.GraphStructure
{
    public interface IGraph<NODEID, NODEDATA, EDGEID, EDGEDATA>
    where NODEDATA : Entity<NODEID>
    where EDGEDATA : Entity<EDGEID>
    {
        Dictionary<Node<NODEID, NODEDATA>, List<Edge<EDGEID, EDGEDATA, Node<NODEID, NODEDATA>>>> Adj { get; set; }

        List<Node<NODEID, NODEDATA>> GetNeighbors(NODEDATA node);

        List<Node<NODEID, NODEDATA>> GetNeighbors(NODEID nodeId);
    }
}