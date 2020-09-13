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
            var nodes = new HashSet<NID>();
            
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
            parent[0][source.Id] = source.Id;

            queue[1].Add(target.Id);
            visited[1][target.Id] = true;
            parent[1][target.Id] = target.Id;

            while (!queue[0].Any() && !queue[1].Any())
            {
                BreadthFirstSearch(ref queue[0], ref visited[0], ref parent[0]);
                BreadthFirstSearch(ref queue[1], ref visited[1], ref parent[1]);

                var commonNodes = Intersect(ref visited);
                if (commonNodes.Any())
                {
                    foreach (var item in commonNodes)
                        Add(item, ref nodes, source.Id, target.Id, parent);
                }
            }
        }

        private void Add(NID id, ref HashSet<NID> set, NID source, NID target, Dictionary<NID, NID> [] parent)
        {
            NID temp = id;
            while (temp.GetHashCode() != source.GetHashCode())
            {
                set.Add(temp);
                temp = parent[0][temp];
            }

            temp = id;
            while (temp.GetHashCode() != target.GetHashCode())
            {
                set.Add(temp);
                temp = parent[1][temp];
            }
        }

        private List<NID> Intersect(ref Dictionary<NID, bool>[] visited)
        {
            List<NID> ret = new List<NID>();
            foreach (var item in visited[0])
                if (visited[1].ContainsKey(item.Key))
                    ret.Add(item.Key);
            return ret;
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