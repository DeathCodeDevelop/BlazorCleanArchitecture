using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Services.Helpers
{
	public interface ICookiesService
	{
		Task WriteCookieAsync(string name, string value, int days);
		Task<string> GetCookieAsync(string name);
	}
}
