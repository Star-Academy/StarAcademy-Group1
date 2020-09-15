namespace Models.GraphStructure
{
    public class Node<TTypeData> : Entity<TTypeData>
    {
        public Entity<TTypeData> Data{get; set;}

        public Node(Entity<TTypeData> data)
        {
            Data = data;
        }

        public override TTypeData Id
        {
            get
            {
                return this.Data.Id;
            }
            set
            {
                this.Data.Id = value;
            }    
        }
    }
}