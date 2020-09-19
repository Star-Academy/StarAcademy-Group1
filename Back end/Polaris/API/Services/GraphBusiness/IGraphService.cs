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
        MaxFlowResult<TEdgeId> GetFlow(TNodeId sourceNodeId, TNodeId targetNodeId);
        List<List<TEdgeId>> GetPaths(TNodeId sourceNodeId, TNodeId targetNodeId);
        Dictionary<string, object> Stats();
    }
}