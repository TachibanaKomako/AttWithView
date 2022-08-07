using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Attributes;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Directors;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Directors.Components;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Components
{
    public class ItemsListBox<T> : ListBox
    {
        public ItemsListBox()
        {
            ListBoxDirector<T> director = new();
            director.Construct(this);
            
        }
    }
}
