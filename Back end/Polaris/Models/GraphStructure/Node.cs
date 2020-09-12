namespace Models.GraphStructure
{
    public class Node<T, E> : Entity<T>
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
    }
}