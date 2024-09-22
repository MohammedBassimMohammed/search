using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Popular_Search_Service.Data;
using Popular_Search_Service.Models.Dto;
using Popular_Search_Service.Models.Entities;
using System;
using System.Xml.Linq;

namespace Popular_Search_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;
        public MoviesController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        
        [HttpGet]
        public IActionResult getallemployess()
        {
            return Ok(dbcontext.Movies.ToList());
        }

        [HttpGet("Searche")]
        public async Task<IActionResult> SearchAndAdd(string User_Selection)
        {
            var existingValue = await dbcontext.Movies.FirstOrDefaultAsync(x => x.Name == User_Selection);
            if (existingValue != null)
            {
                var Searches = new Searche { User_Selection = existingValue.Name };
                await dbcontext.Searches.AddAsync(Searches);
                await dbcontext.SaveChangesAsync();
                return Ok(Searches);
            }
            return NotFound("Value not found in main database.");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updatemovieinfo(int id,UpdateMovieDto UpdateMovieDto)
        {
            var movie =dbcontext.Movies.Find(id);
            if(movie == null)
            {  return NotFound();}
            movie.Name = UpdateMovieDto.Name;
            dbcontext.SaveChanges();
            return Ok(movie);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deletemovie(int id)
        {
            var movie = dbcontext.Movies.Find(id);
            if(movie is null)
            {
                return NotFound();
            }
            dbcontext.Movies.Remove(movie);
            dbcontext.SaveChanges();
            return Ok("movie is removed");
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovieDto AddMovieDto)
        {
            var movieEntity = new Movie()
            {
                Name = AddMovieDto.Name
            };

            dbcontext.Movies.Add(movieEntity);
            dbcontext.SaveChanges();
            return Ok(movieEntity);

        }
    }
}

