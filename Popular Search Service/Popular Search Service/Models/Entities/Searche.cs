using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Net.Http.Headers;

namespace Popular_Search_Service.Models.Entities
{
    public class Searche
    {
        public int Id { get; set; }
        public DateTime Search_Time { get; set; } = DateTime.Now.ToUniversalTime();
        public string User_Selection { get; set; }
    }
}
