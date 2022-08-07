using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AttWithView.MVVMs.MvvmManagers.Attributes;
using AttWithView.MVVMs.MvvmManagers.Components;
using AttWithView.MVVMs.MvvmManagers.Models;
using AttWithView.MVVMs.MvvmManagers.ViewModels;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles;
using AttWithView.MVVMs.MvvmManagers.Views.DefaultWindows;
using AttWithView.MVVMs.MvvmManagers.Views.CollectionAddNewWindows;

namespace AttWithView.MVVMs.MvvmManagers
{
    public abstract class MvvmManagersManager<T> : IMvvmManagersManager<T>
    {
        public virtual ICollectionFrameworkElementFactory GetCollectionFrameworkElementFactory()
        {
            return new DefaultCollectionFrameworkElementFactory<T>(this);
        }
        public virtual ISingleFrameworkElementFactory GetSingleFrameworkElementFactory()
        {
            return new DefaultSingleFrameworkElementFactory<T>();
        }
        public virtual IItemActivator<T> GetItemActivator()
        {
            return new DefaultItemActivator<T>();
        }
        public virtual IItemsDataStore<T> GetItemsDataStore()
        {
            return new DefaultItemsDataStore<T>();
        }
        public virtual IItemDataStore<T> GetItemDataStore()
        {
            return new DefaultItemDataStore<T>();
        }
        public virtual ICollectionAddNewWindowFactory<T> GetCollectionAddNewWindowFactory()
        {
            return new DefaultCollectionAddNewWindowFactory<T>(this);
        }
        private readonly Messenger messenger = new();
        public Messenger GetMessenger()
        {
            return messenger;
        }

        public virtual Window CreateWindow()
        {
            return DefaultWindowFactory.Create(this);
        }
    }
}
