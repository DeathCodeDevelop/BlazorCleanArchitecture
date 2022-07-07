using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public interface IMyDialogService
    {
        public Task<bool> Confirm(string text);
        public Task<T?> Create<T>(Type dialog) where T : class;
        public Task<T?> Update<T>(Type dialog, T model) where T : class;
    }
}
