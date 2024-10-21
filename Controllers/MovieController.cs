using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using MovieProject.Data;
using MovieProjectWebAPI.DTO;

namespace MovieProjectWebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly MovieContext _context;

    public MovieController(MovieContext context){
        _context = context;

        
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAll(){
        return await _context.Movies
        .Select(om => new MovieDTO
        {
            Id = om.Id,
            Title = om.Title,
            Year = om.Year,
            DirectorId = om.DirectorId,


        }).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDTO>> GetMovieByID(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if(movie == null)
        {
            return NotFound();
        }

        var movieDTO = new MovieDTO
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,
            DirectorId = movie.DirectorId,

        };

        return Ok(movieDTO);
    }

    [HttpPost]
    public async Task<ActionResult> PostMovie(MovieDTO movieDTO)
    {
        var movie = new Movie
        {
            Title = movieDTO.Title,
            Year = movieDTO.Year,
            DirectorId = movieDTO.DirectorId,
        };

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMovieByID), new {id = movieDTO.Id}, movieDTO);

    }

   

    

}
