namespace BookLibrary.Models.Entity
{
    public class BaseEntity
    {
        public DateTime DateAddedToLibrary { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime DateDeleted { get; set; }

    }
}
