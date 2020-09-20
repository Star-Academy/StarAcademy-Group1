using Analysis;
using API.Exceptions;
using API.Services.EdgeBusiness;
using API.Services.NodeBusiness;
using Models;
using Models.Network;
using Models.Response;
using System;
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
            return GetGraphWithFilter();
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
                edges = _edgeService.GetEdgesBySideId(nodeId).ToHashSet();
            else if (isSource)
                edges = _edgeService.GetEdgesBySourceId(nodeId).ToHashSet();
            else
                edges = _edgeService.GetEdgesByTargetId(nodeId).ToHashSet();

            // var nodes = _nodeService.GetNodesById(
            //     edges.SelectMany(edge => new TNodeId[] { edge.Source, edge.Target })
            //         .ToHashSet()
            //         .ToArray()
            // );
            var nodesId = new HashSet<TNodeId>();
            foreach (var edge in edges)
            {
                nodesId.Add(edge.Source);
                nodesId.Add(edge.Target);
            }
            var nodes = _nodeService.GetNodesById(nodesId.ToArray());
            return new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes.ToList(), edges.ToList());
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetNodesExpansions(
            TNodeId[] nodeIds,
            bool isSource = false,
            bool isTarget = false,
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
                edges = _edgeService.GetEdgesBySideIds(nodeIds).ToHashSet();
            else if (isSource)
                edges = _edgeService.GetEdgesBySourceIds(nodeIds).ToHashSet();
            else
                edges = _edgeService.GetEdgesByTargetIds(nodeIds).ToHashSet();

            // var nodes = _nodeService.GetNodesById(
            //     edges.SelectMany(edge => new TNodeId[] { edge.Source, edge.Target })
            //         .ToHashSet()
            //         .ToArray()
            // );
            var nodesIds = new HashSet<TNodeId>();
            foreach (var edge in edges)
            {
                nodesIds.Add(edge.Source);
                nodesIds.Add(edge.Target);
            }
            var nodes = _nodeService.GetNodesById(nodesIds.ToArray());

            return new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes.ToList(), edges.ToList());
        }

        public MaxFlowResult<TEdgeId> GetMaxFlow(
            TNodeId sourceNodeId,
            TNodeId targetNodeId,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null
        )
        {
            return new Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                GetGraphWithFilter(nodeFilter, edgeFilter, nodePagination, edgePagination))
                .GetMaxFlow(sourceNodeId, targetNodeId);
        }

        public List<List<List<TEdgeId>>> GetPaths(
            TNodeId sourceNodeId,
            TNodeId targetNodeId,
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null
        )
        {
            return new Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                GetGraphWithFilter(nodeFilter, edgeFilter, nodePagination, edgePagination))
                .GetPaths(sourceNodeId, targetNodeId);
        }

        public Dictionary<string, object> Stats()
        {
            var stats = new Dictionary<string, object>();
            stats.Add("nodesCount", _nodeService.GetNodesByFilter(null, null).Count().ToString());
            stats.Add("edgesCount", _edgeService.GetEdgesByFilter(null, null).Count().ToString());
            return stats;
        }

        private GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetGraphWithFilter(
            string[] nodeFilter = null,
            string[] edgeFilter = null,
            Pagination nodePagination = null,
            Pagination edgePagination = null
        )
        {
            var nodes = _nodeService.GetNodesByFilter(nodeFilter, nodePagination).ToList();
            var edges = _edgeService.GetEdgesByFilter(edgeFilter, edgePagination).ToList();

            return new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes, edges);
        }
    }
}