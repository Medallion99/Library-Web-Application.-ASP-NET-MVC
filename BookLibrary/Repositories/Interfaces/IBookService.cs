using BookLibrary.Models.Entity;

namespace BookLibrary.Repositories.Interfaces
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Update(Book model);
        bool Delete(int id);
        Book FindById(int id);
        IEnumerable<Book> GetAll();
        public Task<List<Book>> SearchBooksAsync(string search);
        public List<Book> Fetch (int id);
    }
}
