// In The Name Of GOD

using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.Analyser
{
    public class BFS<TNodeId, TNodeData, TEdgeId, TEdgeData>
        where TNodeData : Entity<TNodeId>
        where TEdgeData : Entity<TEdgeId>
    {
        private readonly Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph;

        public BFS(Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph)
        {
            this.graph = graph;
        }

        // filters weren't applied yet
        public HashSet<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>> BiDirectionalSearch
            (Node<TNodeId, TNodeData> source, Node<TNodeId, TNodeData> target, Filter filter)
        {
            var edges = new HashSet<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>>();

            var paths = new Dictionary<TNodeId, List<LinkedList<TNodeId>>>[2];
            paths[0] = new Dictionary<TNodeId, List<LinkedList<TNodeId>>>();
            paths[1] = new Dictionary<TNodeId, List<LinkedList<TNodeId>>>();

            foreach (var item in graph.Adj)
            {
                paths[0][item.Key.Id] = new List<LinkedList<TNodeId>>();
                paths[1][item.Key.Id] = new List<LinkedList<TNodeId>>();
            }

            var queue = new List<LinkedList<TNodeId>>[2];
            queue[0] = new List<LinkedList<TNodeId>>();
            queue[1] = new List<LinkedList<TNodeId>>();


            {
                var path = new LinkedList<TNodeId>();
                path.AddLast(source.Id);

                queue[0].Add(path);
                paths[0][source.Id].Add(path);

                var path2 = new LinkedList<TNodeId>();
                path2.AddLast(target.Id);

                queue[1].Add(path2);
                paths[1][target.Id].Add(path2);
            }

            while (queue[0].Any() && queue[1].Any())
            {
                BreadthFirstSearch(ref queue[0], ref paths[0]);
                BreadthFirstSearch(ref queue[1], ref paths[1], 0);
            }

            foreach (var item in graph.Adj)
            {
                if (paths[0][item.Key.Id].Any() && paths[1][item.Key.Id].Any())
                {
                    TakePath(item.Key, ref edges, ref paths);
                }
                paths[0][item.Key.Id].Clear();
                paths[1][item.Key.Id].Clear();
            }

            foreach (var item in edges)
            {
                item.Address = item.Address;
            }

            return edges;
        }
        private void BreadthFirstSearch
            (ref List<LinkedList<TNodeId>> queue, ref Dictionary<TNodeId, List<LinkedList<TNodeId>>> paths, int src = 1)
        {
            var current = queue.First();
            queue.RemoveAt(0);
            var last = current.Last();
            var list = graph.GetNeighbors(last);
            if (src == 0)
                list = graph.GetOpositeNeighbors(last);
            foreach (var node in list)
            {
                if (!current.Contains(node.Id))
                {
                    LinkedList<TNodeId> newPath = new LinkedList<TNodeId>(current);
                    newPath.AddLast(node.Id);
                    if (newPath.Count() > 3 + src) continue;
                    paths[node.Id].Add(newPath);
                    queue.Add(newPath);
                }
            }
        }

        private void TakePath(Node<TNodeId, TNodeData> node, ref HashSet<Edge<TEdgeId, TEdgeData, Node<TNodeId, TNodeData>>> edges, ref Dictionary<TNodeId, List<LinkedList<TNodeId>>>[] paths)
        {
            foreach (var item in paths[0][node.Id])
            {
                bool flag = false;
                int iterator = -1;
                List<int> rm = new List<int>();
                foreach (var item2 in paths[1][node.Id])
                {
                    iterator++;
                    var set = new HashSet<Node<TNodeId, TNodeData>>();
                    foreach (var tmp in item)
                        set.Add(graph.IDToNode[tmp]);
                    foreach (var tmp in item2)
                        set.Add(graph.IDToNode[tmp]);
                    if (set.Count != item.Count + item2.Count - 1)
                        continue;
                    flag = true;
                    rm.Add(iterator);
                    for (int i = item2.Count - 1; i > 0; i--)
                        edges.UnionWith(graph.GetEdges(item2.ElementAt(i), item2.ElementAt(i - 1)));
                }
                if (flag)
                    for (int i = 0; i + 1 < item.Count(); i++)
                        edges.UnionWith(graph.GetEdges(item.ElementAt(i), item.ElementAt(i + 1)));
                rm.Reverse();
                foreach (var tmp in rm)
                    paths[1][node.Id].RemoveAt(tmp);
            }
        }

    }
}