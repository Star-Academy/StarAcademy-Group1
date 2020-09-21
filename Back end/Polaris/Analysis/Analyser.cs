// In The Name Of GOD

using Models;
using Models.Network;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.Linq;

namespace Analysis
{
    public class Analyser<TNodeId, TNodeData, TEdgeId, TEdgeData> : IAnalyser<TNodeId, TNodeData, TEdgeId, TEdgeData>
    where TNodeData : Entity<TNodeId>
    where TEdgeData : AmountedEntity<TEdgeId, TNodeId>, new()
    {
        Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph;
        GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> graphContainer;
        public Analyser(GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData> graphContainer)
        {
            this.graphContainer = graphContainer;
            graph = new Graph<TNodeId, TNodeData, TEdgeId, TEdgeData>(graphContainer);
        }

        public MaxFlowResult<TNodeId, TNodeData, TEdgeId, TEdgeData> GetMaxFlow(TNodeId source, TNodeId target)
        {
            var edges = GetPaths(source, target);
            var maxFlowSolver = new MaxFlow<TNodeId, TNodeData, TEdgeId, TEdgeData>(graph, graphContainer.Edges);
            var result = maxFlowSolver.DinicMaxFlow(source, target);
            var edgeSet = new HashSet<Edge<TEdgeData, TEdgeId, TNodeId>>();
            var nodeSet = new HashSet<Node<TNodeData, TNodeId>>();
            foreach (var list in edges)
                foreach (var item in list)
                    foreach (var edge in item)
                    {
                        var tempEdge = graph.EdgeIdToEdge[edge];
                        edgeSet.Add(tempEdge);
                        nodeSet.Add(graph.NodeIdToNode[tempEdge.Source]);
                        nodeSet.Add(graph.NodeIdToNode[tempEdge.Target]);
                    }

            result.GraphContainer = new GraphContainer<TNodeId, TNodeData, TEdgeId, TEdgeData>(nodeSet.ToList(), edgeSet.ToList());
            return result;

        }

        public List<List<List<TEdgeId>>> GetPaths(TNodeId source, TNodeId target, int maxLength = 7)
        {
            var pathFinder = new BFS<TNodeId, TNodeData, TEdgeId, TEdgeData>(graph);
            return pathFinder.BiDirectionalSearch(source, target, maxLength);//filters should be added in here !
        }
    }
}