using MongoDB.Driver;
using MongoDB.Entities;
using WebApi.DbContext_V;
using WebApi;
using Microsoft.EntityFrameworkCore;
using WebApi.Aplicacion;
using WebApi.Infraestructura.Repositorio;
using WebApi.Aplicacion.BusinessServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddDbContext<MyDbContext>(options =>
options.UseMongoDB(mongoDBSettings?.AtlasURI ?? "", mongoDBSettings?.DatabaseName ?? ""));

builder.Services.AddScoped<IProducto, ProductoRepositorio>();
builder.Services.AddScoped<IProductoAplicacion, ProductosBS>();

const string dbName = "db_sample2024";

Task.Run(async () =>
{
    await DB.InitAsync("db_sample2024", MongoClientSettings.FromConnectionString($"mongodb+srv://jorge:09mayo84@cluster1.6s6mtsc.mongodb.net/{dbName}?retryWrites=true&w=majority")); //initialize db connection
})
.GetAwaiter()
.GetResult();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
