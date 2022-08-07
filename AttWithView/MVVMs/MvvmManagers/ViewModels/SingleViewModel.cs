using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttWithView.MVVMs.MvvmManagers.Components;
using AttWithView.MVVMs.ViewModels;

namespace AttWithView.MVVMs.MvvmManagers.ViewModels
{
    public class SingleViewModel<T> : ViewModelBase, IMvvmManagersViewModel
    {
        private readonly IItemDataStore<T> _itemDataStore;
        public SingleViewModel(IItemDataStore<T> itemDataStore)
        {
            _itemDataStore = itemDataStore;
        }
        public T? Item { get; private set; }
        public ICommand InitCommand => GetCommand(() => new DefaultCommand(Init));
        public void Init()
        {
            Item = _itemDataStore.LoadData();
        }
        public ICommand OkCommand => GetCommand(() => new DefaultCommand(Ok));
        public void Ok()
        {
            if (Item is not null)
            {
                _itemDataStore.SaveData(Item);
            }
        }
        public ICommand CancelCommand => GetCommand(() => new DefaultCommand(Cancel));
        public void Cancel()
        {
            
        }
    }
}
