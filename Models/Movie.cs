using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [Range(1950, 2050)]
        public int Year { get; set; }

        [ForeignKey("Director")]
        public int DirectorId { get; set; }
        public Director? Director { get; set; }

        public ICollection<Review> Reviews { get; set; } = [];

    }
}
