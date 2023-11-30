using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models.Entity
{
    public class Reviews
    {
        public int Id { get; set; }
        [Required]
        public string PublisherName { get; set; }
    }
}
