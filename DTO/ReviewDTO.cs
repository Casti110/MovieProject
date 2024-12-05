using System.ComponentModel.DataAnnotations;

namespace MovieProjectWebAPI.DTO
{
    public class ReviewDTO
    {

        public int Id { get; set; }
        
        public string UserName { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        public string Description { get; set; }
        public int MovieId { get; set; }
    
    }
}
