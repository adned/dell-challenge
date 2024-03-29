﻿namespace DellChallenge.D1.Api.Dal
{
    /// <summary>
    /// The product entity at data level.
    /// </summary>
    public class Product
    {
        #region Properties
        /// <summary>
        /// Gets or sets the ID of the product (GUID).
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        public string Category
        {
            get;
            set;
        }
        #endregion
    }
}