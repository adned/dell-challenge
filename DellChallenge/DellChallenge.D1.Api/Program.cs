using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DellChallenge.D1.Api
{
    /// <summary>
    /// The class that represents the current application. 
    /// </summary>
    public class Program
    {
        #region Methods
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">The command arguments when launching the application (if any).</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the host for the application.
        /// </summary>
        /// <param name="args">The command arguments when launching the application (if any).</param>
        /// <returns>The obtained host builder.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        #endregion
    }
}