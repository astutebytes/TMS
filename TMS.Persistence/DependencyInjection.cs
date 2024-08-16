using TMS.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TMS.Application.Interfaces;
using TMS.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using TMS.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TMS.Application.Common.Constants;
using TMS.Application.Net.Email;
using TMS.Persistence.Net.Email;
using TMS.Persistence.Repositories;
using Hangfire;

namespace TMS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString(AppConstant.DB_NAME), x => x.MigrationsAssembly("TMS.Persistence"));
            });

            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<AppRole>()
            .AddRoleManager<RoleManager<AppRole>>()
            .AddEntityFrameworkStores<DataContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var tokenKey = config[AppConstant.JWT_TOKEN_KEY] ?? throw new Exception("TokenKey not found");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorizationBuilder()
                .AddPolicy(RolesPolicy.ADMIN_POLICY, policy => policy.RequireRole(Roles.ADMIN))
                .AddPolicy(RolesPolicy.ORGANIZER_POLICY, policy => policy.RequireRole(Roles.ORGANIZER))
                .AddPolicy(RolesPolicy.CUSTOMER_POLICY, policy => policy.RequireRole(Roles.CUSTOMER));

            services.AddSingleton<IEmailConfiguration>(config.GetSection("EmailConfiguration").Get<EmailConfiguration>()!);
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IJobService, HangfireJobService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddHangfire(cfg => cfg.UseSqlServerStorage(config.GetConnectionString(AppConstant.DB_NAME)));
            services.AddHangfireServer();

            return services;
        }
    }
}
