using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models.Entity
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public string? TotalPages { get; set; }
        public int GenreId { get; set; }
        [Required]
        public string Description { get; set; }
        public string? GenreName { get; set; }

        [NotMapped]
        public List<SelectListItem>? GenreList { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        public Genre Genre { get; set; }
    }
}
