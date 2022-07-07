using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Services.Api
{
	public class NoteService : INoteService
	{
		private readonly HttpClient httpClient;

		public NoteService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<Guid> Create(CreateNoteViewModel model)
		{
			using var response = await httpClient.PostAsJsonAsync("api/note/create", model);
			return await response.Content.ReadFromJsonAsync<Guid>();
		}

		public async Task<IEnumerable<GetAllNoteViewModel>?> GetAll()
		{
			return await httpClient.GetFromJsonAsync<GetAllNoteViewModel[]>("api/note/getall");
		}

		public async Task<HttpResponseMessage> Update(UpdateNoteViewModel model)
		{
			return await httpClient.PutAsJsonAsync("api/note/update", model);
		}

		public async Task<HttpResponseMessage> Delete(Guid guid)
		{
			string? delete = "api/note/delete/" + guid.ToString();
			return await httpClient.DeleteAsync(delete);
		}

        public async Task<GetAllNoteViewModel?> GetById(Guid guid)
        {
			string? getById = "api/note/GetById/" + guid.ToString();
			return await httpClient.GetFromJsonAsync<GetAllNoteViewModel>(getById);
		}
    }
}
