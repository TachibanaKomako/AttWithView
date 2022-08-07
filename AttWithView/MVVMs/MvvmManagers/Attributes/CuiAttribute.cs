using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttWithView.MVVMs.MvvmManagers.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CuiAttribute : Attribute
    {
        public int OrderNo { get; set; }
        public string Title { get; set; }

        public string? StringFormat { get; set; }

        public CuiAttribute(int orderNo, string title)
        {
            OrderNo = orderNo;
            Title = title;
        }
    }
}
