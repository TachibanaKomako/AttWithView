using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttWithView.MVVMs.MvvmManagers.Components
{
    public interface IItemManager<T>
    {
        void SelectedItem(Item<T> item);
        Item<T> CreateNew();
        void CreateAndAdd(T item);
        void CommitToAdd(Item<T> item);
        void Remove(Item<T> item);
    }
}
