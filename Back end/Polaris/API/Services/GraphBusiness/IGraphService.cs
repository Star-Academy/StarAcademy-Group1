using System.Collections.Generic;
using Models;
using Models.Network;
using Models.Response;

namespace API.Services.GraphBusiness
{
    public interface IGraphService <TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetWholeGraph();
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetExpansion(TNodeId nodeId, bool source = false,
            bool target = false, string[] filter = null, Pagination pagination = null);
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetExpansions(TNodeId nodeId, bool source = false,
            bool target = false, string[] filter = null, Pagination pagination = null);
        MaxFlowResult<TEdgeId> GetMaxFlow(TNodeId sourceNodeId, TNodeId targetNodeId,
            string[] filter = null, Pagination pagination = null);
        List<List<List<TEdgeId>>> GetPaths(TNodeId sourceNodeId, TNodeId targetNodeId,
            string[] filter = null, Pagination pagination = null);
        Dictionary<string, object> Stats();
    }
}