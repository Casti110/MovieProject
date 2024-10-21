using MovieProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieProjectWebAPI.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Range(1950, 2050)]
        public int? Year { get; set; }

        public int? DirectorId { get; set; }

        
    }
}
