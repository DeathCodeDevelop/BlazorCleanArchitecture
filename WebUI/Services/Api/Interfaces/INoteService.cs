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
		Task<IEnumerable<GetAllNoteViewModel>?> GetAll();
		Task<Guid> Create(CreateNoteViewModel model);
		Task<HttpResponseMessage> Update(UpdateNoteViewModel model);
		Task<HttpResponseMessage> Delete(Guid guid);
		Task<GetAllNoteViewModel?> GetById(Guid guid);
	}
}
