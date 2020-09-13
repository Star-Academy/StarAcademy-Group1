// In The Name Of GOD

using System.Text.Json.Serialization;

namespace Elastic.Models
{
    public abstract class Entity<TYPE>
    {
		[JsonPropertyName("id")] //TODO: "id" should get checked
		public virtual TYPE Id { get; set; }

		public override bool Equals(object obj)
		{
			return obj is Entity<TYPE> other && Id.Equals(other.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}
	}
}
