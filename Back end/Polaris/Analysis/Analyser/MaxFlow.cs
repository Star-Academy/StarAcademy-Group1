using Analysis.GraphStructure;
using Elastic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analysis.Analyser
{
    class MaxFlow<NID, NDATA, EID, EDATA>
        where NDATA : Entity<NID>
        where EDATA : Entity<EID>
    {

        private const Int64 inf = 1_000_000_000_000_000_000;

        private readonly Graph<NID, NDATA, EID, EDATA> graph;
        private Dictionary<NID, int> level;
        public MaxFlow(Graph<NID, NDATA, EID, EDATA> graph)
        {
            this.graph = graph;
            level = new Dictionary<NID, int>();
        }

        public int DinicMaxFlow(NID source, NID target)
        {
            if (source.Equals(target))
                return -1;

            Int64 result = 0;

            while (BFS(source, target))
            {
                var start = new Dictionary<NID, int>();

                {
                    Int64 flow = 0;
                    do
                    {
                        flow = SendFlow(source, inf, target, start);
                        result += flow;
                    } while (flow > 0);
                }
            }

            return 0;
        }

        private int SendFlow(NID source, Int64 flow, NID target, Dictionary<NID, int> start)
        {
            return 0;
        }


        private bool BFS(NID source, NID target)
        {
            foreach (var item in graph.Adj)
                level[item.Key.Id] = -1;

            level[source] = 0;
            var q = new List<NID>();
            q.Add(source);

            while (q.Any())
            {
                var node = graph.IDToNode[q.Last()];
                q.RemoveAt(q.Count - 1);
                foreach(var edge in graph.Adj[node])
                {
                    var neighbor = edge.Target.Id;
                    if (level[neighbor] < 0 && edge.Flow < edge.Amount)
                    {
                        level[neighbor] = level[node.Id] + 1;
                        q.Add(neighbor);
                    }
                }
            }

            return level[target] != -1;
        }

    }
}
