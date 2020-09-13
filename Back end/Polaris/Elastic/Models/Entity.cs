using System.Text.Json.Serialization;

namespace Elastic.Models
{
    public abstract class Entity<TType>
    {
        [JsonPropertyName("id")] //TODO: "id" should get checked
        public virtual TType Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Entity<TType> other && Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
