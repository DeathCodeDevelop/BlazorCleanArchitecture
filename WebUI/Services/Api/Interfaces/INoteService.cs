using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Services.Api
{
	public interface INoteService
	{
		Task<IEnumerable<NoteViewModel>?> GetAll();
		Task<Guid> Create(CreateNoteViewModel model);
		Task<HttpResponseMessage> Update(UpdateNoteViewModel model);
		Task<HttpResponseMessage> Delete(Guid id);
		Task<NoteViewModel?> GetById(Guid id);
		Task<HttpResponseMessage> DeleteAll();
	}
}
