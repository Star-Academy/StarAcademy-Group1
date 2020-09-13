using Analysis.GraphStructure;
using Elastic.Models;

namespace Analysis.Analyser
{
    class MaxFlow<NID, NDATA, EID, EDATA>
        where NDATA : Entity<NID>
        where EDATA : Entity<EID>
    {
        private readonly Graph<NID, NDATA, EID, EDATA> graph;
        public MaxFlow(Graph<NID, NDATA, EID, EDATA> graph)
        {
            this.graph = graph;
        }
    }
}
