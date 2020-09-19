using System.Collections.Generic;

using Models.Network;
using Models;
using Models.Banking;

namespace Analysis
{
    public interface IAnalyser<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
         IEnumerable<IEnumerable<TEdgeId>> GetPaths(TNodeId source, TNodeId target);

         MaxFlowResult<TEdgeId> GetMaxFlow(TNodeId source, TNodeId target);
    }
}