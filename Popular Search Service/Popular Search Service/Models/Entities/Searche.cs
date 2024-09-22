using System.Net;
using System.Net.Http.Headers;

namespace Popular_Search_Service.Models.Entities
{
    public class Searche
    {

        public int Id { get; set; }
        public string Keyword { get; set; } = string.Empty;
        public DateTime Search_Time { get; set; } = DateTime.Now.AddHours(3).ToUniversalTime(); //HttpResponseHeader.Date.GetType(Search_Time);
        public string User_Selection { get; set; }
        public int Movie_Id { get; set; }
      
        //public ICollection<Movie>  Movies { get; set; }
    }
}
