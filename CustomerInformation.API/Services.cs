
using HR.Harmony.Query.Handler;
using MediatR;
using MediatR.Pipeline;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//2using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;

using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Customer.Information.CommandHandler;

namespace Customer.Information.Api.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSms(this IServiceCollection services, IConfiguration configuration)
        {

          

            return services;
        }

    
     



        public static IServiceCollection AddDataContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QueryContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), e =>
            {
                e.EnableRetryOnFailure(2);
               
            }));

            services.AddDbContext<CommandContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), e =>
            {
                e.EnableRetryOnFailure(2);
              
            }));

       

          

            services.AddTransient<IDbConnection>((connection) => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            

            return services;
        }
    }
}