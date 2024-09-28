using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Popular_Search_Service.Data;
using Popular_Search_Service.Models.Dto;
using Popular_Search_Service.Models.Entities;
using System.Diagnostics.Metrics;

namespace Popular_Search_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;
        public SearchesController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]

        public IActionResult GetAllMovies()
        {
            return Ok(dbcontext.Searches.ToList());
        }

        [Route("TOP 20 SEARCHES")]
        [HttpGet]
        public IActionResult GetMostSEARCHEMovies()
        {
            var top20 = dbcontext.Searches.GroupBy(s =>s.User_Selection).Where(c => c.Count() > 1)
                .Select(g => new {movie_name = g.Key, Count = g.Count()}).OrderByDescending(g =>g.Count).Take(20).ToList();
            return Ok(top20);
        }
    }
    }


