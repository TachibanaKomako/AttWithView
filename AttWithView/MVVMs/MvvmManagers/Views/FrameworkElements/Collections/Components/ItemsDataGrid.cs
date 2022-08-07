using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Directors;

namespace AttWithView.MVVMs.MvvmManagers.Views.FrameworkElements.Collections.Components
{
    public class ItemsDataGrid<T> : DataGrid
    {
        public ItemsDataGrid()
        {
            DataGridDirector<T> director = new();
            director.Construct(this);
            AutoGenerateColumns = false;
            CanUserAddRows = false;
            CanUserDeleteRows = false;
        }
    }
}
