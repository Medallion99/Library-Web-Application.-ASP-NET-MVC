using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models.Entity
{
    public class Genre : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        /*public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]*/
    }
}
