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
    public class ListBoxDirector<T> : SelectorDirector<ListBox, T>
    {
        public override void ConstructProperty(ListBox view, PropertyInfo info, CuiAttribute cui, Binding binding)
        {
            list.Add(new(binding, info, cui));
        }

        private List<(Binding binding, PropertyInfo info, CuiAttribute attr)> list = new();
        public override void ConstructPropertyBegin(ListBox view)
        {
            list.Clear();
        }

        public override void ConstructPropertyEnd(ListBox view)
        {
            view.ItemTemplate = TemplateGenerator.CreateDataTemplate(() => CreateElement(list.ToArray()));
        }


        public object CreateElement((Binding binding, PropertyInfo info, CuiAttribute attr)[] items)
        {
            DockPanel dockPanel = new();

            Button button = new()
            {
                Content = "削除"
            };
            button.SetBinding(ButtonBase.CommandProperty, new Binding(nameof(Item<T>.DeleteCommand)));
            button.SetValue(DockPanel.DockProperty, Dock.Right);
            button.SetBinding(UIElement.VisibilityProperty, new Binding(nameof(Item<T>.IsSelected)) { Converter = VisibleConverter.Instance });

            StackPanel contentPanel = new();
            contentPanel.SetBinding(FrameworkElement.DataContextProperty, new Binding(nameof(Item<T>.Info)));
            foreach ((Binding binding, PropertyInfo info, CuiAttribute attr) in items)
            {
                TextBlock textBlock = new();
                textBlock.SetBinding(TextBlock.TextProperty, binding);
                contentPanel.Children.Add(textBlock);
            }
            contentPanel.SetValue(DockPanel.DockProperty, Dock.Left);

            dockPanel.Children.Add(button);
            dockPanel.Children.Add(contentPanel);

            return dockPanel;
        }
    }
}
