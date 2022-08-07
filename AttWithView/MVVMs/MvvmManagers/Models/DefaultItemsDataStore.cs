using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttWithView.MVVMs.MvvmManagers.Components;

namespace AttWithView.MVVMs.MvvmManagers.Models
{
    internal class DefaultItemsDataStore<T> : IItemsDataStore<T>
    {
        public IEnumerable<T> LoadData()
        {
            return Enumerable.Empty<T>();
        }

        public void SaveData(IEnumerable<T> item)
        {
        }
    }
}
