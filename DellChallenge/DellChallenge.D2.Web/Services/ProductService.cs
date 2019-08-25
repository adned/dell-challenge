using System.Collections.Generic;
using System.Linq;

using DellChallenge.D1.Contracts;
using DellChallenge.D2.Web.Helpers;
using DellChallenge.D2.Web.Models;


namespace DellChallenge.D2.Web.Services
{
    /// <summary>
    /// The service that handles product operations.
    /// </summary>
    internal class ProductsService : IProductsService
    {
        #region Fields
        /// <summary>
        /// The HTTP wrapper used to access the external service.
        /// </summary>
        private readonly HttpWrapper _httpWrapper;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of ProductService class.
        /// </summary>
        /// <param name="httpWrapper">The HTTP wrapper used to access the external service.</param>
        public ProductsService(HttpWrapper httpWrapper)
        {
            _httpWrapper = httpWrapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets all the existing products.
        /// </summary>
        /// <returns>The obtained list of products.</returns>
        public IEnumerable<ProductModel> GetAll()
        {
            var products = _httpWrapper.GetData();
            return products.Select(p => MapToModel(p));
        }

        /// <summary>
        /// Gets the product with the specified indentifier.
        /// </summary>
        /// <param name="id">The ID of the product to search for.</param>
        /// <returns>The existing product or null in case not found.</returns>
        public ProductModel Get(string id)
        {
            var product = _httpWrapper.GetData(id);
            return MapToModel(product);
        }

        /// <summary>
        /// Adds a new product from the specified details.
        /// </summary>
        /// <param name="newProduct">The details to created product from.</param>
        /// <returns>The added product.</returns>
        public ProductModel Add(DetailsProductModel newProduct)
        {
            var product = _httpWrapper.PostData(MapDetailsFromModel(newProduct));
            return MapToModel(product);
        }

        /// <summary>
        /// Updates the product with the specified details.
        /// </summary>
        /// <param name="id">The ID of the product to be updated.</param>
        /// <param name="productDetails">The details to update product from.</param>
        /// <returns>The updated product or null in case not found.</returns>
        public ProductModel Update(string id, DetailsProductModel productDetails)
        {
            var product = _httpWrapper.PutData(id, MapDetailsFromModel(productDetails));
            return MapToModel(product);
        }

        /// <summary>
        /// Deletes the product with the specified identifier.
        /// </summary>
        /// <param name="id">The ID of the product to be removed.</param>
        /// <returns>The successfully removed product or null in case not found.</returns>
        public ProductModel Delete(string id)
        {
            var product = _httpWrapper.DeleteData(id);
            return MapToModel(product);
        }
        #endregion

        // We can use an auto mapper.
        #region Implementation
        /// <summary>
        /// Maps product details from model to DTO.
        /// </summary>
        /// <param name="productDetails">The product details to be mapped from model.</param>
        /// <returns>The DTO product details entity.</returns>
        private DetailsProductDto MapDetailsFromModel(DetailsProductModel productDetails)
        {
            return new DetailsProductDto
            {
                Category = productDetails.Category,
                Name = productDetails.Name
            };
        }

        /// <summary>
        /// Maps DTO product to model.
        /// </summary>
        /// <param name="product">The product to be mapped to model.</param>
        /// <returns>The model product entity.</returns>
        private ProductModel MapToModel(ProductDto product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Category = product.Category,
                Name = product.Name
            };
        }
        #endregion
    }
}