using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Recipository.Domain;

namespace Recipository.Api.Models
{
	public class RecipeModel : IEntity, INamed
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<IngredientAmountModel> Ingredients { get; set; } = new List<IngredientAmountModel>();

		public static Expression<Func<Recipe, RecipeModel>> FromRecipe { get; } = recipe =>
			new RecipeModel
			{ // Since entity framework doesn't support constructors in Select queries, this is the closest alternative.
				Id = recipe.Id,
				Name = recipe.Name
			};

		public Recipe ToRecipe()
		{
			var recipe = new Recipe(Id, Name);

			foreach (var ingredientModel in Ingredients)
			{
				var quantity = new Quantity(ingredientModel.Amount, ingredientModel.Unit);
				var ingredient = new IngredientQuantity(ingredientModel.IngredientId, quantity);
				recipe.Ingredients.Add(ingredient);
			}

			// Set this to be a new recipe, who's parent is the recipe it is based on.
			recipe.ParentId = recipe.Id;
			recipe.Id = 0;

			return recipe;
		}
	}
}
