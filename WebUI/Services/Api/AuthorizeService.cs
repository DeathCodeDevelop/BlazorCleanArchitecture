using Blazored.LocalStorage;
using Data.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Services.Api.Interfaces;

namespace WebUI.Services.Api
{
	public class AuthorizeService : IAuthorizeService
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		private readonly ILocalStorageService _localStorage;

		public AuthorizeService(HttpClient httpClient, 
			AuthenticationStateProvider authenticationStateProvider,
			ILocalStorageService localStorage)
		{
			_httpClient = httpClient;
			_authenticationStateProvider = authenticationStateProvider;
			_localStorage = localStorage;
		}


		public async Task<bool> LoginAsync(LoginViewModel model)
		{
			var token = await GetTokenAsync(model);

			if (token == null)
				return false;

			await _localStorage.SetItemAsync<string>("token", token);
			await _authenticationStateProvider.GetAuthenticationStateAsync();

			return true;
		}

		public async Task<string?> GetTokenAsync(LoginViewModel model) 
		{
			var response = await _httpClient.PostAsJsonAsync("api/account/login/", model);
			return await response.Content.ReadAsStringAsync();
		}

		public async Task LogoutAsync()
		{
			await _localStorage.RemoveItemAsync("token");
			await _authenticationStateProvider.GetAuthenticationStateAsync();
		}

		public async Task<bool> RegisterAsync(RegisterViewModel model)
		{
			var response = await _httpClient.PostAsJsonAsync("api/account/register/", model);

			if (response.IsSuccessStatusCode) 
			{
				var login = new LoginViewModel()
				{
					UserName = model.UserName,
					Password = model.Password
				};

				return await LoginAsync(login);
			}

			return false;
		}
	}
}
