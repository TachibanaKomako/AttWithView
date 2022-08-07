using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttWithView.MVVMs.MvvmManagers.Components;

namespace AttWithView.MVVMs.MvvmManagers
{
    public interface IMvvmManagersManager<T>
    {
        public ICollectionFrameworkElementFactory GetCollectionFrameworkElementFactory();
        public ISingleFrameworkElementFactory GetSingleFrameworkElementFactory();
        public IItemActivator<T> GetItemActivator();
        public IItemsDataStore<T> GetItemsDataStore();
        public IItemDataStore<T> GetItemDataStore();
        public ICollectionAddNewWindowFactory<T> GetCollectionAddNewWindowFactory();

        public Messenger GetMessenger();
    }
}
