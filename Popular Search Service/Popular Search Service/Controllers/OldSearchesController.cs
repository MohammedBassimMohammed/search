using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Popular_Search_Service.Data;

namespace Popular_Search_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldSearchesController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;
        public OldSearchesController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]

        public IActionResult GetAlloldSearches()
        {
            return Ok(dbcontext.OldSearches.ToList());
        }
    }
}