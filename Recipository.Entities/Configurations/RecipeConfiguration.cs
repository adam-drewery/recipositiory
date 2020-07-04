using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipository.Domain;

namespace Recipository.Entities.Configurations
{
	public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
	{
		private static readonly Recipe[] Defaults =
		{
			new Recipe(1, "Cheesy beans on toast"),
			new Recipe(2, "Chicken Kiev")
		};

		public void Configure(EntityTypeBuilder<Recipe> builder)
		{
			builder.HasData(Defaults);
		}
	}
}
