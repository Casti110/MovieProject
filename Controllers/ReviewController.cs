using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using MovieProject.Data;

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
    public async Task<ActionResult<IEnumerable<Review>>> GetAll(){
        return await _context.Reviews.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReviewByID(int id)
    {
        var review = await _context.Reviews.FindAsync(id);

        if(review == null)
        {
            return NotFound();
        }

        return Ok(review);
    }

    [HttpPost]
    public async Task<ActionResult> PostMovie(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReviewByID), new {id = review.Id}, review);

    }
        

    }
}
