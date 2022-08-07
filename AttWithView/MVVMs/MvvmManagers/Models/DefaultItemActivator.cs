using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttWithView.MVVMs.MvvmManagers.Components;

namespace AttWithView.MVVMs.MvvmManagers.Models
{
    public class DefaultItemActivator<T> : IItemActivator<T>
    {
        public T Activate(IEnumerable<T> items)
        {
            return Activator.CreateInstance<T>();
        }
    }
}
