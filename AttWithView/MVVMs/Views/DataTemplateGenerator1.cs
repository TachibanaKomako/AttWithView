using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace AttWithView.MVVMs.Views
{
    internal class DataTemplateGenerator1
    {
        public static DataTemplate Create(Type type, string ShowColumn)
        {
            StringReader stringReader = new StringReader(
            @"<DataTemplate 
        xmlns=""http://schemas.Microsoft.com/winfx/2006/xaml/presentation""> 
            <" + type.Name + @" Text=""{Binding " + ShowColumn + @"}""/> 
        </DataTemplate>");
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return (DataTemplate)XamlReader.Load(xmlReader);
        }

    }
}
