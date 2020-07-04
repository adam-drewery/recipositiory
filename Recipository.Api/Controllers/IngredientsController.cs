using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipository.Api.Models;
using Recipository.Domain.Extensions;
using Recipository.Entities;

namespace Recipository.Api.Controllers
{
	[Route("[controller]")]
	public class IngredientsController : BaseController
	{
		public IngredientsController(RecipositoryDbContext dbContext) : base(dbContext) { }

		[HttpGet]
		public IEnumerable<IngredientModel> Get()
		{
			return DbContext.Ingredients.Select(IngredientModel.FromIngredient);
		}

		[HttpPost]
		public async Task Post(IngredientModel model)
		{
			var ingredient = model.ToIngredient();
			DbContext.Ingredients.Add(ingredient);

			await DbContext.SaveChangesAsync();
		}

		[HttpPut]
		public async Task Put(IngredientModel model)
		{
			var ingredient = model.ToIngredient();
			DbContext.Ingredients.Update(ingredient);

			await DbContext.SaveChangesAsync();
		}
	}

}
