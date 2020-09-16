using System.Collections.Generic;

using Models;

namespace Models.Network
{
    public interface IGraph<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        Dictionary<TNodeData, LinkedList<TNodeData>> Adj{get; set;}

        LinkedList<TNodeData> GetNeighbors(TNodeData node);

        LinkedList<TNodeData> GetNeighbors(TNodeId nodeId);

        List<TNodeData> Nodes{get; set;}

        List<TEdgeData> Edges{get; set;}
    }
}