using Elastic.Models;

namespace Analysis.GraphStructure.Structures
{
    public class Edge<T, E, N> : Entity<T>
    where E : Entity<T>
    {
        public E data;
        public override T Id
        {
            get
            {
                return this.data.Id;
            }
            set
            {
                this.data.Id = value;
            }    
        }
        public N Source{get; set;}
        public N Target{get; set;}
    }
}
