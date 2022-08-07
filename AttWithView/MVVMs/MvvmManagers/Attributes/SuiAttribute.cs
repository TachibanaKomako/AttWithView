using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AttWithView.MVVMs.MvvmManagers.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SuiAttribute : Attribute
    {
        public int OrderNo { get; set; }
        public string Title { get; set; }
        public PropElement Element { get; set; } = PropElement.TextBox;
        public double? Width { get; set; }
        public double? Height { get; set; }

        public string? StringFormat { get; set; }

        public Orientation GroupOrientation { get; set; } = Orientation.Vertical;
        public SuiAttribute(int orderNo, string title)
        {
            OrderNo = orderNo;
            Title = title;
        }
    }
}
