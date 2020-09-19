using System.Collections.Generic;
using Models;
using Models.Network;


namespace API.Services.GraphBusiness
{
    public interface IGraphService <TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetExpansion(TNodeId nodeId, bool source = false, bool target = false);
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetFlow(TNodeId sourceNodeId, TNodeId targetNodeId);
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetPaths(TNodeId sourceNodeId, TNodeId targetNodeId);
        Dictionary<string, object> Stats();
    }
}