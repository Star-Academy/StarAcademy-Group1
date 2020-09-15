// In The Name Of GOD
using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using Elastic.Models;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.Analyser
{
    public class BFS<NID, NDATA, EID, EDATA>
        where NDATA : Entity<NID>
        where EDATA : Entity<EID>
    {
        private readonly Graph<NID, NDATA, EID, EDATA> graph;

        public BFS(Graph<NID, NDATA, EID, EDATA> graph)
        {
            this.graph = graph;
        }

        // filters weren't applied yet
        public HashSet<Edge<EID, EDATA, Node<NID, NDATA>>> BiDirectionalSearch
            (Node<NID, NDATA> source, Node<NID, NDATA> target, Filter filter)
        {
            var edges = new HashSet<Edge<EID, EDATA, Node<NID, NDATA>>>();

            var paths = new Dictionary<NID, List<LinkedList<NID>>>[2];
            paths[0] = new Dictionary<NID, List<LinkedList<NID>>>();
            paths[1] = new Dictionary<NID, List<LinkedList<NID>>>();

            foreach (var item in graph.Adj)
            {
                paths[0][item.Key.Id] = new List<LinkedList<NID>>();
                paths[1][item.Key.Id] = new List<LinkedList<NID>>();
            }

            var queue = new List<LinkedList<NID>>[2];
            queue[0] = new List<LinkedList<NID>>();
            queue[1] = new List<LinkedList<NID>>();


            {
                var path = new LinkedList<NID>();
                path.AddLast(source.Id);

                queue[0].Add(path);
                paths[0][source.Id].Add(path);

                var path2 = new LinkedList<NID>();
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
            }

            foreach(var item in edges)
            {
                item.Address = item.Address;
            }

            return edges;
        }
        private void BreadthFirstSearch
            (ref List<LinkedList<NID>> queue, ref Dictionary<NID, List<LinkedList<NID>>> paths, int src = 1)
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
                    LinkedList<NID> newPath = new LinkedList<NID>(current);
                    newPath.AddLast(node.Id);
                    if (newPath.Count() > 3 + src) continue;
                    paths[node.Id].Add(newPath);
                    queue.Add(newPath);
                }
            }
        }

        private void TakePath(Node<NID, NDATA> node, ref HashSet<Edge<EID, EDATA, Node<NID, NDATA>>> edges, ref Dictionary<NID, List<LinkedList<NID>>>[] paths)
        {
            foreach (var item in paths[0][node.Id])
            {
                foreach(var item2 in paths[1][node.Id])
                {
                    var set = new HashSet<Node<NID, NDATA>>();
                    foreach (var tmp in item)
                        set.Add(graph.IDToNode[tmp]);
                    foreach (var tmp in item2)
                        set.Add(graph.IDToNode[tmp]);
                    if (set.Count != item.Count + item2.Count - 1) 
                        continue;
                    for (int i = 0; i + 1 < item.Count(); i++)
                        edges.UnionWith(graph.GetEdges(item.ElementAt(i), item.ElementAt(i + 1)));
                    for (int i = item2.Count - 1; i > 0; i--)
                        edges.UnionWith(graph.GetEdges(item2.ElementAt(i), item2.ElementAt(i - 1)));
                }
            }
        }

    }
}