using MC_ComputerSolutions.Interfaces;
using MC_ComputerSolutions.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions
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
            services.AddControllers();

            string SQLConnectionString = Configuration["connectionString:DbConnectionString"];
            services.AddDbContext<AppDbContext>(a => a.UseSqlServer(SQLConnectionString));

            //Cors Enable
            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                    builder =>
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());
            });

            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<IInvoice, InvoiceRepository>();
            services.AddScoped<IInvoiceProducts, InvoiceProductsRepository>();

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
            app.UseCors("MyAllowSpecificOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
