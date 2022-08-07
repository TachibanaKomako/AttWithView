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
using AttWithView.MVVMs.MvvmManagers.ViewModels;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Components;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections
{
    public class DefaultCollectionFrameworkElementFactory<T> : ICollectionFrameworkElementFactory
    {
        private readonly IMvvmManagersManager<T> _manager;
        public DefaultCollectionFrameworkElementFactory(IMvvmManagersManager<T> manager)
        {
            _manager = manager;
        }

        public FrameworkElement Create()
        {
            WindowAttribute attr = typeof(T).GetCustomAttribute<WindowAttribute>() ?? throw new Exception(nameof(attr));

            FrameworkElement itemsControl = CreateItemsControl();
            itemsControl.Width = attr.CollectionViewWidth;
            itemsControl.SetValue(DockPanel.DockProperty, Dock.Left);

            Button addNewButton = new() { Content = "新規作成", Width = 80, Height = 30 ,Margin = new(0,5,5,0) };
            addNewButton.SetBinding(ButtonBase.CommandProperty, new Binding(nameof(CollectionViewModel<T>.ShowAddNewViewCommand)) { Mode = BindingMode.OneWay});
            addNewButton.HorizontalAlignment = HorizontalAlignment.Left;
            addNewButton.SetValue(DockPanel.DockProperty, Dock.Top);

            FrameworkElement singleView = _manager.GetSingleFrameworkElementFactory().Create();
            singleView.SetBinding(FrameworkElement.DataContextProperty, new Binding(nameof(CollectionViewModel<T>.SelectedItem)) { Mode = BindingMode.OneWay });
            singleView.SetValue(DockPanel.DockProperty, Dock.Bottom);
            singleView.SetBinding(UIElement.IsEnabledProperty, new Binding(nameof(CollectionViewModel<T>.SelectedIsEnabled)) { Mode = BindingMode.OneWay });
            DockPanel singlePanel = new();
            singlePanel.SetValue(DockPanel.DockProperty, Dock.Right);
            singlePanel.Margin = new(5, 0, 0, 0);
            singlePanel.Children.Add(addNewButton);
            singlePanel.Children.Add(singleView);

            DockPanel panel = new();
            panel.Children.Add(itemsControl);
            panel.Children.Add(singlePanel);
            return panel;
        }
        private static FrameworkElement CreateItemsControl()
        {
            WindowAttribute? att = typeof(T).GetCustomAttribute<WindowAttribute>();
            if (att != null)
            {
                switch (att.CollectionViewMode)
                {
                    case CollectionViewMode.DataGrid:
                        return new ItemsDataGrid<T>();
                    case CollectionViewMode.ListBox:
                        return new ItemsListBox<T>();
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
