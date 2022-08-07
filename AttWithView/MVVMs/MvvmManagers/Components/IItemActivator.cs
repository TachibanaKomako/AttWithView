using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttWithView.MVVMs.MvvmManagers.Components
{
    public interface IItemActivator<T>
    {
        T Activate(IEnumerable<T> items);
    }
}
