using Microsoft.EntityFrameworkCore;

namespace DellChallenge.D1.Api.Dal
{
    /// <summary>
    /// A ProductsContext instance represents a session with the database and can be used to
    /// query and save instances of your entities. DbContext is a combination of the
    /// Unit Of Work and Repository patterns.
    /// </summary>
    public class ProductsContext : DbContext
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ProductsContext class using the specified options.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public ProductsContext(DbContextOptions options)
            : base(options)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the products for the context.
        /// </summary>
        public DbSet<Product> Products
        {
            get;
            set;
        }
        #endregion
    }
}