using System;

namespace Buncis.Logic.CustomEventArgs
{
    public class ProductListingEventArgs : EventArgs
    {
        public int? CategoryId { get; set; }

        public int? SupplierId { get; set; }
    }

    public delegate void SearchProductsEventHandler(object sender, ProductListingEventArgs e);
}