namespace DellChallenge.D1.Contracts
{
    /// <summary>
    /// The details for a product DTO.
    /// </summary>
    public class DetailsProductDto
    {
        #region Properties
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