using System.Collections.Generic;

namespace Models.Network
{
    public interface IGraph<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        LinkedList<TNodeId> GetNeighbors(TNodeData node);

        LinkedList<TNodeId> GetNeighbors(TNodeId nodeId);

        List<TNodeData> Nodes{get; set;}

        List<TEdgeData> Edges{get; set;}
    }
}