using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Recipository.Api.Client
{
	public class ControllerContext
	{
		private readonly string _controllerName;

		private readonly HttpClient _http;

		public ControllerContext(string controllerName, HttpClient http)
		{
			_controllerName = controllerName;
			_http = http;
		}

		protected async Task<IEnumerable<T>> Get<T>()
		{
			var json = await _http.GetStringAsync(_controllerName);
			return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
		}

		protected async Task Post(object model)
		{
			var json = JsonConvert.SerializeObject(model);
			await _http.PostAsync(_controllerName, new StringContent(json));
		}
	}
}