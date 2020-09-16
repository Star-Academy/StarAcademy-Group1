using System.Text.Json.Serialization;

namespace Models
{
    public abstract class Entity<TId> : IModel
    {
		[JsonPropertyName("id")] //TODO: "id" should get checked
		public virtual TId Id { get; set; }

		public override bool Equals(object obj)
		{
			return obj is Entity<TId> other && Id.Equals(other.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
