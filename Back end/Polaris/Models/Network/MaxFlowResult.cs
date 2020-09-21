using System;
using System.Collections.Generic;

namespace Models.Network
{
    public class MaxFlowResult<TNodeId, TNodeData, TEdgeId, TEdgeData> : IModel
        where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>, new()
    {
        public Int64 MaxFlowAmount { get; set; }
        public Dictionary<TEdgeId, Int64> EdgeToFlow { get; set; }

        public GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> GraphContainer { get; set; }

        public MaxFlowResult()
        {
            EdgeToFlow = new Dictionary<TEdgeId, long>();
        }

        public MaxFlowResult(long maxFlowAmount, Dictionary<TEdgeId, long> edgeToFlow, GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> container)
        {
            MaxFlowAmount = maxFlowAmount;
            EdgeToFlow = edgeToFlow;
            GraphContainer = container;
        }
    }
}