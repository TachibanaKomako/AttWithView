using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AttWithView.MVVMs.MvvmManagers.Attributes;
using AttWithView.MVVMs.MvvmManagers.Components;
using AttWithView.MVVMs.MvvmManagers.ViewModels;
using AttWithView.MVVMs.MvvmManagers.Views.DefaultWindows.CreateHandlers;
using AttWithView.MVVMs.MvvmManagers.Views.DefaultWindows.CreateHandlers.Concrete;

namespace AttWithView.MVVMs.MvvmManagers.Views.DefaultWindows
{
    internal class DefaultWindowFactory
    {
        public static Window Create<T>(IMvvmManagersManager<T> manager)
        {
            WindowAttribute? attr = typeof(T).GetCustomAttribute<WindowAttribute>();
            if(attr is null)
            {
                throw new Exception(nameof(attr));
            }
            CreateHandler<T> handler = attr.WindowMode switch
            {
                WindowMode.Collection => new CollectionViewCreateHandler<T>(),
                WindowMode.Single => new SingleViewCreateHandler<T>(),
                _ => throw new Exception(nameof(handler)),
            };
            return handler.Create(manager);
        }
    }
}
