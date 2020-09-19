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

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetExpansion(
            TNodeId nodeId,
            bool source = true,
            bool target = true,
            string[] filter = null,
            Pagination pagination = null
        )
        {
            // if (!source && !target)
            //     throw new BadExpansionRequest("Either \"source\" or \"target\" must be true");
            // else if (source && target)
            //     return _edgeService.GetEdgesBySideId(nodeId);
            // else if (source)
            //     return _edgeService.GetEdgesBySourceId(nodeId);
            throw new System.NotImplementedException();
        }

        public MaxFlowResult<TEdgeId> GetFlow(
            TNodeId sourceNodeId,
            TNodeId targetNodeId
        )
        {
            var edges = _edgeService.GetEdgesByFilter().ToList();
            var nodes = _nodeService.GetNodesByFilter().ToList();
            return new Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData>(
                new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes, edges))
                .GetMaxFlow(sourceNodeId, targetNodeId);
        }

        //IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySideId(TTypeSideId id, Pagination pagination = null)
        //IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesBySourceId(TTypeSideId id, Pagination pagination = null)
        //IEnumerable<Edge<TDataModel, TTypeDataId, TTypeSideId>> GetEdgesByTargetId(TTypeSideId id, Pagination pagination = null)

        public Dictionary<string, object> Stats()
        {
            var stats = new Dictionary<string, object>();
            stats.Add("nodesCount", _nodeService.GetNodesByFilter(null, null).Count().ToString());
            stats.Add("edgesCount", _edgeService.GetEdgesByFilter(null, null).Count().ToString());
            return stats;
        }

        public List<List<TEdgeId>> GetPaths(TNodeId sourceNodeId, TNodeId targetNodeId)
        {
            var edges = _edgeService.GetEdgesByFilter();
            var nodes = _nodeService.GetNodesByFilter();
            //var bfs = BFS<TNodeId, TNodeData, TEdgeId, TEdgeData>(edges, nodes);
            throw new System.NotImplementedException();
        }

    }
}