using System.Collections.Generic;

using DellChallenge.D2.Web.Models;

namespace DellChallenge.D2.Web.Services
{
    /// <summary>
    /// The interface to be implemented by the products service.
    /// </summary>
    public interface IProductsService
    {
        #region Methods
        /// <summary>
        /// Gets all the existing products.
        /// </summary>
        /// <returns>The obtained list of products.</returns>
        IEnumerable<ProductModel> GetAll();

        /// <summary>
        /// Gets the product with the specified indentifier.
        /// </summary>
        /// <param name="id">The ID of the product to search for.</param>
        /// <returns>The existing product or null in case not found.</returns>
        ProductModel Get(string id);

        /// <summary>
        /// Adds a new product from the specified details.
        /// </summary>
        /// <param name="newProduct">The details to created product from.</param>
        /// <returns>The added product.</returns>
        ProductModel Add(DetailsProductModel newProduct);

        /// <summary>
        /// Updates the product with the specified details.
        /// </summary>
        /// <param name="id">The ID of the product to be updated.</param>
        /// <param name="productDetails">The details to update product from.</param>
        /// <returns>The updated product or null in case not found.</returns>
        ProductModel Update(string id, DetailsProductModel productDetails);

        /// <summary>
        /// Deletes the product with the specified identifier.
        /// </summary>
        /// <param name="id">The ID of the product to be removed.</param>
        /// <returns>The successfully removed product or null in case not found.</returns>
        ProductModel Delete(string id);
        #endregion
    }
}