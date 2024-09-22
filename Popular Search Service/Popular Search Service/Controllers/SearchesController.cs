using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Popular_Search_Service.Data;
using Popular_Search_Service.Models.Dto;
using Popular_Search_Service.Models.Entities;

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
        public IActionResult getallemployess() => Ok(dbcontext.Searches.ToList());
    }
    }


