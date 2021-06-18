using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalE.DAL.SQL;
using TechnicalE.Domain.ExchangeRatesManager;
using TechnicalE.Domain.PurchaseTransactionManager;
using TechnicalE.Interfaces;
using TechnicalE.Interfaces.Generic;
using TechnicalE.Interfaces.Services;
using TechnicalE.Persistance.Generic;
using TechnicalE.Services;
using TechnicalE.Services.ExchangeRate;
using TechnicalE.Services.FormatNumbers;

namespace TechnicalE.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TechnicalEvDbContext>(options => options
                .UseSqlServer(("Name=TechnicalEvDbContext")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();            
            services.AddTransient<IExchangeRateService, ExchangeRateService>();
            services.AddTransient<IExchangeRateManager, ExchangeRateManager>();
            services.AddTransient<IFormatNumbers, FormatNumbers>();
            services.AddTransient<IErrorMessageService, ErrorMessageService>();
            services.AddTransient<IPurchaseTransactionManager, PurchaseTransactionManager>();
            services.AddTransient<IRateConversionService, RateConversionService>();

            services.AddCors();
            services.AddControllers();

            services.AddMvc().AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(options =>
                options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            
            
        }
    }
}
