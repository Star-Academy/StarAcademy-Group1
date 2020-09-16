// In The Name Of GOD

using Models;
using System;

namespace Analysis.GraphStructure.Structures
{
    public class Edge<ID, DATA, NODE> : Entity<ID>
    where DATA : Entity<ID>
    {
        public Edge()
        {
        }
        public Edge(NODE u, NODE v, int flow, long amount, int address)
        {
            Source = u;
            Target = v;
            Flow = flow;
            Amount = amount;
            Address = address;
        }

        public DATA Data { get; set; }
        public override ID Id
        {
            get
            {
                return Data.Id;
            }
            set
            {
                Data.Id = value;
            }
        }

        public Int64 Amount { get; set; }
        public Int64 Flow { get; set; }

        internal int Address { get; set; }
        public NODE Source { get; set; }
        public NODE Target { get; set; }
    }
}
