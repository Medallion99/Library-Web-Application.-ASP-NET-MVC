using BookLibrary.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _bookService.GetAll();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
