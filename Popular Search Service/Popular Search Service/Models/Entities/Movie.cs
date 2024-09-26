using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popular_Search_Service.Models.Entities
{
    [Table("Movies")]
    [Index(nameof(Movie.Name), IsUnique = true)]
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
