using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
