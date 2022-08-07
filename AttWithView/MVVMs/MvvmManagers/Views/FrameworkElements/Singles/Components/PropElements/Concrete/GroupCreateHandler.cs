using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Attributes;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Singles.PropElements.Concrete
{
    public class GroupCreateHandler : CreateHandler
    {
        public GroupCreateHandler()
            : base(PropElement.Group)
        {
        }

        public override FrameworkElement Create(PropertyInfo info, Binding binding, SuiAttribute attr)
        {
            FrameworkElement element = PropElementFactory.Instance.Create(info.PropertyType, attr.GroupOrientation);
            element.SetBinding(FrameworkElement.DataContextProperty, binding);
            return element;
        }
    }
}
