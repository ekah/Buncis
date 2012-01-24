using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Buncis.Data.Models;

namespace Buncis.Data.Domain.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Id(x => x.CategoryId);
            Map(x => x.CategoryName);
            Map(x => x.CategoryDescription).Column("Description");
        }
    }

    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.ProductId);
            Map(x => x.ProductName);
            Map(x => x.QuantityPerUnit);
            Map(x => x.UnitPrice);
            Map(x => x.UnitsInStock);
            Map(x => x.UnitsOnOrder);
            Map(x => x.ReorderLevel);
            Map(x => x.Discontinued);
            Map(x => x.CategoryId);
            Map(x => x.SupplierId);
            Map(x => x.ProductImage);
            References<Category>(x => x.Category).Column("CategoryId");
            References<Supplier>(x => x.Supplier).Column("SupplierId");
        }
    }

    public class SupplierMap : ClassMap<Supplier>
    {
        public SupplierMap()
        {
            Table("Suppliers");
            Id(x => x.SupplierId);
            Map(x => x.CompanyName);
            Map(x => x.ContactName);
            Map(x => x.HomePage);
            Map(x => x.ContactTitle);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.Region);
            Map(x => x.PostalCode);
            Map(x => x.Phone);
            Map(x => x.Fax);
        }
    }
}
