using BookLibrary.Models.Entity;
using BookLibrary.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            this._service = service;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
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
            var record = _service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Succesfully";
                return RedirectToAction(nameof(Add));
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
    }
}
