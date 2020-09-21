using Models;
using Models.Network;
using Models.Response;
using System.Collections.Generic;

namespace API.Services.GraphBusiness
{
    public interface IGraphService<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>, new()
    {
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetWholeGraph();

        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetNodeExpansions(
            TNodeId nodeId,
            bool isSource = false,
            bool isTarget = false,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null
        );

        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetNodesExpansions(
            TNodeId[] nodeIds,
            bool isSource = false,
            bool isTarget = false,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null
        );

        MaxFlowResult<TNodeId, TNodeData, TEdgeId, TEdgeData> GetMaxFlow(
            TNodeId sourceNodeId,
            TNodeId targetNodeId,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null,
            int maxLength = 7
        );

        GetPathsResult<TNodeId, TNodeData, TEdgeId, TEdgeData> GetPaths(
            TNodeId sourceNodeId,
            TNodeId targetNodeId,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null,
            int maxLength = 7
        );

        Dictionary<string, object> Stats();
    }
}