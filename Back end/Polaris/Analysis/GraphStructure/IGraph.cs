using Elastic.Models;
using System.Collections.Generic;

namespace Analysis.GraphStructure
{
    public interface IGraph<NODEID, NODEDATA, EDGEID, EDGEDATA>
    where NODEDATA : Entity<NODEID>
    where EDGEDATA : Entity<EDGEID>
    {
        Dictionary<NODEDATA, LinkedList<NODEDATA>> Adj{get; set;}

        LinkedList<NODEDATA> GetNeighbors(NODEDATA node);

        LinkedList<NODEDATA> GetNeighbors(NODEID nodeId);
    }
}