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
			this.httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImQ1ODNjMTlkLThhMTUtNDNjOC04ZjU1LTZmZWM3OWNiZWI1ZiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJzdHJpbmciLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJzdHJpbmciLCJleHAiOjE2NTc5MzM5NDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUyMDAvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTIwMC8ifQ.x1DEHOVtBwEDxLCrRsY6jj7XHb7rqDXroxWg9GpfwE8");
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
