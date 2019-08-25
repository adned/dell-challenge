using System;
using System.Collections.Generic;
using System.Net.Http;

using DellChallenge.D1.Contracts;

using Microsoft.Extensions.Options;

namespace DellChallenge.D2.Web.Helpers
{
    /// <summary>
    /// The HTTP wrapper used to access the external service.
    /// </summary>
    public class HttpWrapper
    {
        #region Fields
        /// <summary>
        /// The configuration for HTTP wrapper.
        /// </summary>
        private IOptions<ExternalServiceConfig> _serverConfig;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of HttpWrapper class.
        /// </summary>
        /// <param name="serverConfig">The configuration for the HTTP wrapper.</param>
        public HttpWrapper(IOptions<ExternalServiceConfig> serverConfig)
        {
            _serverConfig = serverConfig;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets data from the external server.
        /// </summary>
        /// <returns>The full list of products.</returns>
        public IEnumerable<ProductDto> GetData()
        {
            IEnumerable<ProductDto> result = new List<ProductDto>();

            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                response = client.GetAsync(_serverConfig.Value.ApiUrl).GetAwaiter().GetResult();
            }

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<IEnumerable<ProductDto>>().GetAwaiter().GetResult();
                }
                else
                {
                    throw new ApplicationException($"Code: {response.StatusCode}, Details: {response.ReasonPhrase}.");
                }
            }

            return result;
        }

        /// <summary>
        /// Gets data from the external server.
        /// </summary>
        /// <param name="id">The ID of the product to be read rom the server.</param>
        /// <returns>The product with the specified ID or null in case not found.</returns>
        public ProductDto GetData(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            ProductDto result = null;

            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                response = client.GetAsync(_serverConfig.Value.ApiUrl + "//" + id).GetAwaiter().GetResult();
            }

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<ProductDto>().GetAwaiter().GetResult();
                }
                else
                {
                    throw new ApplicationException($"Code: {response.StatusCode}, Details: {response.ReasonPhrase}.");
                }
            }

            return result;
        }

        /// <summary>
        /// Posts data to the server.
        /// </summary>
        /// <param name="productDetails">The details of the produc to be created on the server.</param>
        /// <returns>The created product on the server side.</returns>
        public ProductDto PostData(DetailsProductDto productDetails)
        {
            if (productDetails == null)
            {
                throw new ArgumentNullException("productDetails");
            }

            ProductDto result = null;

            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                response = client.PostAsJsonAsync<DetailsProductDto>(_serverConfig.Value.ApiUrl, productDetails).GetAwaiter().GetResult();
            }

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<ProductDto>().GetAwaiter().GetResult();
                }
                else
                {
                    throw new ApplicationException($"Code: {response.StatusCode}, Details: {response.ReasonPhrase}.");
                }
            }

            return result;
        }

        /// <summary>
        /// Deletes the product from the server.
        /// </summary>
        /// <param name="id">The ID of the product to be deleted.</param>
        /// <returns>The product that was deleted on the server.</returns>
        public ProductDto DeleteData(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            ProductDto result = null;

            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                response = client.DeleteAsync(_serverConfig.Value.ApiUrl + "//" + id).GetAwaiter().GetResult();
            }

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<ProductDto>().GetAwaiter().GetResult();
                }
                else
                {
                    throw new ApplicationException($"Code: {response.StatusCode}, Details: {response.ReasonPhrase}.");
                }
            }

            return result;
        }

        /// <summary>
        /// Updates the product on the server.
        /// </summary>
        /// <param name="id">The ID of the product to be updated.</param>
        /// <param name="productDetails">The details to update product with.</param>
        /// <returns>The updated product on server side.</returns>
        public ProductDto PutData(string id, DetailsProductDto productDetails)
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            if (productDetails == null)
            {
                throw new ArgumentNullException("productDetails");
            }

            ProductDto result = null;

            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                response = client.PutAsJsonAsync<DetailsProductDto>(_serverConfig.Value.ApiUrl + "//" + id, productDetails).GetAwaiter().GetResult();
            }

            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<ProductDto>().GetAwaiter().GetResult();
                }
                else
                {
                    throw new ApplicationException($"Code: {response.StatusCode}, Details: {response.ReasonPhrase}.");
                }
            }

            return result;
        }
        #endregion
    }
}