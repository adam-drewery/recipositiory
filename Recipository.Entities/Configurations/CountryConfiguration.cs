using System.Linq;
using Audacia.Locality;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Country = Recipository.Domain.Country;

namespace Recipository.Entities.Configurations
{
	public class CountryConfiguration : IEntityTypeConfiguration<Country>
	{
		public void Configure(EntityTypeBuilder<Country> builder)
		{
			var id = 0;
			var countries = World.Countries.Select(c =>
			{
				id++;
				return new Country(id, c.Name);
			});
			builder.HasData(countries);
		}
	}
}
