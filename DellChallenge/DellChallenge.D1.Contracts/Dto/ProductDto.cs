﻿namespace DellChallenge.D1.Contracts
{
    /// <summary>
    /// The product DTO.
    /// </summary>
    public class ProductDto : DetailsProductDto
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ID for the product.
        /// </summary>
        public string Id
        {
            get;
            set;
        }
        #endregion
    }
}