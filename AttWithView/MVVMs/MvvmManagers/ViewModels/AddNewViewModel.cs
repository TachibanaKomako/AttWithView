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
    public class AddNewViewModel<T> : ViewModelBase, IMvvmManagersViewModel
    {
        private readonly IItemManager<T> _itemManager;
        public AddNewViewModel(IItemManager<T> itemManager)
        {
            _itemManager = itemManager;
        }
        private Item<T>? item;
        public T Item => item is not null ? item.Info : throw new Exception(nameof(item));
        
        public ICommand InitCommand => GetCommand(() => new DefaultCommand(Init));
        public void Init()
        {
            item = _itemManager.CreateNew();
        }
        public ICommand OkCommand => GetCommand(() => new DefaultCommand(Ok));
        public void Ok()
        {
            if (item is not null)
            {
                _itemManager.CommitToAdd(item);
            }
        }
        public ICommand CancelCommand => GetCommand(() => new DefaultCommand(Cancel));
        public void Cancel()
        {

        }
    }
}
