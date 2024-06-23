using Financas.Aplication.Filter;
using Financas.Infra.Persistence.Repositories;
using Financas.Infra.Persistence.Repositories.Interfaces;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories;
using Financas.Persistence.Repositories.Interfaces;
using Financas.Service.Service;
using Financas.Service.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Text;

namespace Financas.Aplication.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void ConfigureService(this WebApplicationBuilder builder)
        {
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Secret") ?? throw new ArgumentNullException("Secret"));
            builder.Services.AddSignalR();
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.EnableAnnotations();
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FINANCAS Api - V1",
                    Version = "v1",
                    Description = "The private Financas TV Api",
                    Contact = new OpenApiContact
                    {
                        Name = "E-mail",
                        Email = "backend-team@financasApi.net"
                    }
                });

                x.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            builder.Services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
            });
        }

        public static void ConfigureDependencies(this WebApplicationBuilder builder)
        {
            // General Services
            builder.Services
           .AddTransient<ITokenService, TokenService>();

            // Library
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("default"));
            });
            NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();

            // Repositories
            builder.Services
                .AddTransient<IAccountRepository, AccountRepository>()
                .AddTransient<IExpensesRepository, ExpensesRepository>()
                .AddTransient<IRevenueRepository, RevenueRepository>()
                .AddTransient<ITransactionRepository, TransactionRepository>()
                .AddTransient<IUserRepository, UserRepository>();              
        }

    }
}
