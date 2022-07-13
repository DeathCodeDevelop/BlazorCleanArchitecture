
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Services.Helpers
{
	public class CookiesService : ICookiesService
	{
		readonly IJSRuntime JSRuntime;

		public CookiesService(IJSRuntime jsRuntime)
		{
			this.JSRuntime = jsRuntime;
		}

		public async Task WriteCookieAsync(string name, string value, int days)
		{
			await JSRuntime.InvokeAsync<object>("writeLocalStorage", name, value, days);
		}

		public async Task<string> GetCookieAsync(string name) 
		{
			return await JSRuntime.InvokeAsync<string>("readLocalStorage", name);
		}
	}
}
