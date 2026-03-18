using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security;

namespace Lab5.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "pole wymagane")]
        [MaxLength(50, ErrorMessage = "Tytuł nie może przekraczać 50 znaków")]
        public string Title { get; set; }
        [UIHint("LongText")]
        [Required(ErrorMessage = "pole wymagane")]
        public string Description{ get; set; }
        [UIHint("Stars")]
        [Range(1,5, ErrorMessage = "Ocena filmu musi być liczbą pomiędzy 1 a 5")]
        public int Rating { get; set; }
        public string? TrailerLink { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
