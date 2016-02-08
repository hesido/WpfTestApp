using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
    interface SelectableItem
    {
        bool IsSelected { get; set; }

        //public SelectableItem() { IsSelected = false; }
    }
}
