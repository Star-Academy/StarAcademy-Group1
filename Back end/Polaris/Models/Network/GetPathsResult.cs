using System.Collections.Generic;

namespace Models.Network
{
    public class GetPathsResult<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        public GetPathsResult(List<List<List<TEdgeId>>> pathsList, GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> graph)
        {
            PathsList = pathsList;
            Graph = graph;
        }

        public List<List<List<TEdgeId>>> PathsList { get; set; }
        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> Graph { get; set; }
    }
}