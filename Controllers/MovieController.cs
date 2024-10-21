using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using MovieProject.Data;

using SQLitePCL;


namespace MovieProject.Controllers;



[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly MovieContext _context;

    public MovieController(MovieContext context){
        _context = context;

        
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAll(){
        return await _context.Movies.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovieByID(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if(movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult> PostMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMovieByID), new {id = movie.Id}, movie);

    }

   

    

}
