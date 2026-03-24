using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Titulo)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(t => t.Descricao)
                      .IsRequired()
                      .HasMaxLength(1000);

                entity.Property(t => t.Status)
                      .IsRequired();

                entity.Property(t => t.DataCriada)
                      .IsRequired();
            });
        }
    }
}
