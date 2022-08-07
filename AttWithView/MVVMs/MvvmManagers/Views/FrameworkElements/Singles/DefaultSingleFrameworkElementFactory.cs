using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Components;
using AttWithView.MVVMs.MvvmManagers.ViewModels;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles
{
    internal class DefaultSingleFrameworkElementFactory<T> : ISingleFrameworkElementFactory
    {
        public FrameworkElement Create()
        {
            FrameworkElement element =  PropElementFactory.Instance.Create(typeof(T));
            element.SetBinding(FrameworkElement.DataContextProperty, new Binding(nameof(SingleViewModel<T>.Item)) { Mode = BindingMode.OneWay });
            return element;
        }
    }
}
