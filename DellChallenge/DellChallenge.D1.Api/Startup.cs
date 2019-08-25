using DellChallenge.D1.Api.Dal;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

namespace DellChallenge.D1.Api
{
    /// <summary>
    /// The startup class for the application.
    /// </summary>
    public class Startup
    {
        #region Constructors
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the configuration object for the application.
        /// </summary>
        public IConfiguration Configuration
        {
            get;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Configures DI container here.
        /// </summary>
        /// <param name="services">The all services for the application.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ProductsContext>(options => options.UseInMemoryDatabase("ProductsDb"));
            services.AddTransient<IProductsService, ProductsService>(); // IoC

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Products API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactCors",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                    });
            });
        }

        /// <summary>
        /// Configures the request routes.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The hosting environment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API V1");
            });

            app.UseMvc();
            app.UseCors();
        }
        #endregion
    }
}