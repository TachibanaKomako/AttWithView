using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttWithView.MVVMs.MvvmManagers.Components;

namespace AttWithView.MVVMs.MvvmManagers.ViewModels
{
    public class ItemManager<T> : IItemManager<T>
    {
        private readonly CollectionViewModel<T> vm;
        private readonly IItemActivator<T> activator;
        private Item<T>? selectedItem;
        public ItemManager(CollectionViewModel<T> vm, IItemActivator<T> activator)
        {
            this.vm = vm;
            this.activator = activator;

            this.vm.PropertyChanged += Vm_PropertyChanged;
        }

        private void Vm_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(CollectionViewModel<T>.SelectedItem):

                    break;
                default:
                    break;
            }
        }

        public void CommitToAdd(Item<T> item)
        {
            vm.Items.Insert(0, item);
            vm.SelectedIndex = 0;
        }

        public void CreateAndAdd(T item)
        {
            vm.Items.Add(new(item, this));
        }

        public Item<T> CreateNew()
        {
            return new Item<T>(activator.Activate(vm.Items.Select(f => f.Info)), this);
        }

        public void Remove(Item<T> item)
        {
            vm.Items.Remove(item);
        }

        public void SelectedItem(Item<T>? item)
        {
            Item<T>? oldItem = selectedItem;
            if (oldItem is not null)
            {
                oldItem.IsSelected = false;
            }
            if (item is not null)
            {
                item.IsSelected = true;
                selectedItem = item;
            }
        }
    }
}
