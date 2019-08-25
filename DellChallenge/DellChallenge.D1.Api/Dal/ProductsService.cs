using System.Collections.Generic;
using System.Linq;

using DellChallenge.D1.Contracts;

namespace DellChallenge.D1.Api.Dal
{
    /// <summary>
    /// The service that handles product operations.
    /// </summary>
    public class ProductsService : IProductsService
    {
        #region Fields
        /// <summary>
        /// The data context for products.
        /// </summary>
        private readonly ProductsContext _context;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of ProductsService class.
        /// </summary>
        /// <param name="context">The data context for products.</param>
        public ProductsService(ProductsContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets all the existing products.
        /// </summary>
        /// <returns>The obtained list of products.</returns>
        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        /// <summary>
        /// Gets the product with the specified indentifier.
        /// </summary>
        /// <param name="id">The ID of the product to search for.</param>
        /// <returns>The existing product or null in case not found.</returns>
        public ProductDto Get(string id)
        {
            ProductDto result = null;

            Product existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                result = MapToDto(existingProduct);
            }

            return result;
        }

        /// <summary>
        /// Adds a new product from the specified details.
        /// </summary>
        /// <param name="newProduct">The details to created product from.</param>
        /// <returns>The added product.</returns>
        public ProductDto Add(DetailsProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();

            var addedDto = MapToDto(product);
            return addedDto;
        }

        /// <summary>
        /// Updates the product with the specified details.
        /// </summary>
        /// <param name="id">The ID of the product to be updated.</param>
        /// <param name="product">The details to update product from.</param>
        /// <returns>The updated product or null in case not found.</returns>
        public ProductDto Update(string id, DetailsProductDto product)
        {
            ProductDto result = null;

            Product existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                UpdateDetailsFromDto(existingProduct, product);
                _context.SaveChanges();
                result = MapToDto(existingProduct);
            }

            return result;
        }

        /// <summary>
        /// Deletes the product with the specified identifier.
        /// </summary>
        /// <param name="id">The ID of the product to be removed.</param>
        /// <returns>The successfully removed product or null in case not found.</returns>
        public ProductDto Delete(string id)
        {
            ProductDto result = null;

            Product existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                _context.SaveChanges();
                result = MapToDto(existingProduct);
            }

            return result;
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Maps DTO product details to data representation.
        /// </summary>
        /// <param name="productDetails">The details of the product to be mapped to data.</param>
        /// <returns>The data product entity.</returns>
        private Product MapToData(DetailsProductDto productDetails)
        {
            return new Product
            {
                Category = productDetails.Category,
                Name = productDetails.Name
            };
        }

        /// <summary>
        /// Maps data representation of the product to the corresponding DTO entity.
        /// </summary>
        /// <param name="product">The data product to be mapped.</param>
        /// <returns>The obtained DTO for the product.</returns>
        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }

        /// <summary>
        /// Updates the existing data product with the provided details.
        /// </summary>
        /// <param name="existingProduct">The existing data product.</param>
        /// <param name="productDetails">The details to update existing product with.</param>
        private void UpdateDetailsFromDto(Product existingProduct, DetailsProductDto productDetails)
        {
            existingProduct.Name = productDetails.Name;
            existingProduct.Category = productDetails.Category;
        }
        #endregion
    }
}