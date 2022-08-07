using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Components;
using AttWithView.MVVMs.MvvmManagers.ViewModels;

namespace AttWithView.MVVMs.MvvmManagers.Views.CollectionAddNewWindows
{
    internal class DefaultCollectionAddNewWindowFactory<T> : ICollectionAddNewWindowFactory<T>
    {
        private readonly IMvvmManagersManager<T> _manager;

        public DefaultCollectionAddNewWindowFactory(IMvvmManagersManager<T> manager)
        {
            _manager = manager;
        }

        public Window Create(IItemManager<T> itemManager)
        {
            AddNewViewModel<T> viewModel = new(itemManager);
            viewModel.Init();

            Window window = WindowFactory.Create(_manager);

            window.DataContext = viewModel;
            return window;
        }
    }
}
