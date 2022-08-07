using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttWithView.MVVMs.MvvmManagers.ViewModels
{
    public interface IMvvmManagersViewModel
    {
        ICommand InitCommand { get; }
        void Init();
        ICommand OkCommand { get; }
        void Ok();
        ICommand CancelCommand { get; }
        void Cancel();
    }
}
