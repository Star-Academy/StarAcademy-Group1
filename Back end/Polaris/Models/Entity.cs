using System.Text.Json.Serialization;

namespace Models
{
    public abstract class Entity<T> : IModel
    {
		[JsonPropertyName("id")] //TODO: "id" should get checked
		public virtual T Id { get; set; }

		public override bool Equals(object obj)
		{
			return obj is Entity<T> other && Id.Equals(other.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
