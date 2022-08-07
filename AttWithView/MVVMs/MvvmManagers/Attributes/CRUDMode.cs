using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttWithView.MVVMs.MvvmManagers.Attributes
{
    [Flags]
    public enum CRUDMode
    {
        Create = 0x01,
        Read = 0x02,
        Update = 0x04,
        Delete = 0x08,
        All = 0x0F
    }
}
