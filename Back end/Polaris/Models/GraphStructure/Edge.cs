using System.Text.Json.Serialization;

namespace Models.GraphStructure
{
    public class Edge<TTypeSide, TTypeData> : Entity<TTypeData>
    {
        public Edge(AmountedEntity<TTypeData, TTypeSide> data)
        {
            Data = data;
        }

        public AmountedEntity<TTypeData, TTypeSide> Data{get; set;}
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
        public TTypeSide Source
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
        public TTypeSide Target
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

        [JsonIgnore]
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