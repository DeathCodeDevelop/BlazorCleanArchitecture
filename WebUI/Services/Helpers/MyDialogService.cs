using Data.ViewModels;
using MudBlazor;
using WebUI.Pages;

namespace WebUI.Services.Helpers
{
	public class MyDialogService : IMyDialogService
	{
		private IDialogService DialogService { get; set; }

		public MyDialogService(IDialogService dialogService)
		{
			DialogService = dialogService;
		}

		public async Task<bool> Confirm(string text)
		{
			if (DialogService != null)
			{
				var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };

				var parameters = new DialogParameters();
				parameters.Add("Text", text);

				var dialog = DialogService.Show<ConfirmDialog>("Confirm", parameters, options);
				var result = await dialog.Result;

				if (!result.Cancelled)
					return true;
			}
			return false;
		}

		public async Task<CreateNoteViewModel?> CreateNote()
		{
			if (DialogService != null)
			{
				var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };

				var dialog = DialogService.Show<CreateNoteDialog>("Create Note", options);
				var result = await dialog.Result;

				if (!result.Cancelled)
					if (result.Data is CreateNoteViewModel)
						return result.Data as CreateNoteViewModel;
			}
			return null;
		}

		public async Task<T?> Create<T>(Type dialog) where T : class
		{
			if (DialogService != null)
			{
				var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };

				var result = await DialogService.Show(dialog, "", options).Result;

				if (!result.Cancelled)
					if (result.Data is T)
						return result.Data as T;
			}
			return null;
		}

		public async Task<T?> Update<T>(Type dialog, T model) where T : class
		{
			if (DialogService != null && model != null)
			{
				var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };

				var parameters = new DialogParameters();
				parameters.Add("Model", model);

				var result = await DialogService.Show(dialog, "", parameters, options).Result;

				if (!result.Cancelled)
					if (result.Data is T)
						return result.Data as T;
			}
			return null;
		}
	}
}
