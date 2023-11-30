using BookLibrary.Models.Data;
using BookLibrary.Models.Entity;
using BookLibrary.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        private readonly IGenreService _genreService;
        private readonly DatabaseContext _databaseContext;

        public BookController(IBookService service, IGenreService genreService, DatabaseContext databaseContext)
        {
            this._service = service;
            this._genreService = genreService;
            this._databaseContext = databaseContext;
        }
        public IActionResult Add()
        {
            var model = new Book();
            model.GenreList = _genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.GenreList = _genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(),Selected = a.Id == model.GenreId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Succesfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            var model = _service.FindById(id);
            model.GenreList = _genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();


            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.GenreList = _genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var record = _service.Delete(id);
                return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = _service.GetAll();
            return View(data);
        }
        
        [HttpGet]
        public async Task<IActionResult> Search(string search)
        {
            ViewData["Search"] = search;
            var result = _service.SearchBooksAsync(search);

            return View(await result);
        }

        public IActionResult Fetch(int id)
        {
            var fetch = _service.Fetch(id);
            return View(fetch);
        }

    }
}
