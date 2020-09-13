using System.Text.Json.Serialization;

namespace Models
{
    public abstract class AmountedEntity<TAmountedEntityId, TSideEntityId> : Entity<TAmountedEntityId>, IModel
    {
        [JsonPropertyName("source")]
        public virtual TSideEntityId Source
        { get; set; }
        [JsonPropertyName("target")]
        public virtual TSideEntityId Target { get; set; }
        [JsonPropertyName("amount")]
        public virtual double Amount { get; set; }
    }
}