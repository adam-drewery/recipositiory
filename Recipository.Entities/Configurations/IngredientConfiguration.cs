using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipository.Domain;

namespace Recipository.Entities.Configurations
{
	public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
	{
		private static readonly Ingredient[] Defaults =
		{
			new Ingredient(1, "Bread"),
			new Ingredient(2, "Cheese"),
			new Ingredient(3, "Beans"),
			new Ingredient(4, "Chicken"),
			new Ingredient(5, "Garlic"),
		};

		public void Configure(EntityTypeBuilder<Ingredient> builder)
		{
			builder.HasData(Defaults);
		}
	}
}
