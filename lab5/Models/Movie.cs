using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [UIHint("LongText")]
        public string Description { get; set; }

        [UIHint("Stars")]
        public int Rating { get; set; }
        public string TrailerLink { get; set; }
    }
}
