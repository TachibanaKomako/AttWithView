using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AttWithView.MVVMs.MvvmManagers.Attributes;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles.PropElements;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles.PropElements.Concrete;
using AttWithView.MVVMs.Views;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles
{
    public class PropElementFactory
    {
        private readonly Dictionary<PropElement, CreateHandler> handlers = new();
        PropElementFactory()
        {
            foreach(Type type in Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.Namespace == typeof(TextBoxCreateHandler).Namespace
                        && type.IsAssignableTo(typeof(CreateHandler))))
            {
                object? instance = Activator.CreateInstance(type);
                if(instance is not null)
                {
                    CreateHandler handler = (CreateHandler)instance;
                    handlers.Add(handler.PropElement, handler);
                }
            }
        }

        public static PropElementFactory Instance { get; } = new();

        public FrameworkElement Create(Type itemType,Orientation orientation = Orientation.Vertical)
        {
            StackPanel panel = new()
            {
                Orientation = orientation
            };
            foreach ((System.Windows.Data.Binding binding, PropertyInfo propertyInfo, SuiAttribute attr) in BindingFactory.Create<SuiAttribute>(itemType, f => f.StringFormat).OrderBy(f => f.attr.OrderNo))
            {
                panel.Children.Add(handlers[attr.Element].Create(propertyInfo, binding, attr));
            }
            return panel;
        }
    }
}
