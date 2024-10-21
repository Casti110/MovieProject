using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using MovieProject.Data;
using MovieProjectWebAPI.DTO;

namespace MovieProjectWebAPI.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly MovieContext _context;

        public DirectorController(MovieContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDTO>>> GetAll()
        {
            return await _context.Directors
            .Select( od => new DirectorDTO
            {
                Id = od.Id,
                Name = od.Name,
                
            }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDTO>> GetDirectorByID(int id)
        {
            var director = await _context.Directors.FindAsync(id);

            if (director == null)
            {
                return NotFound();
            }

            var directorDTO = new DirectorDTO
            {
                
                Id = director.Id,
                Name = director.Name,
                

            };
            return directorDTO;
        }

        [HttpPost]
        public async Task<ActionResult> PostDirector(DirectorDTO directorDTO)
        {   
            var otherDirector = new Director
            {
                Name = directorDTO.Name,
                
            };

            _context.Directors.Add(otherDirector);
            await _context.SaveChangesAsync();

            directorDTO.Id = otherDirector.Id;

            return CreatedAtAction(nameof(GetDirectorByID), new { id = directorDTO.Id }, directorDTO);

        }

    }
    
    }

