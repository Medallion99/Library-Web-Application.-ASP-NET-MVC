using BookLibrary.Models.Data;
using BookLibrary.Models.Entity;
using BookLibrary.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext _ctx;

        public BookService(DatabaseContext context)
        {
            this._ctx = context;
        }
        public bool Add(Book model)
        {
            try
            {
                _ctx.Book.Add(model);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = FindById(id);
                if (data == null)
                {
                    return false;
                }
                else
                    _ctx.Book.Remove(data);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book FindById(int id)
        {
            return _ctx.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var result = _ctx.Book
                        .Join(
                            _ctx.Genre,
                            book => book.GenreId,
                            genre => genre.Id,
                            (book, genre) => new Book
                            {
                                Title = book.Title,
                                GenreId = book.GenreId,
                                Id = book.Id,
                                GenreName = genre.Name,
                                TotalPages = book.TotalPages,
                                ISBN = book.ISBN,
                                ImageUrl = book.ImageUrl,
                                DateAddedToLibrary = book.DateAddedToLibrary,
                                DateDeleted = book.DateDeleted,
                                PublishedDate = book.PublishedDate,
                                Description = book.Description,
                            })
                        .ToList();

            return result;
        }

        public bool Update(Book model)
        {
            try
            {
                _ctx.Book.Update(model);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Book>> SearchBooksAsync(string search)
        {

            var query = _ctx.Book.AsEnumerable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || s.GenreName.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            return query.ToList();
        }

        public List<Book> Fetch(int id)
        {
            var result = _ctx.Book
                     .Where(book => book.Id == id)
                     .ToList();

            return result;
        }
    }
}
