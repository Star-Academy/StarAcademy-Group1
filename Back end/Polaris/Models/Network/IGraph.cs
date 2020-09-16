using System.Collections.Generic;

namespace Models.Network
{
    public interface IGraph<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        List<TNodeId> GetNeighbors(TNodeData node);

        List<TNodeId> GetNeighbors(TNodeId nodeId);

        List<TNodeId> Nodes { get; set; }

        List<TEdgeId> Edges { get; set; }
    }
}