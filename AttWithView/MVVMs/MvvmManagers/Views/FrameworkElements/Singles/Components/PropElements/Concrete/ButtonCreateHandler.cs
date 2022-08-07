using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Attributes;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles.PropElements.Concrete
{
    public class ButtonCreateHandler : CreateHandler
    {
        public ButtonCreateHandler() : base(PropElement.Button)
        {
        }

        public override FrameworkElement Create(PropertyInfo info, Binding binding, SuiAttribute attr)
        {
            Button button = new();
            if(attr.Width is not null)
            {
                button.Width = (double)attr.Width;
            }
            if(attr.Height is not null)
            {
                button.Height = (double)attr.Height;
            }
            button.Content = attr.Title;
            button.SetBinding(ButtonBase.CommandProperty, binding);
            return button;
        }
    }
}
