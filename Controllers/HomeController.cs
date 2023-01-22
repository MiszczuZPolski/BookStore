using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        [HttpPost]
        public IActionResult UpdateQuantity(int ID, int quantity)
        {
            var manager = new DBManager(_context);
            manager.UpdateBookQuantity(ID, quantity);
            return RedirectToAction("Cart", "Home");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var manager = new DBManager(_context);
            var cartItems = manager.GetCartItems();

            foreach (var item in cartItems)
            {
                var book = _context.Books.SingleOrDefault(x => x.ID == item.BookID);
                book.Amount -= item.Quantity;
                manager.UpdateBook(book);
                manager.RemoveBookFromCart(item.BookID);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}