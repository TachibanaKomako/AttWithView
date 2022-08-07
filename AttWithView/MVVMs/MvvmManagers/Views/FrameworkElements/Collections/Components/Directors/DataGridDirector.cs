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
using AttWithView.MVVMs.MvvmManagers.Components;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Directors.Components;
using AttWithView.MVVMs.Views;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Directors
{
    public class DataGridDirector<T> : SelectorDirector<DataGrid, T>
    {
        public override void ConstructProperty(DataGrid view, PropertyInfo info, CuiAttribute cui, Binding binding)
        {
            DataGridTemplateColumn column = new();
            column.Header = cui.Title;
            column.CellTemplate = TemplateGenerator.CreateDataTemplate(() =>
            {
                TextBox textBox = new();
                textBox.SetBinding(TextBox.TextProperty, binding);
                textBox.SetBinding(FrameworkElement.DataContextProperty, new Binding(nameof(Item<T>.Info)));
                textBox.IsReadOnly = true;
                return textBox;
            });
            view.Columns.Add(column);
        }

        public override void ConstructPropertyBegin(DataGrid view)
        {
            view.Columns.Clear();
        }

        public override void ConstructPropertyEnd(DataGrid view)
        {
        }
    }
}
