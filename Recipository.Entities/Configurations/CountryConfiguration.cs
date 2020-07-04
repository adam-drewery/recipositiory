using System.Linq;
using Audacia.Locality;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Country = Recipository.Domain.Country;

namespace Recipository.Entities.Configurations
{
	public class CountryConfiguration : IEntityTypeConfiguration<Country>
	{
		public static Country[] Defaults { get; } = GetDefaults();

		private static Country[] GetDefaults()
		{
			var id = 0;
			return World.Countries.Select(c =>
			{
				id++;
				return new Country(id, c.Name);
			}).ToArray();
		}

		public void Configure(EntityTypeBuilder<Country> builder)
		{

			builder.HasData(Defaults);
		}
	}
}
