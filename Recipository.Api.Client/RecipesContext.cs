using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Recipository.Api.Models;

namespace Recipository.Api.Client
{
	public class RecipesContext : ControllerContext
	{
		public RecipesContext(string name, HttpClient http) : base(name, http) { }

		public Task<IEnumerable<RecipeModel>> List() => Get<RecipeModel>();

		public Task Update(RecipeModel model) => Post(model);
	}
}