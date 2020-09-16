using System;
using System.Text.Json.Serialization;

namespace Models
{
    public abstract class AmountedEntity<TAmountedEntityId, TSideEntityId> : Entity<TAmountedEntityId>
    {
        public AmountedEntity(TSideEntityId source, TSideEntityId target, Int64 amount)
        {
            Source = source;
            Target = target;
            Amount = amount;
        }

        public AmountedEntity()
        {

        }

        [JsonPropertyName("source")]
        public virtual TSideEntityId Source { get; set; }

        [JsonPropertyName("target")]
        public virtual TSideEntityId Target { get; set; }
        
        [JsonPropertyName("amount")]
        public virtual Int64 Amount { get; set; }
    }
}