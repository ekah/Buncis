using System.Collections.Generic;
using Buncis.Data.Models;

namespace Buncis.Core.Services
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();
    }
}