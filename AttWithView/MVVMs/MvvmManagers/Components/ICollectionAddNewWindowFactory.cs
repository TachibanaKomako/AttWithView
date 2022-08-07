using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttWithView.MVVMs.MvvmManagers.Components
{
    public interface ICollectionAddNewWindowFactory<T>
    {
        Window Create(IItemManager<T> itemManager);
    }
}
