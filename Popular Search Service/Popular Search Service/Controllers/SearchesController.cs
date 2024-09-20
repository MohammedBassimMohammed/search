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
        public IActionResult getallemployess()
        {
            return Ok(dbcontext.Searches.ToList());
        }

        [HttpPost]
        public IActionResult AddSearcheDto(AddSearcheDto AddSearcheDto)
        {
            var SearchesEntity = new Searche()
            {
                User_Selection = AddSearcheDto.User_Selection,
                Movie_Id = AddSearcheDto.Movie_Id
            };

            dbcontext.Searches.Add(SearchesEntity);
            dbcontext.SaveChanges();
            return Ok(SearchesEntity);
        }
    }
    }


