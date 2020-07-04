using System;
using System.Net.Http;

namespace Recipository.Api.Client
{
	public class RecipositoryApiClient : IDisposable
	{
		// The API client uses its own HttpClient instance because HttpClient is not stateless and we don't want other things messing with it.
		private HttpClient _http;

		public RecipositoryApiClient(Uri baseAddress)
		{
			_http = new HttpClient { BaseAddress = baseAddress };

			Recipes = new RecipesContext("recipes", _http);
		}

		public RecipesContext Recipes { get; }

		public void Dispose()
		{
			_http?.Dispose();
		}
	}
}
