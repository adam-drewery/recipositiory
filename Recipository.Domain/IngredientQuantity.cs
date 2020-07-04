namespace Recipository.Domain
{
	public class IngredientQuantity
	{
		public IngredientQuantity() { }

		public IngredientQuantity(int ingredientId, Quantity quantity)
		{
			IngredientId = ingredientId;
			Quantity = quantity;
		}

		public int IngredientId { get; set; }

		public Ingredient Ingredient { get; set; }

		public Quantity Quantity { get; set; }
	}
}
