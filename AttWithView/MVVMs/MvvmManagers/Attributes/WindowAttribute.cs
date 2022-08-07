using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttWithView.MVVMs.MvvmManagers.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class WindowAttribute : Attribute
    {
        public string Title { get; set; } = "";
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 600;
        public CRUDMode CRUDMode { get; set; } = CRUDMode.All;
        public WindowMode WindowMode { get; set; } = WindowMode.Single;
        public CollectionViewMode CollectionViewMode { get; set; } = CollectionViewMode.ListBox;
        public int CollectionViewWidth { get; set; } = 200;
        public int AddNewWidth { get; set; } = 600;
        public int AddNewHeight { get; set; } = 600;
        public ClosingMode ClosingMode { get; set; } = ClosingMode.OkCancel;
    }
}
