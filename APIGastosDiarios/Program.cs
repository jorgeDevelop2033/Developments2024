using APIGastosDiarios;
using APIGastosDiarios.Aplicacion.GastosBusiness;
using APIGastosDiarios.Aplicacion.Interfaces;
using APIGastosDiarios.Infraestructura.Repositorios;
using APIGastosDiarios.RemoteInterfaces;
using APIGastosDiarios.RemoteServices;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//;
string cadenaConexion = "Server=localhost,1433; Initial Catalog=db_Lab2024; Persist Security Info=False; User ID=sa; Password =183377; MultipleActiveResultSets=False; TrustServerCertificate=True; Connection Timeout=30";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<dbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

builder.Services.AddScoped<IGastosBusiness, GastsoBusiness>();

builder.Services.AddScoped<IGastosRepositorio, GastosRepositorios>();
builder.Services.AddScoped<IProductosServices, ProductosServices>();


builder.Services.AddHttpClient("Productos", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Productos"]!);
});


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

