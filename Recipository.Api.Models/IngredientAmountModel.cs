using System;
using System.Linq.Expressions;
using Recipository.Domain;

namespace Recipository.Api.Models
{
	public class IngredientAmountModel
	{
		public int IngredientId { get; set; }

		public int Amount { get; set; }

		public Unit Unit { get; set; }
	}

	public class IngredientModel : IEntity, INamed
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public static Expression<Func<Ingredient,IngredientModel>> FromIngredient { get; } = ingredient =>
			new IngredientModel
			{
				Id = ingredient.Id,
				Name = ingredient.Name
			};

		public Ingredient ToIngredient() => new Ingredient(Id, Name);
	}
}
