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
    public class DatePickerCreateHandler : CreateHandler
    {
        public DatePickerCreateHandler()
            : base(PropElement.DatePicker)
        {
        }

        public override FrameworkElement Create(PropertyInfo info, Binding binding, SuiAttribute attr)
        {
            StackPanel panel = new();
            panel.Children.Add(new Label { Content = attr.Title });
            DatePicker datePicker = new();
            datePicker.SetBinding(DatePicker.SelectedDateProperty, binding);
            panel.Children.Add(datePicker);
            return panel;
        }
    }
}
