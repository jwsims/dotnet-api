using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Template.Core.Data.Pagination;
using Template.Data;
using Template.Data.Entities;
using Template.Services.Production;
using Template.Web.Models.Production;

namespace Template.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDataContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("LaptopConnection"))
            );

            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
            services.Configure<PagingOptions>(this.Configuration.GetSection("DefaultPagingOptions"));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IWorkOrderService, WorkOrderService>();

            services
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Mapper.Initialize(config => { config.CreateMap<Product, ProductViewModel>(); });

            app.UseMvc();
        }
    }
}