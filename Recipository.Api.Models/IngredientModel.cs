using Recipository.Domain;

namespace Recipository.Api.Models
{
	public class IngredientModel
	{
		public int IngredientId { get; set; }

		public int Amount { get; set; }

		public Unit Unit { get; set; }
	}
}