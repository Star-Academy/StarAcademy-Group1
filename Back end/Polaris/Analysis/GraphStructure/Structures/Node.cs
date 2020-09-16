// In The Name Of GOD

using Models;

namespace Analysis.GraphStructure.Structures
{
    public class Node<ID, DATA> : Entity<ID>
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
    }
}