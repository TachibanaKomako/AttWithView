using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttWithView.MVVMs.MvvmManagers.Components;

namespace AttWithView.MVVMs.MvvmManagers.Models
{
    public class DefaultItemDataStore<T> : IItemDataStore<T>
    {
        public T LoadData()
        {
            return Activator.CreateInstance<T>();
        }

        public void SaveData(T item)
        {
        }
    }
}
