using Microsoft.AspNetCore.Mvc;
using CuentasDiarias.Services.WebApi.Helpers;
using System.Text;
using CuentasDiarias.Services.WebApi.Modules.Swagger;
using CuentasDiarias.Services.WebApi.Modules.Injection;
using CuentasDiarias.Services.WebApi.Modules.Mapper;
using CuentasDiarias.Services.WebApi.Modules.Feature;
using CuentasDiarias.Services.WebApi.Modules.Authentication;
using CuentasDiarias.Services.WebApi.Modules.Validator;
using CuentasDiarias.Services.WebApi.Modules.Watchdog;
using HealthChecks.UI.Client;
using CuentasDiarias.Services.WebApi.Modules.HealthCheck;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WatchDog;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var config = builder.Configuration;

        // Add services to the container.

        string myPolicy = "miPolitica";


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        //
        //builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));//se registra el mapeo de los dto e intidades y viceversa

        builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
          .AddNewtonsoftJson(options =>
          {
              options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
          });


        //ConfigurationValue = builder.Configuration["CadenaConexion"];

        //builder.Configuration.GetSection(Config.OriginCors));
        //
        //Archivo de configuracion json en memoria en la clase appsettings
        var appconfig = builder.Configuration.GetSection("Config");
        builder.Services.Configure<AppSettings>(appconfig);

        builder.Services.AddMapper();
        builder.Services.AddFeature(config);      

        builder.Services.InjectionRegistration();
        builder.Services.AddSwagger();
        builder.Services.Authentication(config);
        builder.Services.AddValidator();
        builder.Services.AddHelthCheck(config);

        //builder.Services.AddWatchDogs(config);

        var appSetting = appconfig.Get<AppSettings>();

        var key = Encoding.ASCII.GetBytes(appSetting.Secret);
        var Issuer = appSetting.Issuer;
        var Audience = appSetting.Audience;

		builder.Services.AddAuthorization(options =>
				options.AddPolicy("ElevatedRights", policy =>
			policy.RequireRole("Administrator", "PowerUser", "BackupAdministrator"))
		  );

		var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //} 

        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API de Cuentas v1");
        });


        app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.MapHealthChecksUI();

        app.MapHealthChecks("/healthcheck", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

		

		//Agregando las credenciales para conectarse a watchdog
		//app.UseWatchDog(conf =>
		//{
		//    conf.WatchPagePassword = "admin";
		//    conf.WatchPageUsername = "admin";
		//});
		//app.UseHealthChecks("/health", new HealthCheckOptions
		//{
		//    Predicate = _ => true,
		//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
		//    ResultStatusCodes =
		//        {
		//            [HealthStatus.Healthy] = StatusCodes.Status200OK,
		//            [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
		//            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
		//        },
		//}).UseHealthChecksUI(setup =>
		//{
		//    setup.ApiPath = "/health";
		//    setup.UIPath = "/health-ui";
		//});

		app.Run();
    }
}

#region "BasurasOld"


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(myPolicy,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:60468").
//                                              AllowAnyHeader().
//                                              AllowAnyMethod();
//                      });
//});

//builder.Services.AddSingleton<DapperContext>();
//builder.Services.AddScoped<IBancoApplication,BancoApplication>(); //1 vez por solicitud
//builder.Services.AddScoped<IBancoDomain,BancoDomain>();
//builder.Services.AddScoped<IBancoRepository, BancoRepository>();

//builder.Services.AddScoped<IUsersApplication,UsersApplication>();
//builder.Services.AddScoped<IUsersDomain, UsersDomain>();
//builder.Services.AddScoped<IUsersRepository, UsersRepository>();
//builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>)); //TypeOf yab que es una clase generica <T>


//autentificacion agregando atributos, para el token de tipo



//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
//    {
//        Version = "v1",
//        Title = "Cuentas Diarias  API",
//        Description = "Prueba de la Web API ",
//        TermsOfService = new Uri("https://example.com/terms"),
//        Contact = new OpenApiContact
//        {
//            Name = "Jorge Soto",
//            Url = new Uri("https://example.com/contact")
//        },
//        License = new OpenApiLicense
//        {
//            Name = "Example License",
//            Url = new Uri("https://example.com/license")
//        }
//    });

//    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        Name = "Authorization"
//    });

//    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
//        {
//            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
//                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
//                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
//                            Id = "Bearer"


//                    }
//                },
//                new string[] {}
//        }
//    });
//});


//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    //x.Events = new JwtBearerEvents
//    //{
//    //    OnTokenValidated = context =>
//    //    {
//    //        var userId = int.Parse(context.Principal.Identity.Name); //Valida que el context que el token se agrego, pueden ir mas valores
//    //        return Task.CompletedTask;
//    //    },
//    //    OnAuthenticationFailed = context =>
//    //    {
//    //        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
//    //        {
//    //            context.Response.Headers.Add("Token-Expire", "true");
//    //        }

//    //        return Task.CompletedTask;
//    //    }
//    //};
//    x.Audience = Audience;
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;//No es necesario almacenar el token
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        //son los parametros en que se validara el token
//        ClockSkew = TimeSpan.FromDays(1),
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = signingKey,
//        ValidateIssuer = false,
//        ValidIssuer = issuer,
//        ValidateAudience = true,
//        ValidAudience = audience,
//        ValidateLifetime = true,
//        AuthenticationType = JwtBearerDefaults.AuthenticationScheme
//        //validar la diferencia en la horas - no se valida la hora por eso se coloca en 0
//    };
//});


//builder.Services.AddAuthentication(options => {
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = true,
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidIssuer = issuer,
//        ValidAudience = audience,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
//    };
//});

//builder.Services.AddAuthorization();

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(o =>
//{
//    o.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = issuer,
//        ValidAudience = audience,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),        
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true
//    };

//    o.Audience = audience;
//});
#endregion

