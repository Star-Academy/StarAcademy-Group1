using System.Collections.Generic;


namespace Models.Network
{
    public class Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> : IGraph<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        public Dictionary<TNodeData, LinkedList<TNodeData>> Adj { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<TNodeData> Nodes { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<TEdgeData> Edges { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public LinkedList<TNodeData> GetNeighbors(TNodeData node)
        {
            throw new System.NotImplementedException();
        }

        public LinkedList<TNodeData> GetNeighbors(TNodeId nodeId)
        {
            throw new System.NotImplementedException();
        }
    }
}