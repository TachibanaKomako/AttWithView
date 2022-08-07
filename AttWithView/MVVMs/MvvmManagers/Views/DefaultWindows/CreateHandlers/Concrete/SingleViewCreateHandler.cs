using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AttWithView.MVVMs.MvvmManagers.Attributes;
using AttWithView.MVVMs.MvvmManagers.ViewModels;

namespace AttWithView.MVVMs.MvvmManagers.Views.DefaultWindows.CreateHandlers.Concrete
{
    internal class SingleViewCreateHandler<T> : CreateHandler<T>
    {
        public SingleViewCreateHandler() : base(WindowMode.Single)
        {
        }

        protected override FrameworkElement CreateView(IMvvmManagersManager<T> manager)
        {
            return manager.GetSingleFrameworkElementFactory().Create();
        }

        protected override IMvvmManagersViewModel CreateViewModel(IMvvmManagersManager<T> manager)
        {
            var vm = new SingleViewModel<T>(manager.GetItemDataStore());
            return vm;
        }
    }
}
