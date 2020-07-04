using Microsoft.AspNetCore.Mvc;
using Recipository.Entities;
using Serilog;

namespace Recipository.Api.Controllers
{
	[ApiController]
	public class BaseController : ControllerBase
	{
		protected readonly ILogger Log;
		protected readonly RecipositoryDbContext DbContext;

		public BaseController(RecipositoryDbContext dbContext)
		{
			Log = Serilog.Log.ForContext(GetType());
			DbContext = dbContext;
		}
	}
}