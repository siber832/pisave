using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzeria.Database
{
    public class PizzeriaContext : DbContext
    {

        public PizzeriaContext()
        {

        }

        public PizzeriaContext(DbContextOptions<PizzeriaContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(e => e.Loguin).IsUnique(true);

           /* modelBuilder.Entity<User>()
                .IsUnique(c => c.Loguin);
                */
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Comment> Coments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        //.UseMySql(@"Server=localhost;database=Pizzeria;uid=root;pwd=root;");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;");
            }
        }
    }
}
