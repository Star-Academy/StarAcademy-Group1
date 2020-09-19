using System.Collections.Generic;

namespace Models.Network
{
    public class GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        public GraphContainer(List<TNodeData> nodes, List<TEdgeData> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }

        List<TNodeData> Nodes { get; set; }
        List<TEdgeData> Edges { get; set; }
    }
}