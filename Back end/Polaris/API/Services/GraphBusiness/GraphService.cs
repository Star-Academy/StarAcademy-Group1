using Analysis;
using API.Exceptions;
using API.Services.EdgeBusiness;
using API.Services.NodeBusiness;
using Models;
using Models.Network;
using Models.Response;
using System.Collections.Generic;
using System.Linq;

namespace API.Services.GraphBusiness
{
    public class GraphService<TNodeId, TNodeData, TEdgeId, TEdgeData>
    : IGraphService<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>, new()
    {
        private readonly IEdgeService<TEdgeData, TEdgeId, TNodeId> _edgeService;
        private readonly INodeService<TNodeData, TNodeId> _nodeService;

        public GraphService(
            INodeService<TNodeData, TNodeId> nodeService,
            IEdgeService<TEdgeData, TEdgeId, TNodeId> edgeService
        )
        {
            _nodeService = nodeService;
            _edgeService = edgeService;
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetWholeGraph()
        {
            return GetGraphByFilter();
        }

        private GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetGraphByFilter(
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null
        )
        {
            // var nodes = _nodeService.GetNodesByFilter(nodeFilter, nodePagination).ToList();
            var edges = _edgeService.GetEdgesByFilter(edgeFilter, edgePagination).ToHashSet();

            var filteredNodes = _nodeService.GetNodesByFilter(nodeFilter, nodePagination).ToHashSet();
            var filteredNodesIds = filteredNodes.Select(fn => fn.Id).ToHashSet();

            var sourceTargetNodeIds = edges.SelectMany(edge => new TNodeId[] { edge.Source, edge.Target }).ToHashSet();
            var sourceTargetNodes = _nodeService.GetNodesById(sourceTargetNodeIds.ToArray());

            var allNodeIds = filteredNodesIds.Intersect(sourceTargetNodeIds).ToHashSet();
            var allNodes = filteredNodes.Intersect(sourceTargetNodes).ToHashSet();

            edges = edges.Where(
                e => allNodeIds.Contains(e.Source) && allNodeIds.Contains(e.Target))
                .ToHashSet();

            return new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                allNodes.ToList(),
                edges.ToList()
            );
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetNodeExpansions(
            TNodeId nodeId,
            bool isSource = true,
            bool isTarget = true,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null
        )
        {
            HashSet<Edge<TEdgeData, TEdgeId, TNodeId>> edges;

            if (!isSource && !isTarget)
                throw new BadExpansionRequest("Either parameters \"isSource\" or \"isTarget\" must be true");
            else if (isSource && isTarget)
                edges = _edgeService.GetEdgesBySideId(nodeId, edgeFilter).ToHashSet();
            else if (isSource)
                edges = _edgeService.GetEdgesBySourceId(nodeId, edgeFilter).ToHashSet();
            else
                edges = _edgeService.GetEdgesByTargetId(nodeId, edgeFilter).ToHashSet();

            var filteredNodes = _nodeService.GetNodesByFilter(nodeFilter, nodePagination);
            var filteredNodesIds = filteredNodes.Select(fn => fn.Id);

            var sourceTargetNodeIds = edges.SelectMany(edge => new TNodeId[] { edge.Source, edge.Target }).ToHashSet();
            var sourceTargetNodes = _nodeService.GetNodesById(sourceTargetNodeIds.ToArray());

            var allNodeIds = filteredNodesIds.Intersect(sourceTargetNodeIds).ToHashSet();
            var allNodes = filteredNodes.Intersect(sourceTargetNodes).ToHashSet();

            edges = edges.Where(
                e => allNodeIds.Contains(e.Source) && allNodeIds.Contains(e.Target))
                .ToHashSet();

            return new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                allNodes.ToList(),
                edges.ToList()
            );
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetNodesExpansions(
            TNodeId[] nodeIds,
            bool isSource = true,
            bool isTarget = true,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null
        )
        {
            HashSet<Edge<TEdgeData, TEdgeId, TNodeId>> edges;

            if (!isSource && !isTarget)
                throw new BadExpansionRequest("Either parameters \"isSource\" or \"target\" must be true");
            else if (isSource && isTarget)
                edges = _edgeService.GetEdgesBySideIds(nodeIds, edgeFilter).ToHashSet();
            else if (isSource)
                edges = _edgeService.GetEdgesBySourceIds(nodeIds, edgeFilter).ToHashSet();
            else
                edges = _edgeService.GetEdgesByTargetIds(nodeIds, edgeFilter).ToHashSet();

            var filteredNodes = _nodeService.GetNodesByFilter(nodeFilter, nodePagination);
            var filteredNodesIds = filteredNodes.Select(fn => fn.Id);

            var sourceTargetNodeIds = edges.SelectMany(edge => new TNodeId[] { edge.Source, edge.Target }).ToHashSet();
            var sourceTargetNodes = _nodeService.GetNodesById(sourceTargetNodeIds.ToArray());

            var allNodeIds = filteredNodesIds.Intersect(sourceTargetNodeIds).ToHashSet();
            var allNodes = filteredNodes.Intersect(sourceTargetNodes).ToHashSet();

            edges = edges.Where(
                e => allNodeIds.Contains(e.Source) && allNodeIds.Contains(e.Target))
                .ToHashSet();

            return new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                allNodes.ToList(),
                edges.ToList()
            );
        }

        public MaxFlowResult<TNodeId, TNodeData, TEdgeId, TEdgeData> GetMaxFlow(
            TNodeId sourceNodeId,
            TNodeId targetNodeId,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null,
            int maxLength = 7
        )
        {
            var result = new Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                GetGraphByFilter(nodeFilter, edgeFilter, nodePagination, edgePagination))
                .GetMaxFlow(sourceNodeId, targetNodeId, maxLength);
            return new MaxFlowResult<TNodeId, TNodeData, TEdgeId, TEdgeData>(result.MaxFlowAmount,
                result.EdgeToFlow.Where(etf => etf.Value != 0).ToDictionary(x => x.Key, x => x.Value), result.GraphContainer);
        }

        public Dictionary<string, object> Stats()
        {
            var stats = new Dictionary<string, object>();
            stats.Add("nodesCount", _nodeService.GetNodesByFilter(null, null).Count().ToString());
            stats.Add("edgesCount", _edgeService.GetEdgesByFilter(null, null).Count().ToString());
            return stats;
        }

        public GetPathsResult<TNodeId, TNodeData, TEdgeId, TEdgeData> GetPaths(TNodeId sourceNodeId, TNodeId targetNodeId, string[] nodeFilter, string[] edgeFilter, Pagination nodePagination, Pagination edgePagination, int maxLength)
        {
            var pathsList = new Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                GetGraphByFilter(nodeFilter, edgeFilter, nodePagination, edgePagination))
                .GetPaths(sourceNodeId, targetNodeId, maxLength);
            var nodesIds = new HashSet<TNodeId>();
            var edgesIds = new HashSet<TEdgeId>();
            pathsList.ForEach(first => first.ForEach(second => second.ForEach(third => edgesIds.Add(third))));
            var edges = _edgeService.GetEdgesById(edgesIds.ToArray()).ToList();
            edges.ForEach((e) =>
            {
                nodesIds.Add(e.Source);
                nodesIds.Add(e.Target);
            });
            var graphContainer = new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                _nodeService.GetNodesById(nodesIds.ToArray()).ToList(),
                edges
            );
            return new GetPathsResult<TNodeId, TNodeData, TEdgeId, TEdgeData>(pathsList, graphContainer);
        }
    }
}