using System;
using System.Collections.Generic;

namespace Recipository.Domain
{
	public class Recipe : IEntity, INamed
	{
		public Recipe(string name) => Name = name;

		public Recipe(int id, string name) : this(name) => Id = id;

		public int Id { get; set; }

		/// <summary>The ID of the recipe that this one is derived from.</summary>
		public int? ParentId { get; set; }

		public int? CountryOfOriginId { get; set; }

		public string Name { get; set; }

		public Country CountryOfOrigin { get; set; }

		public ICollection<IngredientQuantity> Ingredients { get; } = new HashSet<IngredientQuantity>();
	}
}
