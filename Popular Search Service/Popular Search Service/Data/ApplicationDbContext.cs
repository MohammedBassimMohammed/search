using Microsoft.EntityFrameworkCore;
using Popular_Search_Service.Models.Entities;

namespace Popular_Search_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void test (ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Movie>().HasOne(x => x.Name).WithMany(c => c.Searches).HasForeignKey(s => s.User_Selection);
        //}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Searche> Searches { get; set; }
        public DbSet<Popular_Searche> Popular_Searches { get; set;}
    }
}
