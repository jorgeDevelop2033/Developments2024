using CuentasDiarias.Services.WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CuentasDiarias.Services.WebApi.Modules.Authentication
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            var appconfig = configuration.GetSection("Config");
            services.Configure<AppSettings>(appconfig);

            var appSetting = appconfig.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSetting.Secret);
            var Issuer = appSetting.Issuer;
            var Audience = appSetting.Audience;


            const string secretKey = "mysupersecret_secretkey!123";
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            SigningCredentials signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            //---
            const string audience = "Audience";
            const string issuer = "Issuer";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };

                o.Audience = audience;
            });

            return services;
        }
    }
}
