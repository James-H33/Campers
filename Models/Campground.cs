using System.ComponentModel.DataAnnotations;

namespace Campers.Models
{
    public class Campground
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 25 characters.")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
