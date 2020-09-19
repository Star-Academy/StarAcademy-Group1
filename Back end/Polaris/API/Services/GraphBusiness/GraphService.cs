using System.Collections.Generic;
using System.Linq;

using API.Exceptions;
using API.Services.EdgeBusiness;
using Models.Banking;
using API.Services.NodeBusiness;
using Models.Network;
using Models;
using Analysis;


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
            //var bfs = new BFS<TNodeId, TNodeData, TEdgeId, TEdgeData>(new Graph<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodes, edges));

        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetExpansion(TNodeId nodeId, bool source = true, bool target = true)
        {
            // if (!source && !target)
            //     throw new BadExpansionRequest("Either \"source\" or \"target\" must be true");
            // else if (source && target)
            //     return _edgeService.GetEdgesBySideId(nodeId);
            // else if (source)
            //     return _edgeService.GetEdgesBySourceId(nodeId);
            throw new System.NotImplementedException();
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetFlow(TNodeId sourceNodeId, TNodeId targetNodeId)
        {
            throw new System.NotImplementedException();
        }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GetPaths(TNodeId sourceNodeId, TNodeId targetNodeId)
        {
            var edges = _edgeService.GetEdgesByFilter();
            var nodes = _nodeService.GetNodesByFilter();
            //var bfs = BFS<TNodeId, TNodeData, TEdgeId, TEdgeData>(edges, nodes);
            throw new System.NotImplementedException();
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
    }
}