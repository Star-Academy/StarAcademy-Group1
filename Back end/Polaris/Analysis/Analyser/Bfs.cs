// In The Name Of GOD
using Analysis.GraphStructure;
using Analysis.GraphStructure.Structures;
using Elastic.Models;
using Elasticsearch.Net;
using System.Collections.Generic;

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


        }
    }
}