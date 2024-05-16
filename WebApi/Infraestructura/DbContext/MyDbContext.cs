using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebApi.Modelo;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DbContext_V
{
    public  class MyDbContext : DbContext
    {
        public MyDbContext() { }
		public virtual DbSet<Cliente> Customers { get; init; }
        public virtual DbSet<Producto> Productos { get; init; }

        public MyDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>();
        }
    }
}

//  modelBuilder.Entity<Cliente>();
