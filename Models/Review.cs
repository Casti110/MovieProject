using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; } 

        [StringLength(50)]

       
        public string? UserName { get; set; }

        [StringLength(1000, ErrorMessage = "only 1000 characters allowed")]
        public string Description { get; set; } 

        [Range(1, 10)]
        public int Rating {get; set;}

        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}
