using System;
using System.Text.Json.Serialization;

namespace Models.Network
{
    public class Edge<TDataModel, TTypeDataId, TTypeSideId> : Entity<TTypeDataId>
    where TDataModel : AmountedEntity<TTypeDataId, TTypeSideId>
    {
        public Edge()
        {
        }
        public Edge(TTypeSideId u, TTypeSideId v, Int64 flow, long amount, int address)
        {
            Source = u;
            Target = v;
            Flow = flow;
            Amount = amount;
            Address = address;
        }
        [JsonIgnore]
        public Int64 Flow { get; set; }
        [JsonIgnore]
        internal int Address { get; set; }



        public Edge(TDataModel data)
        {
            Data = data;
        }

        public TDataModel Data{get; set;}

        [JsonPropertyName("id")]
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

        [JsonPropertyName("source")]
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
        
        [JsonPropertyName("target")]
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

        [JsonPropertyName("amount")]
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