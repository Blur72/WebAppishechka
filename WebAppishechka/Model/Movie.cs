using System.ComponentModel.DataAnnotations;

namespace WebAppishechka.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Range(0, 10)]
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
    }
}
