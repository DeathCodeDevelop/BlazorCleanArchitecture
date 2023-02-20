using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Services.Helpers.Interfaces;

namespace WebUI.Services.Helpers
{
	public class TheameService : ITheameService
	{
		private readonly ILocalStorageService _localStorage;
		public bool IsDarkTheame 
		{
			get { return GetIsDarkTheame(); }
			set 
			{
				ChangeTheame(value);
			}
		}

		public TheameService(ILocalStorageService localStorage)
		{
			_localStorage = localStorage;
		}

		public void ChangeTheame(bool value)
		{
			_localStorage.SetItemAsync<bool>("IsDarkTheame", value);
		}

		public bool GetIsDarkTheame()
		{
			return _localStorage.GetItemAsync<bool>("IsDarkTheame").Result;
		}
	}
}
