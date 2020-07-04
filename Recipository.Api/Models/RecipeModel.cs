using System;
using System.Linq.Expressions;
using Recipository.Domain;

namespace Recipository.Api.Models
{
	public class RecipeModel : IEntity, INamed
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public static Expression<Func<Recipe, RecipeModel>> FromRecipe { get; } = recipe =>
			new RecipeModel
			{ // Since entity framework doesn't support constructors in Select queries, this is the closest alternative.
				Id = recipe.Id,
				Name = recipe.Name
			};
	}
}
