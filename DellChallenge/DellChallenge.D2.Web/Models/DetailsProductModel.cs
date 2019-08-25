using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D2.Web.Models
{
    /// <summary>
    /// The details for a product model.
    /// </summary>
    public class DetailsProductModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Required(ErrorMessage = "Name is mandatory.")]
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