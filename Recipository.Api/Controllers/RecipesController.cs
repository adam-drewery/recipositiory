using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipository.Api.Models;
using Recipository.Entities;
using Serilog;

namespace Recipository.Api.Controllers
{
	[ApiController]
	public class BaseController : ControllerBase
	{
		protected readonly ILogger Log;
		protected readonly RecipositoryDbContext DbContext;

		public BaseController(RecipositoryDbContext dbContext)
		{
			Log = Serilog.Log.ForContext(GetType());
			DbContext = dbContext;
		}
	}


	[Route("[controller]")]
	public class RecipesController : BaseController
	{
		public RecipesController(RecipositoryDbContext dbContext) : base(dbContext) { }

		[HttpGet]
		public IEnumerable<RecipeModel> Get()
		{
			return DbContext.Recipes.Select(RecipeModel.FromRecipe);
		}
	}
}
