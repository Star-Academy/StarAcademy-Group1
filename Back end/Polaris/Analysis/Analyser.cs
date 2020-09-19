using System.Collections.Generic;

using Models.Network;
using Models;
using Models.Banking;

namespace Analysis
{
    public class Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData> : IAnalyser<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        public Analyser(GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> graphContainer)
        {
        }

        public MaxFlowResult<TEdgeId> GetMaxFlow(TNodeId source, TNodeId target)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IEnumerable<TEdgeId>> GetPaths(TNodeId source, TNodeId target)
        {
            throw new System.NotImplementedException();
        }
    }
}