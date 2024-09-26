//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Popular_Search_Service.Data;

//namespace Popular_Search_Service.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class Popular_SearchesController : ControllerBase
//    {
//        private readonly ApplicationDbContext dbcontext;
//        public Popular_SearchesController(ApplicationDbContext dbcontext)
//        {
//            this.dbcontext = dbcontext;
//        }

//        [HttpGet]
//        public IActionResult getallemployess()
//        {
//            return Ok(dbcontext.Popular_Searches.ToList());
//        }
//    }
//}
