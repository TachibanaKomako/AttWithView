using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AttWithView.MVVMs.MvvmManagers.Attributes;
using AttWithView.MVVMs.MvvmManagers.ViewModels;

namespace AttWithView.MVVMs.MvvmManagers.Views.DefaultWindows.CreateHandlers
{
    public abstract class CreateHandler<T>
    {
        public CreateHandler(WindowMode targetWindowMode)
        {
            TargetWindowMode = targetWindowMode;
        }

        public WindowMode TargetWindowMode { get; init; }
        public Window Create(IMvvmManagersManager<T> manager)
        {
            WindowAttribute? attr = typeof(T).GetCustomAttribute<WindowAttribute>();
            if (attr is null)
            {
                throw new Exception(nameof(attr));
            }
            Window window = new();
            window.Width = attr.Width;
            window.Height = attr.Height;
            window.Title = attr.Title;

            IMvvmManagersViewModel vm = CreateViewModel(manager);
            vm.Init();
            FrameworkElement element = CreateView(manager);
            element.Margin = new(10);

            window.DataContext = vm;
            window.Content = element;
            window.Closing += Window_Closing;


            return window;
        }

        private void Window_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sender is Window window)
            {
                WindowAttribute? attr = typeof(T).GetCustomAttribute<WindowAttribute>();
                if (attr is null)
                {
                    throw new Exception(nameof(attr));
                }
                IMvvmManagersViewModel vm = (IMvvmManagersViewModel)window.DataContext;
                switch (attr.ClosingMode)
                {
                    case ClosingMode.AlwayCancel:
                        vm.Cancel();
                        break;
                    case ClosingMode.AlwayOk:
                        vm.Ok();
                        break;
                    case ClosingMode.OkCancel:
                        switch (MessageBox.Show("保存しますか?", "閉じる", MessageBoxButton.YesNoCancel))
                        {
                            case MessageBoxResult.Yes:
                                vm.Ok();
                                break;
                            case MessageBoxResult.No:
                                vm.Cancel();
                                break;
                            case MessageBoxResult.Cancel:
                                e.Cancel = true;
                                break;
                        }
                        break;
                }
                
            }
        }

        protected abstract FrameworkElement CreateView(IMvvmManagersManager<T> manager);
        protected abstract IMvvmManagersViewModel CreateViewModel(IMvvmManagersManager<T> manager);
    }
}
