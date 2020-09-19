using System.Collections.Generic;
using System.Linq;

using API.Exceptions;
using API.Services.EdgeBusiness;
using Models.Banking;
using API.Services.NodeBusiness;
using Models.Network;
using Models;
using Analysis;
using Models.Response;

namespace API.Services.GraphBusiness
{
    public class GraphService<TNodeId, TNodeData, TEdgeId, TEdgeData> : IGraphService<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        private readonly IEdgeService<TEdgeData, TEdgeId, TNodeId> _edgeService;
        private readonly INodeService<TNodeData, TNodeId> _nodeService;

        public GraphService(INodeService<TNodeData, TNodeId> nodeService, IEdgeService<TEdgeData, TEdgeId, TNodeId> edgeService)
        {
            _nodeService = nodeService;
            _edgeService = edgeService;
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetWholeGraph()
        {
            var edges = _edgeService.GetEdgesByFilter().ToList();
            var nodes = _nodeService.GetNodesByFilter().ToList();
            return new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes, edges);
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetExpansion(
            TNodeId nodeId,
            bool source = true,
            bool target = true,
            string[] filter = null,
            Pagination pagination = null
        )
        {
            HashSet<Edge<TEdgeData, TEdgeId, TNodeId>> edges;

            if (!source && !target)
                throw new BadExpansionRequest("Either parameters \"source\" or \"target\" must be true");
            else if (source && target)
                edges = _edgeService.GetEdgesBySideId(nodeId).ToHashSet();
            else if (source)
                edges = _edgeService.GetEdgesBySourceId(nodeId).ToHashSet();
            else
                edges = _edgeService.GetEdgesByTargetId(nodeId).ToHashSet();

            var nodes = _nodeService.GetNodesById(
                edges.SelectMany(edge => new TNodeId[]{edge.Source, edge.Target})
                    .ToHashSet()
                    .ToArray()
            );

            return new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes.ToList(), edges.ToList());
        }

        public List<List<List<TEdgeId>>> GetPaths(
            TNodeId sourceNodeId,
            TNodeId targetNodeId,
            string[] filter = null,
            Pagination pagination = null
        )
        {
            var edges = _edgeService.GetEdgesByFilter(filter, pagination).ToList();
            var nodes = _nodeService.GetNodesByFilter(filter, pagination).ToList();

            return new Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes, edges))
                    .GetPaths(sourceNodeId, targetNodeId);
        }

        public MaxFlowResult<TEdgeId> GetMaxFlow(
            TNodeId sourceNodeId,
            TNodeId targetNodeId,
            string[] filter = null,
            Pagination pagination = null
        )
        {
            var edges = _edgeService.GetEdgesByFilter(filter, pagination).ToList();
            var nodes = _nodeService.GetNodesByFilter(filter, pagination).ToList();
            return new Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes, edges))
                    .GetMaxFlow(sourceNodeId, targetNodeId);
        }

        public Dictionary<string, object> Stats()
        {
            var stats = new Dictionary<string, object>();
            stats.Add("nodesCount", _nodeService.GetNodesByFilter(null, null).Count().ToString());
            stats.Add("edgesCount", _edgeService.GetEdgesByFilter(null, null).Count().ToString());
            return stats;
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetExpansions(TNodeId nodeId, bool source = false, bool target = false, string[] filter = null, Pagination pagination = null)
        {
            throw new System.NotImplementedException();
        }
    }
}