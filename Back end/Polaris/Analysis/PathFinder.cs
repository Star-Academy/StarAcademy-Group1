// In The Name Of GOD

using Models;
using Models.Network;
using System.Collections.Generic;
using System.Linq;

namespace Analysis
{
    public class PathFinder<TNodeId, TNodeData, TEdgeId, TEdgeData>
        where TNodeData : Entity<TNodeId>
        where TEdgeData : AmountedEntity<TEdgeId, TNodeId>
    {
        private readonly Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph;

        public PathFinder(Graph<TNodeId, TNodeData, TEdgeId, TEdgeData> graph)
        {
            this.graph = graph;
        }

        // filters weren't applied yet
        public List<List<List<TEdgeId>>> BiDirectionalSearch(TNodeId source, TNodeId target, int maxLength = 7)
        {
            var edges = new HashSet<List<List<TEdgeId>>>();

            var paths = new Dictionary<TNodeId, List<LinkedList<TNodeId>>>[2];
            paths[0] = new Dictionary<TNodeId, List<LinkedList<TNodeId>>>();
            paths[1] = new Dictionary<TNodeId, List<LinkedList<TNodeId>>>();

            foreach (var item in graph.Adj)
            {
                paths[0][item.Key] = new List<LinkedList<TNodeId>>();
                paths[1][item.Key] = new List<LinkedList<TNodeId>>();
            }

            var queue = new List<LinkedList<TNodeId>>[2];
            queue[0] = new List<LinkedList<TNodeId>>();
            queue[1] = new List<LinkedList<TNodeId>>();


            {
                var path = new LinkedList<TNodeId>();
                path.AddLast(source);

                queue[0].Add(path);
                paths[0][source].Add(path);

                var path2 = new LinkedList<TNodeId>();
                path2.AddLast(target);

                queue[1].Add(path2);
                paths[1][target].Add(path2);
            }

            while (queue[0].Any() && queue[1].Any())
            {
                int len = (maxLength + 1) / 2;
                BreadthFirstSearch(ref queue[0], ref paths[0], len);
                BreadthFirstSearch(ref queue[1], ref paths[1], maxLength - len, 0);
            }

            foreach (var item in graph.Adj)
            {
                if (paths[0][item.Key].Any() && paths[1][item.Key].Any())
                {
                    TakePath(item.Key, ref edges, ref paths);
                }
                paths[0][item.Key].Clear();
                paths[1][item.Key].Clear();
            }

            return edges.ToList();
        }
        private void BreadthFirstSearch
            (ref List<LinkedList<TNodeId>> queue, ref Dictionary<TNodeId, List<LinkedList<TNodeId>>> paths, int maxLength, int src = 1)
        {
            var current = queue.First();
            queue.RemoveAt(0);
            var last = current.Last();
            List<TNodeId> list;
            if (src == 1)
                list = graph.GetNeighbors(last);
            else
                list = graph.GetOpositeNeighbors(last);
            foreach (var adjId in list)
            {
                if (!current.Contains(adjId))
                {
                    LinkedList<TNodeId> newPath = new LinkedList<TNodeId>(current);
                    newPath.AddLast(adjId);
                    if (newPath.Count() > maxLength) continue;
                    paths[adjId].Add(newPath);
                    queue.Add(newPath);
                }
            }
        }

        private void TakePath
            (TNodeId nodeId, ref HashSet<List<List<TEdgeId>>> edges, ref Dictionary<TNodeId, List<LinkedList<TNodeId>>>[] paths)
        {
            foreach (var item in paths[0][nodeId])
            {
                int iterator = -1;
                List<int> rm = new List<int>();
                foreach (var item2 in paths[1][nodeId])
                {
                    int difference = item.Count - item2.Count;
                    if (difference < 0 || difference > 1)
                        continue;
                    iterator++;
                    var set = new HashSet<TNodeId>();
                    foreach (var tmp in item)
                        set.Add(tmp);
                    foreach (var tmp in item2)
                        set.Add(tmp);
                    if (set.Count != item.Count + item2.Count - 1)
                        continue;
                    rm.Add(iterator);
                    var pathToAdd = new List<List<TEdgeId>>();
                    for (int i = 0; i + 1 < item.Count(); i++)
                        pathToAdd.Add(graph.GetEdges(item.ElementAt(i), item.ElementAt(i + 1)));
                    for (int i = item2.Count - 1; i > 0; i--)
                        pathToAdd.Add(graph.GetEdges(item2.ElementAt(i), item2.ElementAt(i - 1)));
                    edges.Add(pathToAdd);
                }
                rm.Reverse();
                foreach (var tmp in rm)
                    paths[1][nodeId].RemoveAt(tmp);
            }
        }

    }
}
