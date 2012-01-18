using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Buncis.Core.Services;
using Buncis.Data.Models;
using Buncis.Core.Repositories;
using System.Linq.Expressions;
using LinqKit;

namespace Buncis.Services
{
    public class ProductService : Base.BuncisBaseService, IProductService
    {
        private IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Gets the product by product id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Product GetProductByProductId(int id)
        {
            return _productRepository.FindBy(o => o.ProductId == id);
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="categoryId">The category id.</param>
        /// <param name="supplierId">The supplier id.</param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts(int? categoryId, int? supplierId)
        {
            // Use the power of LinqKit.. thanks to the developer
            Expression<Func<Product, bool>> categoryExpression;
            Expression<Func<Product, bool>> supplierExpression;

            if (categoryId.HasValue)
                categoryExpression = (p) => p.CategoryId == categoryId.Value;
            else
                categoryExpression = (p) => true;

            if (supplierId.HasValue)
                supplierExpression = (p) => p.SupplierId == supplierId.Value;
            else
                supplierExpression = (p) => true;

            Expression<Func<Product, bool>> query = (p) => categoryExpression.Invoke(p) && supplierExpression.Invoke(p);
            return _productRepository.FilterBy(query.Expand()).ToList();
        }

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void UpdateProduct(Product product)
        {
            UsingTransaction(() =>
            {
                _productRepository.Update(product);
            });
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void AddProduct(Product product)
        {
            UsingTransaction(() =>
            {
                _productRepository.Add(product);
            });
        }
    }
}
