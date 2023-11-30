using BookLibrary.Models.Data;
using BookLibrary.Models.Entity;
using BookLibrary.Repositories.Interfaces;

namespace BookLibrary.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext _ctx;

        public GenreService(DatabaseContext context)
        {
            this._ctx = context;
        }
        public bool Add(Genre model)
        {
            try
            {
                _ctx.Genre.Add(model);
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
                _ctx.Genre.Remove(data);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre FindById(int id)
        {
            return _ctx.Genre.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _ctx.Genre.ToList(); 
        }

        public bool Update(Genre model)
        {
            try
            {
                _ctx.Genre.Update(model);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
