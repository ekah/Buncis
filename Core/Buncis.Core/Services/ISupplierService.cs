﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Core.Repositories;
using Buncis.Data.Models;

namespace Buncis.Core.Services
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();
    }
}
