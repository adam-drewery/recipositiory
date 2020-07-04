using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipository.Domain;

namespace Recipository.Entities.Configurations
{
	public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
	{
		private static readonly Recipe[] Defaults =
		{
			new Recipe("Cheesy beans on toast")
			{
				Ingredients =
				{
					new IngredientQuantity(1, Quantity.Slices(2)),
					new IngredientQuantity(2, Quantity.Ounces(3)),
					new IngredientQuantity(3, Quantity.Grams(410)),
				}
			},

			new Recipe("Chicken Kiev")
			{
				Ingredients =
				{
					new IngredientQuantity(4, Quantity.Chunks(1)),
					new IngredientQuantity(5, Quantity.Cloves(2)),
				}
			},
		};

		public void Configure(EntityTypeBuilder<Recipe> builder)
		{
			builder.HasData(Defaults);
		}
	}
}
