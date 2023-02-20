using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Services.Api.Interfaces
{
	public interface IAuthorizeService
	{
		Task<bool> LoginAsync(LoginViewModel model);
		Task<bool> RegisterAsync(RegisterViewModel model);
		Task LogoutAsync();
		Task<string?> GetTokenAsync(LoginViewModel model);
	}
}
