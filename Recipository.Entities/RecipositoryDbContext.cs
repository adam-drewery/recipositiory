using Microsoft.EntityFrameworkCore;
using Recipository.Domain;
using Country = Recipository.Domain.Country;

namespace Recipository.Entities
{
	public class RecipositoryDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=Recipes.db");

		public DbSet<Recipe> Recipes { get; set; }

		public DbSet<Country> Countries { get; set; }
	}
}
