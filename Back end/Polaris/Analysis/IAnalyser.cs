// In The Name Of GOD

using Models;
using Models.Network;
using System.Collections.Generic;

namespace Analysis
{
    public interface IAnalyser<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
         List<List<List<TEdgeId>>> GetPaths(TNodeId source, TNodeId target);

         MaxFlowResult<TEdgeId> GetMaxFlow(TNodeId source, TNodeId target);
    }
}