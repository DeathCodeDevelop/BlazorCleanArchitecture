using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Services.Api.Interfaces;

namespace WebUI.Services.Api
{
	[Authorize]
	public class NoteService : INoteService
	{
		private readonly HttpClient httpClient;

		public NoteService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<Guid> Create(CreateNoteViewModel model)
		{
			var response = await httpClient.PostAsJsonAsync("api/note/create", model);
			return await response.Content.ReadFromJsonAsync<Guid>();
		}

		public async Task<IEnumerable<NoteViewModel>?> GetAll()
		{
			return await httpClient.GetFromJsonAsync<NoteViewModel[]>("api/note/getAll");
		}

		public async Task<HttpResponseMessage> Update(UpdateNoteViewModel model)
		{
			return await httpClient.PutAsJsonAsync("api/note/update", model);
		}

		public async Task<HttpResponseMessage> Delete(Guid id)
		{
			string? delete = "api/note/delete/" + id.ToString();
			return await httpClient.DeleteAsync(delete);
		}

		public async Task<HttpResponseMessage> DeleteAll()
		{
			string? delete = "api/note/deleteAll/";
			return await httpClient.DeleteAsync(delete);
		}

		public async Task<NoteViewModel?> GetById(Guid id)
		{
			string? getById = "api/note/getById/" + id.ToString();
			return await httpClient.GetFromJsonAsync<NoteViewModel>(getById);
		}
	}
}
