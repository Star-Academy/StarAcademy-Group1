// In The Name Of GOD

using Models;
using Models.Network;
using System.Collections.Generic;

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

        public List<List<TEdgeId>> GetPaths(TNodeId source, TNodeId target)
        {
            throw new System.NotImplementedException();
        }
    }
}