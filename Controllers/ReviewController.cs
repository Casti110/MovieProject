using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using MovieProject.Data;
using MovieProjectWebAPI.DTO;

namespace MovieProjectWebAPI.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly MovieContext _context;

    public ReviewController(MovieContext context){
        _context = context;

        
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll(){
        return await _context.Reviews
        .Select( or => new ReviewDTO
        {
            Id = or.Id,
            Rating = or.Rating,
            Description = or.Description,
            MovieId = or.MovieId,

        }).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDTO>> GetReviewByID(int id)
    {
        var review = await _context.Reviews.FindAsync(id);

        if(review == null)
        {
            return NotFound();
        }

        var reviewDTO = new ReviewDTO
        {
            Id = review.Id,
            Rating = review.Rating,
            Description = review.Description,
            MovieId = review.MovieId,

        };

            return Ok(reviewDTO);
    }

    [HttpPost]
    public async Task<ActionResult> PostMovie(ReviewDTO reviewDTO)
    {
        var otherReview = new Review
        {
            UserName = reviewDTO.UserName,
            Rating = reviewDTO.Rating,
            Description = reviewDTO.Description,
            MovieId = reviewDTO.MovieId,
        };



        _context.Reviews.Add(otherReview);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReviewByID), new {id = reviewDTO.Id}, reviewDTO);

    }
        

    }
}
