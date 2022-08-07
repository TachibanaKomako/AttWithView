using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AttWithView.MVVMs.Views
{
    public static class BindingFactory
    {
        public static IEnumerable<(Binding binding,PropertyInfo propertyInfo,T attr)> Create<T>(Type type,Func<T,string?> getStringFormat)
            where T: Attribute
        {
            PropertyInfo[] infos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(PropertyInfo info in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                T? attr = info.GetCustomAttribute<T>();
                if(attr is not null)
                {
                    Binding binding = new(info.Name)
                    {
                        Mode = info.CanRead is true ? BindingMode.OneWay : BindingMode.TwoWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                        StringFormat = getStringFormat(attr)
                    };
                    yield return (binding, info, attr);
                }
            }
        }
    }
}
