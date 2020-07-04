using System;

namespace Recipository.Domain
{
	public class Ingredient : IEntity, INamed
	{
		public Ingredient(string name) => Name = name;

		public Ingredient(int id, string name) : this(name) => Id = id;

		public int Id { get; set; }

		public string Name { get; set; }
	}
}
