using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace La_Mia_Pizzeria_1.Database {
    public class PizzeriaContext : IdentityDbContext<IdentityUser> {
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<CategoriaPizza> CategoriePizze { get; set; }
        public DbSet<Ingrediente> ingredientis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //Metodo standard per leggere il json per recuperare la connection string
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("ConnectionsKey.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzeriaDatabase"));
            //metodo opzionale adoperando una classe statica con attributo statico contenente la connection string
            //optionsBuilder.UseSqlServer(Settings.ConnectionKey);

        }

    }
}
