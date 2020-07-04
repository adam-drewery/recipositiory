using System;
using System.Linq;
using FluentAssertions;
using Recipository.Api.Controllers;
using Recipository.Api.Models;
using Recipository.Domain;
using Xunit;

namespace Recipository.Api.Tests
{
	public class IngredientsControllerTests : ControllerTests
	{
		protected IngredientsController Controller { get; }

		public IngredientsControllerTests()
		{
			Controller = new IngredientsController(DbContext);
		}

		public class Get : IngredientsControllerTests
		{
			[Fact]
			public void Returns_no_ingredients_when_none_exist()
			{
				// Remove all recipes first
				foreach (var recipe in DbContext.Recipes)
					DbContext.Recipes.Remove(recipe);

				foreach (var ingredient in DbContext.Ingredients)
					DbContext.Ingredients.Remove(ingredient);

				DbContext.SaveChanges();

				var result = Controller.Get();
				result.Should().BeEmpty("because we removed them all from the underlying repository");
			}

			[Fact]
			public void Returns_all_ingredients_when_some_exist()
			{
				var result = Controller.Get().ToList();
				result.Count.Should().BeGreaterThan(0);
				result.Should().HaveCount(DbContext.Ingredients.Count());
			}
		}

		public class Post : IngredientsControllerTests
		{
			[Fact]
			public void Adds_a_new_ingredient()
			{
				var originalCount = DbContext.Ingredients.Count();
				var ingredient = new IngredientModel { Name = "Paprika" };
				Controller.Post(ingredient);

				DbContext.Ingredients.Count().Should().Be(originalCount + 1);
			}
		}

		public class Put : IngredientsControllerTests
		{
			[Fact]
			public void Updates_an_ingredient()
			{
				var originalCount = DbContext.Ingredients.Count();
				var ingredientModel = DbContext.Ingredients.Select(IngredientModel.FromIngredient).First();
				ingredientModel.Name += " (limited edition)";
				Controller.Post(ingredientModel);

				DbContext.Ingredients.Count().Should().Be(originalCount);
				DbContext.Ingredients.Should().ContainSingle(ingredient => ingredient.Name.EndsWith("(limited edition)"));
			}
		}
	}
}
