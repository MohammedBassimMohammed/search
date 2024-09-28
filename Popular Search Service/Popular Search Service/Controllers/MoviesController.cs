using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using Popular_Search_Service.Data;
using Popular_Search_Service.Models.Dto;
using Popular_Search_Service.Models.Entities;
using System;
using System.Data;
using System.Xml.Linq;


namespace Popular_Search_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public MoviesController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        




        [HttpGet]
        public IActionResult getallemployess()
        {
            return Ok(_dbcontext.Movies.ToList());
        }





        [HttpGet("Searche")]
        public async Task<IActionResult> SearchAndAdd(string User_Selection)
        {
            var existingValue = await _dbcontext.Movies.FirstOrDefaultAsync(x => x.Name == User_Selection);
            if (existingValue != null)
            {
                var Searches = new Searche 
                { 
                    User_Selection = existingValue.Name 
                };
                await _dbcontext.Searches.AddAsync(Searches);
                await _dbcontext.SaveChangesAsync();
                return Ok(Searches);
            }
            return NotFound("Value not found in main database.");
        }





        [HttpPut]
        public async Task<IActionResult> updatemovieinfo(int id,UpdateMovieDto UpdateMovieDto)
        {
            var movie = _dbcontext.Movies.Find(id);
            var DuplicateName = await _dbcontext.Movies.AnyAsync(m => m.Name == UpdateMovieDto.Name);
            if (movie == null && DuplicateName)
            {  return NotFound("Movie with the same name already exists.");}
            movie.Name = UpdateMovieDto.Name;
            _dbcontext.SaveChanges();
            return Ok(movie);
        }




        [HttpDelete]
        //[Route("{id:int}")]
        public IActionResult deletemovie(int id)
        {
            var movie = _dbcontext.Movies.Find(id);
            if(movie is null)
            {
                return NotFound();
            }
            _dbcontext.Movies.Remove(movie);
            _dbcontext.SaveChanges();
            return Ok("movie is removed");
        }





        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieDto AddMovieDto)
        {
            var movieEntity = new Movie()

            {
                Name = AddMovieDto.Name
            };
            _dbcontext.Movies.Add(movieEntity);
            var DuplicateName = await _dbcontext.Movies.AnyAsync(m => m.Name == AddMovieDto.Name);
            if(DuplicateName)
            {  return NotFound(); } 
            _dbcontext.SaveChanges();
            return Ok(movieEntity);

        }
    }
}

