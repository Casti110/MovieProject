using MovieProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieProjectWebAPI.DTO
{
    public class DirectorDTO
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

    }
}
