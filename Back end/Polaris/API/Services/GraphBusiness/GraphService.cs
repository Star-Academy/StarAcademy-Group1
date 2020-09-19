using System.Collections.Generic;
using System.Linq;

using API.Services.EdgeBusiness;
using Models.Banking;
<<<<<<< Updated upstream
=======
using Models;
using Models.Network;
>>>>>>> Stashed changes
using API.Services.NodeBusiness;

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