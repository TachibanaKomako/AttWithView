using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttWithView.MVVMs.ViewModels;

namespace AttWithView.MVVMs.MvvmManagers.Components
{
    public class Item<T> : ViewModelBase
    {
        public Item(T info,IItemManager<T> manager)
        {
            Manager = manager;
            Info = info;
        }
        public bool IsSelected { get => (bool)(GetValue() ?? false); set => SetValue(value); }
        public IItemManager<T> Manager { get; private set; }
        public T Info { get; private set; }

        private ICommand? deleteCommand;
        public ICommand DeleteCommand => deleteCommand ??= new DefaultCommand(Delete);

        protected void Delete()
        {
            Manager.Remove(this);
        }
    }
}
