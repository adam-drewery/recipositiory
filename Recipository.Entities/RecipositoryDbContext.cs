using Microsoft.EntityFrameworkCore;
using Recipository.Domain;
using Country = Recipository.Domain.Country;

namespace Recipository.Entities
{
	public class RecipositoryDbContext : DbContext
	{
		public RecipositoryDbContext(DbContextOptions options) :base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Recipe> Recipes { get; set; }

		public DbSet<Country> Countries { get; set; }
	}
}
