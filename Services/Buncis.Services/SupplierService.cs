using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Core.Services;
using Buncis.Data.Models;
using Buncis.Core.Repositories;

namespace Buncis.Services
{
    public class SupplierService : Base.BuncisBaseService, ISupplierService
    {
        private ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAll().ToList();
        }
    }
}
