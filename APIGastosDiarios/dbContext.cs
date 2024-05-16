using APIGastosDiarios.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
namespace APIGastosDiarios
{
	public class dbContext : DbContext
	{
		public dbContext(DbContextOptions<dbContext> options) : base(options) 
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			
		}

		public DbSet<RegistrosGastos> Gastos { get; set; }
	}
}

