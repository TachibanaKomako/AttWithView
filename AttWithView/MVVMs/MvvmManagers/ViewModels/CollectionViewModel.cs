using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AttWithView.MVVMs.Messages;
using AttWithView.MVVMs.MvvmManagers.Components;
using AttWithView.MVVMs.MvvmManagers.Models;
using AttWithView.MVVMs.ViewModels;

namespace AttWithView.MVVMs.MvvmManagers.ViewModels
{
    public class CollectionViewModel<T> : SelectableItemsViewModel<Item<T>>, IMvvmManagersViewModel
    {
        private readonly IItemActivator<T> _activator;
        private ItemManager<T>? itemManager;
        private readonly IItemsDataStore<T> _itemsDataStore;
        private readonly ICollectionAddNewWindowFactory<T> _windowFactory;
        private readonly Messenger _messenger;
        public CollectionViewModel(IItemActivator<T> activator, IItemsDataStore<T> itemsDataStore,ICollectionAddNewWindowFactory<T> windowFactory, Messenger messenger)
        {
            _activator = activator;
            _itemsDataStore = itemsDataStore;
            _windowFactory = windowFactory;
            _messenger = messenger;
        }

        public ItemManager<T> ItemManager => itemManager ??= new ItemManager<T>(this, _activator);

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case nameof(SelectedItem):
                    ItemManager.SelectedItem(SelectedItem);
                    break;
            }
        }

        public ICommand InitCommand => GetCommand(() => new DefaultCommand(Init));
        public void Init()
        {
            Items.Clear();
            foreach(T item in _itemsDataStore.LoadData())
            {
                ItemManager.CreateAndAdd(item);
            }
            SelectedIndex = 0;
        }
        public ICommand OkCommand => GetCommand(() => new DefaultCommand(Ok));
        public void Ok()
        {
            _itemsDataStore.SaveData(Items.Select(f => f.Info));
        }
        public ICommand CancelCommand => GetCommand(() => new DefaultCommand(Cancel));
        public void Cancel()
        {

        }

        public ICommand ShowAddNewViewCommand => GetCommand(()=>new DefaultCommand(ShowAddNewView));
        public void ShowAddNewView()
        {
            Window w = _windowFactory.Create(ItemManager);
            _messenger.Send(new ShowWindowMessage(w));
        }
    }
}
