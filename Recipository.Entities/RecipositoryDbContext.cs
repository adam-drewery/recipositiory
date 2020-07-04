using System;
using System.Linq;
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

		public override int SaveChanges()
		{
			Audit();
			return base.SaveChanges();
		}

		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			Audit();
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}

		private void Audit()
		{
			var entries = this.ChangeTracker.Entries()
				.Select(e => e.Entity)
				.OfType<IAuditable>();

			foreach (var entry in entries)
				entry.CreatedDate = DateTime.UtcNow;
		}
	}
}
