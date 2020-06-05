using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MyMarketPlaceCoolProducts.Creationals;
using MyMarketPlaceCoolProducts.DAO;
using MyMarketPlaceCoolProducts.DTO;
using MyMarketPlaceCoolProducts.Models;
using MyMarketPlaceCoolProducts.Repositories;
using MyMarketPlaceCoolProducts.Services;

namespace MyMarketPlaceCoolProducts
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ProductDbSettings>(
                Configuration.GetSection(nameof(ProductDbSettings)));
            services.AddSingleton<IProductDbSettings>(sp =>
                sp.GetRequiredService<IOptions<ProductDbSettings>>().Value);

            services.AddSingleton<IService, ProductService>();
            services.AddSingleton<IRepository<Product, string>, MemoryProductRepository>();
            services.AddSingleton<IFactory<Product, ProductDTO>, ProductFactory>();

            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: "Products")
                .Options;
            ProductDbContext ProductDbContext = new ProductDbContext(options);
            services.AddSingleton<ProductDbContext>(ProductDbContext);
            services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
