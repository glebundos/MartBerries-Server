using MartBerries_Server.Application.Handlers.CommandHandlers;
using MartBerries_Server.Application.Handlers.QueryHandlers;
using MartBerries_Server.Application.Helpers;
using MartBerries_Server.Core.Repositories;
using MartBerries_Server.Core.Repositories.Base;
using MartBerries_Server.Infrastructure.Data;
using MartBerries_Server.Infrastructure.Repositories;
using MartBerries_Server.Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MartBerries_Server.API
{
    public static class ServerModule
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            var builder = WebApplication.CreateBuilder();
            services.AddControllers().AddJsonOptions(
            o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            services.AddEndpointsApiExplorer();
            var connectionString = builder.Configuration.GetConnectionString("MartBerries.Data");
            services.AddDbContext<ServerContext>(m => m.UseSqlServer(connectionString/*, ServerVersion.AutoDetect(connectionString)*/));
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MartBerries.API",
                    Version = "v1"
                });
            });

            services.AddCors();
            services.AddAutoMapper(typeof(Program));
            services.AddMediatR(typeof(GetAllSupplierHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
            //services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            services.AddTransient<IMoneyTransferRepository, MoneyTransferRepository>();
            services.AddTransient<IOrderedProductRepository, OrderedProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductTransferRepository, ProductTransferRepository>();
            services.AddTransient<ISupplierProductRepository, SupplierProductRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
