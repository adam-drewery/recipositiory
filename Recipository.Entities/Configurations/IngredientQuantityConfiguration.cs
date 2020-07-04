using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipository.Domain;

namespace Recipository.Entities.Configurations
{
	public class IngredientQuantityConfiguration : IEntityTypeConfiguration<IngredientQuantity>
	{
		private static readonly IngredientQuantity[] Defaults =
		{
			new IngredientQuantity(1, 1, Quantity.Slices(2)),
			new IngredientQuantity(1, 2, Quantity.Ounces(3)),
			new IngredientQuantity(1, 3, Quantity.Grams(410)),

			new IngredientQuantity(2, 4, Quantity.Chunks(1)),
			new IngredientQuantity(2, 5, Quantity.Cloves(2)),
		};

		public void Configure(EntityTypeBuilder<IngredientQuantity> builder)
		{
			builder.HasKey(nameof(IngredientQuantity.RecipeId), nameof(IngredientQuantity.IngredientId));
			builder.OwnsOne(x => x.Quantity);
		}
	}
}
