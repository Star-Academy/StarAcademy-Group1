using Models;
using Analysis.GraphStructure.Structures;
using System.Collections.Generic;

namespace Analysis.GraphStructure
{
    public interface IGraph<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : Entity<TEdgeId>
    {
        Dictionary<Node<TNodeId, TNodeData>, List<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>>> Adj { get; set; }

        public void AddEdgeForFlow(Node<TNodeId, TNodeData> u, Node<TNodeId, TNodeData> v, long amount);
        List<Node<TNodeId, TNodeData>> GetNeighbors(TNodeData node);

        List<Node<TNodeId, TNodeData>> GetNeighbors(TNodeId nodeId);
    }
}