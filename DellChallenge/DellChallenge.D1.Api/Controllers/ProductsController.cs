using System.Collections.Generic;

using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Contracts;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D1.Api.Controllers
{
    /// <summary>
    /// Controller for the products.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields
        /// <summary>
        /// The products service to be used.
        /// </summary>
        private readonly IProductsService _productsService;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the products controller.
        /// </summary>
        /// <param name="productsService">The products service.</param>
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets all the available products.
        /// </summary>
        /// <returns>The list of the existing products.</returns>
        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        /// <summary>
        /// Gets the product for the specified identifier.
        /// </summary>
        /// <param name="id">The ID of the product to search for.</param>
        /// <returns>The existing product or 404 in case not found.</returns>
        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Get(string id)
        {
            ActionResult<ProductDto> result;

            var existingProduct = _productsService.Get(id);
            if (existingProduct != null)
            {
                result = Ok(existingProduct);
            }
            else
            {
                result = NotFound($"No product found for ID {id}.");
            }

            return result;
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="newProduct">The details of the product to be created.</param>
        /// <returns>The newly created product.</returns>
        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] DetailsProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        /// <summary>
        /// Deletes the specified product.
        /// </summary>
        /// <param name="id">The ID of the product to be removed.</param>
        /// <returns>The product that was just removed.</returns>
        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Delete(string id)
        {
            ActionResult<ProductDto> result;

            var deletedProduct = _productsService.Delete(id);
            if (deletedProduct != null)
            {
                result = Ok(deletedProduct);
            }
            else
            {
                result = NotFound($"No product to delete found for ID {id}.");
            }

            return result;
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="id">The ID of the product to be updated.</param>
        /// <param name="changedProduct">The details of thew product to update with.</param>
        /// <returns>The updated product.</returns>
        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Put(string id, [FromBody] DetailsProductDto changedProduct)
        {
            ActionResult<ProductDto> result;

            var updatedProduct = _productsService.Update(id, changedProduct);
            if (updatedProduct != null)
            {
                result = Ok(updatedProduct);
            }
            else
            {
                result = NotFound($"No product to update found for ID {id}.");
            }

            return result;
        }
        #endregion
    }
}