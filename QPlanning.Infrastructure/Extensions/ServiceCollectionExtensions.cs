using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using QPlanning.Infrastructure.Auth;
using QPlanning.Infrastructure.Data.Entities;
using QPlanning.Infrastructure.Data.EntityFramework.QPlanningContext;
using System;
using System.Text;

namespace QPlanning.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string SecretKey = "lYh0jU1yZ7SpFOsCMT1osvE7gtzls0lp";
		private static readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

		public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<QPlanningApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString(typeof(QPlanningApplicationContext).Name), b => b.MigrationsAssembly("Web.Api.Infrastructure").CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds)).ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
		}

		public static IdentityBuilder AddIdentityServices(this IServiceCollection services)
		{
			var identityBuilder = services.AddIdentityCore<AppUser>(o =>
			{
				// configure identity options
				o.Password.RequireDigit = true;
				o.Password.RequireLowercase = true;
				o.Password.RequireUppercase = true;
				o.Password.RequireNonAlphanumeric = false;
				o.Password.RequiredLength = 8;
			});

			identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole<int>), identityBuilder.Services);
			return identityBuilder.AddEntityFrameworkStores<QPlanningApplicationContext>();
		}

		public static IConfigurationSection ConfigureJwtServices(this IServiceCollection services, IConfiguration configuration)
		{
			// jwt wire up
			// Get options from app settings
			var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

			// Configure JwtIssuerOptions
			services.Configure<JwtIssuerOptions>(options =>
			{
				options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
				options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
				options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
			});

			return jwtAppSettingOptions;
		}

		public static TokenValidationParameters ConfigureTokenParameters(this IServiceCollection services, IConfigurationSection jwtAppSettingOptions)
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

				ValidateAudience = true,
				ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

				ValidateIssuerSigningKey = true,
				IssuerSigningKey = _signingKey,

				RequireExpirationTime = false,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};
			return tokenValidationParameters;
		}

		public static string GetJwtIssuer(this IServiceCollection services, IConfigurationSection jwtAppSettingOptions)
		{
			var issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
			return issuer;
		}
    }
}