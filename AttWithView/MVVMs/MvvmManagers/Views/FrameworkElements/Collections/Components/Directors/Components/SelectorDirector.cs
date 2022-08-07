using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using AttWithView.MVVMs.MvvmManagers.Attributes;
using AttWithView.MVVMs.MvvmManagers.ViewModels;
using AttWithView.MVVMs.Views;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Directors.Components
{
    public abstract class SelectorDirector<TView, TViewModel>
        where TView : Selector
    {
        public void Construct(TView view)
        {

            view.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(CollectionViewModel<TViewModel>.Items)) { Mode = BindingMode.OneWay });
            view.SetBinding(Selector.SelectedIndexProperty, new Binding(nameof(CollectionViewModel<TViewModel>.SelectedIndex)) { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

            ConstructPropertyBegin(view);
            foreach ((Binding binding, PropertyInfo info, CuiAttribute attr) in BindingFactory.Create(typeof(TViewModel), (CuiAttribute attr) => attr.StringFormat).OrderBy(f => f.attr.OrderNo))
            {
                ConstructProperty(view, info, attr, binding);
            }
            ConstructPropertyEnd(view);
        }
        public abstract void ConstructPropertyBegin(TView view);
        public abstract void ConstructProperty(TView view, PropertyInfo info, CuiAttribute cui, Binding binding);
        public abstract void ConstructPropertyEnd(TView view);
    }
}
