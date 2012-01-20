using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Core.Services;
using Buncis.Core.Infrastructures;
using Buncis.Logic.Views;

namespace Buncis.Logic.Presenters
{
    public class SupplierListingPresenter : BuncisBasePresenter<ISupplierListingView>
    {
        private ISupplierService _supplierService;

        public SupplierListingPresenter(ISystemSettings systemSettings, ISupplierListingView view, ISupplierService supplierService)
            : base(systemSettings, view)
        {
            _supplierService = supplierService;

            view.GetSuppliers += new EventHandler(view_GetSuppliers);
        }

        void view_GetSuppliers(object sender, EventArgs e)
        {
            View.Model.Suppliers = _supplierService.GetAllSuppliers();
        }

    }
}
