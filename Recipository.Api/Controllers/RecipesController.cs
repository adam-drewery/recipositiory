using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipository.Api.Models;
using Recipository.Entities;

namespace Recipository.Api.Controllers
{
	[Route("[controller]")]
	public class RecipesController : BaseController
	{
		public RecipesController(RecipositoryDbContext dbContext) : base(dbContext) { }

		[HttpGet]
		public IEnumerable<RecipeModel> Get()
		{
			return DbContext.Recipes.Select(RecipeModel.FromRecipe);
		}

		[HttpPost]
		public async Task Post(RecipeModel model)
		{
			var recipe = model.ToRecipe();

			//
			recipe.ParentId = recipe.Id;
			recipe.Id = 0;

			DbContext.Recipes.Add(recipe);
			await DbContext.SaveChangesAsync();
		}
	}

}
