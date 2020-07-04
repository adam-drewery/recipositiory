using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Recipository.Entities;

namespace Recipository.Api.Tests
{
	public abstract class ControllerTests
	{
		protected RecipositoryDbContext DbContext { get; }

		public ControllerTests()
		{
			var connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();

			var option = new DbContextOptionsBuilder<RecipositoryDbContext>().UseSqlite(connection).Options;
			DbContext = new RecipositoryDbContext(option);
			DbContext.Database.EnsureCreated();
		}
	}
}