// In The Name Of GOD

using Elastic.Models;

namespace Analysis.GraphStructure.Structures
{
    public class Edge<ID, DATA, NODE> : Entity<ID>
    where DATA : Entity<ID>
    {
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
        public NODE Source { get; set; }
        public NODE Target { get; set; }
    }
}
