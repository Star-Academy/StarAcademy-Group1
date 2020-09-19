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
        Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph;
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> graphContainer;
        public Analyser(GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> graphContainer)
        {
            this.graphContainer = graphContainer;
            graph = new Graph<TNodeId, TNodeData, TEdgeId, TEdgeData>(graphContainer);
        }

        public MaxFlowResult<TEdgeId> GetMaxFlow(TNodeId source, TNodeId target)
        {
            var maxFlowSolver = new MaxFlow<TNodeId, TNodeData, TEdgeId, TEdgeData>(graphContainer);
            throw new System.NotImplementedException();

        }

        public List<List<List<TEdgeId>>> GetPaths(TNodeId source, TNodeId target)
        {
            var pathFinder = new BFS<TNodeId, TNodeData, TEdgeId, TEdgeData>(graph);
            return pathFinder.BiDirectionalSearch(source, target);//filters should be added in here !
        }
    }
}