namespace Recipository.Domain
{
	public class IngredientQuantity
	{
		public IngredientQuantity() { }

		public IngredientQuantity(int recipeId, int ingredientId, Quantity quantity)
		: this(ingredientId, quantity)
		{
			RecipeId = recipeId;
		}

		public IngredientQuantity(int ingredientId, Quantity quantity)
		{
			IngredientId = ingredientId;
			Quantity = quantity;
		}

		public int RecipeId { get; set; }

		public int IngredientId { get; set; }

		public Ingredient Ingredient { get; set; }

		public Recipe Recipe { get; set; }

		public Quantity Quantity { get; set; }
	}
}
