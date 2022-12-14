using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace AdoptPetProject.Models
{
    public class AdoptPetContext : DbContext
    {
        //public AdoptPetContext():base("AdoptPetDB")
        //{
        //    Database.SetInitializer(new AdoptPetInitilializer());
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:localhost,1433;Database=AdoptPetDB;User ID=SA;Password=root159963;Encrypt=False");
        }
        
    }
}

