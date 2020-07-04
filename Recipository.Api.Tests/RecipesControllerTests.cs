using System;
using System.Linq;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Recipository.Api.Controllers;
using Recipository.Api.Models;
using Recipository.Domain;
using Recipository.Entities;
using Xunit;

namespace Recipository.Api.Tests
{
	public class RecipesControllerTests
	{
		public RecipesControllerTests()
		{
			var connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();

			var option = new DbContextOptionsBuilder<RecipositoryDbContext>().UseSqlite(connection).Options;
			DbContext = new RecipositoryDbContext(option);
			DbContext.Database.EnsureCreated();
			Controller = new RecipesController(DbContext);
		}

		protected RecipositoryDbContext DbContext { get; }

		protected RecipesController Controller { get; }

		public class Get : RecipesControllerTests
		{
			[Fact]
			public void Returns_no_recipes_when_none_exist()
			{
				foreach (var recipe in DbContext.Recipes)
					DbContext.Recipes.Remove(recipe);

				DbContext.SaveChanges();

				var result = Controller.Get();
				result.Should().BeEmpty("because we removed them all from the underlying repository");
			}

			[Fact]
			public void Returns_all_recipes_when_some_exist()
			{
				var result = Controller.Get().ToList();
				result.Count.Should().BeGreaterThan(0);
				result.Should().HaveCount(DbContext.Recipes.Count());
			}
		}

		public class Post : RecipesControllerTests
		{
			[Fact]
			public void Adds_a_new_version_of_a_recipe()
			{
				// Get any old recipe from the repository and update it.
				var recipeModel = DbContext.Recipes.Select(RecipeModel.FromRecipe).First();
				var originalCount = DbContext.Recipes.Count();
				recipeModel.Name += " (improved version)";

				// Improve this recipe with CHEESE.
				var cheese = new IngredientModel {Amount = 500, Unit = Unit.Grams, IngredientId = 2};
				recipeModel.Ingredients.Add(cheese);
				Controller.Post(recipeModel);

				DbContext.Recipes.Count().Should().Be(originalCount + 1);
			}
		}
	}
}
