namespace WebUI.Services.Helpers
{
	public interface IMyDialogService
    {
        public Task<bool> Confirm(string text);
        public Task<T?> Create<T>(Type dialog) where T : class;
        public Task<T?> Update<T>(Type dialog, T model) where T : class;
    }
}
