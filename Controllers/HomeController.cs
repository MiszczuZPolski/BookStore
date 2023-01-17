using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBContext _context;

        public HomeController(DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var manager = new DBManager(_context);
            var books = manager.GetBooks();
            return View(books);
        }

        [HttpPost]
        public IActionResult AddToCart(int bookId, int quantity)
        {
            var manager = new DBManager(_context);
            manager.AddBookToCart(bookId, quantity);
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public IActionResult Cart()
        {
            var manager = new DBManager(_context);
            var books = manager.GetBooksInCart();
            return View(books);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int ID)
        {
            var manager = new DBManager(_context);
            manager.RemoveBookFromCart(ID);
            return RedirectToAction("Cart", "Home");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}