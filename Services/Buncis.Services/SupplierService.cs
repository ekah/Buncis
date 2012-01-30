using System.Collections.Generic;
using System.Linq;
using Buncis.Core.Repositories;
using Buncis.Core.Services;
using Buncis.Data.Models;

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
            return _supplierRepository.GetAll().OrderBy(s => s.CompanyName).ToList();
        }
    }
}