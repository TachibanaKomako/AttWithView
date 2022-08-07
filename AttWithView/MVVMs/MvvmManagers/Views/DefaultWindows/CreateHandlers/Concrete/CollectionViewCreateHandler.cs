using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Attributes;
using AttWithView.MVVMs.MvvmManagers.Components;
using AttWithView.MVVMs.MvvmManagers.ViewModels;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles;

namespace AttWithView.MVVMs.MvvmManagers.Views.DefaultWindows.CreateHandlers.Concrete
{
    internal class CollectionViewCreateHandler<T> : CreateHandler<T>
    {
        public CollectionViewCreateHandler() : base(WindowMode.Collection)
        {
        }

        protected override FrameworkElement CreateView(IMvvmManagersManager<T> manager)
        {
            ICollectionFrameworkElementFactory collectionFactory = manager.GetCollectionFrameworkElementFactory();
            return collectionFactory.Create();
        }

        protected override IMvvmManagersViewModel CreateViewModel(IMvvmManagersManager<T> manager)
        {
            var viewModel = new CollectionViewModel<T>(manager.GetItemActivator(), manager.GetItemsDataStore(), manager.GetCollectionAddNewWindowFactory(), manager.GetMessenger());
            return viewModel;
        }
    }
}
