// In The Name Of GOD
using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using Elastic.Models;
using Elasticsearch.Net;
using Nest;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.Analyser
{
    class BFS<NID, NDATA, EID, EDATA>
        where NDATA : Entity<NID>
        where EDATA : Entity<EID>
    {
        private readonly Graph<NID, NDATA, EID, EDATA> graph;

        public BFS(Graph<NID, NDATA, EID, EDATA> graph)
        {
            this.graph = graph;
        }

        public void BiDirectionalSearch(Node<NID, NDATA> source, Node<NID, NDATA> target, Filter filter)
        {
            var edges = new HashSet<Edge<EID, EDATA, Node<NID, NDATA>>>();

            Dictionary<NID, List<LinkedList<NID>>>[] paths = new Dictionary<NID, List<LinkedList<NID>>>[2];
            paths[0] = new Dictionary<NID, List<LinkedList<NID>>>();
            paths[1] = new Dictionary<NID, List<LinkedList<NID>>>();

            List<LinkedList<NID>>[] queue = new List<LinkedList<NID>>[2];
            queue[0] = new List<LinkedList<NID>>();
            queue[1] = new List<LinkedList<NID>>();

            LinkedList<NID> path = new LinkedList<NID>();
            path.AddLast(source.Id);

            queue[0].Add(path);
            paths[0][source.Id].Add(path);

            path.Clear();
            path.AddLast(target.Id);

            queue[1].Add(path);
            paths[1][target.Id].Add(path);

            while (!queue[0].Any() && !queue[1].Any())
            {
                BreadthFirstSearch(ref queue[0], ref paths[0]);
                BreadthFirstSearch(ref queue[1], ref paths[1], 0);
            }

            foreach (var item in graph.Adj)
            {
                if (paths[0][item.Key.Id].Any() && paths[1][item.Key.Id].Any())
                {
                    TakePath(item.Key, ref edges);
                } 
            }
        }

        private void TakePath(Node<NID, NDATA> node, ref HashSet<Edge<EID, EDATA, Node<NID, NDATA>>> edges)
        {

        }

        private void BreadthFirstSearch(ref List<LinkedList<NID>> queue, ref Dictionary<NID, List<LinkedList<NID>>> paths, int src = 1)
        {
            while (!queue.Any())
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
                        LinkedList<NID> newPath = current;
                        newPath.AddLast(node.Id);
                        if (newPath.Count() > 3 + src) continue;
                        paths[node.Id].Add(newPath);
                        queue.Add(newPath);
                    }
                }
            }
        }
    }
}