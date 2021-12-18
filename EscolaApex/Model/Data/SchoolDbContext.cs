using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscolaApex.Model.Data
{
    public class SchoolDbContext:DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()                
                .HasIndex(e => e.CPF)                
                .IsUnique();
        }
    }
}
