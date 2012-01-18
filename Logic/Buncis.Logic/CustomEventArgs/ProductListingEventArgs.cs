using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Logic.CustomEventArgs
{
    public class ProductListingEventArgs : EventArgs
    {
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}
