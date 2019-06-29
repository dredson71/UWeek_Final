using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Plan> Plans { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<Suscription> Suscriptions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>()
                .HasKey(a => new { a.UserId, a.IngredientId });

            modelBuilder.Entity<DishIngredient>()
                .HasKey(d => new { d.DishId, d.IngredientId });
            modelBuilder.Entity<Order>()
                .HasKey(o => new { o.DishId, o.SuscriptionId });
        }

    }
}
