using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Attributes;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles.PropElements.Concrete
{
    public class TextBoxCreateHandler : CreateHandler
    {
        public TextBoxCreateHandler() : base(PropElement.TextBox)
        {
        }

        public override FrameworkElement Create(PropertyInfo info, Binding binding, SuiAttribute attr)
        {
            StackPanel panel = new();
            panel.Children.Add(new Label { Content = attr.Title });
            TextBox textBox = new();
            textBox.SetBinding(TextBox.TextProperty, binding);
            panel.Children.Add(textBox);
            return panel;
        }
    }
}
