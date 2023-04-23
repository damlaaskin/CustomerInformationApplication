using Customer.Information.Api.Configurations;
using Customer.Information.CommandHandler;
using Customer.Information.Query.Requests;
using Customer.Information.Query.Responses;
using Customer.Information.QueryHandler.Caching;
using HR.Harmony.Query.Handler;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            LogConfiguration();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            LogConfiguration();
            services.AddDataContexts(Configuration);
            services.AddMediatR();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerInformation.API", Version = "v1" });
            });
            services.AddScoped<ICacheManager, CacheManager>();
            services.AddDbContext<QueryContext>(c => c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), e =>
            {
                e.EnableRetryOnFailure(2);
            }));
            services.AddDbContext<CommandContext>(c => c.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), e =>
            {
                e.EnableRetryOnFailure(2);
            }));



            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerInformation.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void LogConfiguration()
        {

            //Log.Logger = new LoggerConfiguration()
            //            .Enrich.FromLogContext()
            //            .MinimumLevel.Information()
            //            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //            .MinimumLevel.Override("System", LogEventLevel.Warning)
            //            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Configuration.GetValue<string>("ElasticsearchConnection")))
            //            {
            //                AutoRegisterTemplate = true
            //            })
            //            .CreateLogger();

            Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Debug()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                   .MinimumLevel.Override("System", LogEventLevel.Warning)
                   .Enrich.FromLogContext()
                   .WriteTo.RollingFile(Configuration.GetSection("RollingFilePathFormat").Value)
                   .CreateLogger();

        }
    }
}
