// In The Name Of GOD
using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using Elastic.Models;
using Elasticsearch.Net;
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
            Dictionary<NID, bool>[] visited = new Dictionary<NID, bool>[2];
            visited[0] = new Dictionary<NID, bool>();
            visited[1] = new Dictionary<NID, bool>();

            Dictionary<NID, NID>[] parent = new Dictionary<NID, NID>[2];
            parent[0] = new Dictionary<NID, NID>();
            parent[1] = new Dictionary<NID, NID>();

            List<NID>[] queue = new List<NID>[2];
            queue[0] = new List<NID>();
            queue[1] = new List<NID>();

            queue[0].Add(source.Id);
            visited[0][source.Id] = true;

            queue[1].Add(target.Id);
            visited[1][target.Id] = true;

            while (!queue[0].Any() && !queue[1].Any())
            {
                BreadthFirstSearch(ref queue[0], ref visited[0], ref parent[0]);
                BreadthFirstSearch(ref queue[1], ref visited[1], ref parent[1]);

                // should check for a good path :)
            }
        }

        private void BreadthFirstSearch(ref List<NID> queue, ref Dictionary<NID, bool> visited, ref Dictionary<NID, NID> parent)
        {
            while (!queue.Any())
            {
                NID current = queue.First();
                queue.RemoveAt(0);
                if (visited[current])
                    continue;
                var list = graph.GetNeighbors(current);
                foreach (var node in list)
                {
                    if (!visited[node.Id])
                    {
                        parent[node.Id] = current;
                        visited[node.Id] = true;
                        queue.Add(node.Id);
                    }
                }
            }
        }
    }
}