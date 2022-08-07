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
using AttWithView.MVVMs.MvvmManagers.ViewModels;

namespace AttWithView.MVVMs.MvvmManagers.Views.CollectionAddNewWindows
{
    public class WindowFactory
    {
        public static Window Create<T>(IMvvmManagersManager<T> manager)
        {

            Button okButton = new Button();
            okButton.Width = 100;
            okButton.Height = 30;
            okButton.Content = "OK";
            okButton.SetBinding(ButtonBase.CommandProperty, new Binding(nameof(AddNewViewModel<T>.OkCommand)) { Mode = BindingMode.OneWay });
            okButton.SetValue(DockPanel.DockProperty, Dock.Left);

            Button cancelButton = new Button();
            cancelButton.Width = 100;
            cancelButton.Height = 30;
            cancelButton.Content = "CANCEL";
            cancelButton.SetBinding(ButtonBase.CommandProperty, new Binding(nameof(AddNewViewModel<T>.OkCommand)) { Mode = BindingMode.OneWay });
            cancelButton.SetValue(DockPanel.DockProperty, Dock.Right);
            cancelButton.HorizontalAlignment = HorizontalAlignment.Right;

            DockPanel panel = new();
            panel.Children.Add(okButton);
            panel.Children.Add(cancelButton);
            panel.SetValue(DockPanel.DockProperty, Dock.Bottom);

            DockPanel panel2 = new();
            panel2.Children.Add(panel);
            panel2.Children.Add(manager.GetSingleFrameworkElementFactory().Create());
            panel2.Margin = new(10);

            WindowAttribute? attr = typeof(T).GetCustomAttribute<WindowAttribute>();

            if(attr is null)
            {
                throw new Exception(nameof(attr));
            }

            Window window = new()
            {
                Title = "新規作成",
                Height = attr.AddNewHeight,
                Width = attr.AddNewWidth,
                Content = panel2
            };
            void ClickAndClose(object sender, RoutedEventArgs e)
            {
                window.Close();
            }
            okButton.Click += ClickAndClose;
            cancelButton.Click += ClickAndClose;
            return window;
        }
    }
}
