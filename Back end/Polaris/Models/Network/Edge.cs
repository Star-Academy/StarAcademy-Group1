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
        public Edge(TDataModel data, Int64 flow, int address)
        {
            Data = data;
            Flow = flow;
            Address = address;
        }
        [JsonIgnore]
        public Int64 Flow { get; set; }
        [JsonIgnore]
        public int Address { get; set; }

        public Edge(TDataModel data)
        {
            Data = data;
        }

        public TDataModel Data { get; set; }

        [JsonPropertyName("id")]
        public override TTypeDataId Id
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

        [JsonPropertyName("source")]
        public TTypeSideId Source
        {
            get
            {
                return Data.Source;
            }
            set
            {
                Data.Source = value;
            }
        }

        [JsonPropertyName("target")]
        public TTypeSideId Target
        {
            get
            {
                return Data.Target;
            }
            set
            {
                Data.Target = value;
            }
        }

        [JsonIgnore]
        public Int64 Amount
        {
            get
            {
                return Data.Amount;
            }
            set
            {
                Data.Amount = value;
            }
        }
    }
}