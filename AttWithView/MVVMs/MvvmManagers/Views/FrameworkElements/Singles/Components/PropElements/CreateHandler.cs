using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Attributes;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles.PropElements
{
    public abstract class CreateHandler
    {
        public CreateHandler(PropElement propElement)
        {
            PropElement = propElement;
        }

        public PropElement PropElement { get; init; }


        public abstract FrameworkElement Create(PropertyInfo info,Binding binding, SuiAttribute attr);
    }
}
