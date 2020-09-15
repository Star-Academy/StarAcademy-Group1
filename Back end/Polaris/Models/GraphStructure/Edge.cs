using System.Text.Json.Serialization;

namespace Models.GraphStructure
{
    public class Edge<TDataModel, TTypeSideId, TTypeDataId> : Entity<TTypeDataId>
    where TDataModel : AmountedEntity<TTypeDataId, TTypeSideId>
    {
        public Edge()
        {   
        }
        
        public Edge(AmountedEntity<TTypeDataId, TTypeSideId> data)
        {
            Data = data;
        }

        public AmountedEntity<TTypeDataId, TTypeSideId> Data{get; set;}

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

        public TTypeSideId Source
        {
            get
            {
                return this.Data.Source;
            }
            set
            {
                this.Data.Source = value;
            }
        }
        public TTypeSideId Target
        {
            get
            {
                return this.Data.Target;
            }
            set
            {
                this.Data.Target = value;
            }
        }

        public double Amount
        {
            get
            {
                return this.Data.Amount;
            }
            set
            {
                this.Data.Amount = value;
            }
        }
    }
}