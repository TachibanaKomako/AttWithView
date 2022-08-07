using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttWithView.MVVMs.MvvmManagers.Components
{
    public interface IItemsDataStore<T>
    {
        IEnumerable<T> LoadData();
        void SaveData(IEnumerable<T> item);
    }
}
