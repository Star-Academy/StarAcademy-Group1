namespace Models.Network
{
    public class Node<TDataModel, TTypeDataId> : Entity<TTypeDataId>
    where TDataModel : Entity<TTypeDataId>
    {
        public TDataModel Data{get; set;}

        public Node()
        {
        }

        public Node(TDataModel data)
        {
            Data = data;
        }

        public override TTypeDataId Id
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