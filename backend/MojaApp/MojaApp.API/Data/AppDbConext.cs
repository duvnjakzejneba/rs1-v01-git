using Microsoft.EntityFrameworkCore;
using MojaApp.API.Controllers.Models; 

namespace MojaApp.API.Controllers.Data
{

    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Studenti => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(

                new Student()
                {
                    Id = 1,
                    Ime = "Zejneba",
                    Prezime = "Duvnjak-Beso",
                    BrojIndeksa = "IB200161",
                    DatumRodjenja = new DateOnly(2002, 4, 29),
                    DatumKreiranja = new DateTime(2026, 11, 13)
                },
                new Student()
                {
                    Id = 2,
                    Ime = "Amer",
                    Prezime = "Beso",
                    BrojIndeksa = "IB200162",
                    DatumRodjenja = null,
                    DatumKreiranja = new DateTime(2026, 11, 13)
                }
                ); 
        }
    }
}