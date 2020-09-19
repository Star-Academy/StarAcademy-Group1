using System.Collections.Generic;

namespace Models.Network
{
    public class GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        public GraphContainer(List<Node<TNodeData, TNodeId>> nodes, List<Edge<TEdgeData, TEdgeId, TNodeId>> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }

        List<Node<TNodeData, TNodeId>> Nodes { get; set; }
        List<Edge<TEdgeData, TEdgeId, TNodeId>> Edges { get; set; }
    }
}