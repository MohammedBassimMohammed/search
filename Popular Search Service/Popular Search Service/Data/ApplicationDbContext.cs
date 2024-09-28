using Microsoft.EntityFrameworkCore;
using Popular_Search_Service.Models.Entities;

namespace Popular_Search_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Searche> Searches { get; set; }
        public DbSet<OldSearches> OldSearches { get; set; }
    }
}
