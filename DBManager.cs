using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore
{
    public class DBManager
    {
        private readonly DBContext _context;

        public DBManager([FromServices] DBContext context)
        {
            _context = context;
        }

        public DBManager AddBook(BookModel bookModel)
        {
            try
            {
                _context.Books.Add(bookModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                bookModel.ID= 0;
                _context.Books.Add(bookModel);
                _context.SaveChanges();
            }

            return this;
        }

        public DBManager AddBookToCart(int bookID, int quantity)
        {
            var book = _context.Books.SingleOrDefault(x => x.ID == bookID);
            if (book == null)
            {
                return this;
            }

            var cartItem = _context.Carts.SingleOrDefault(x => x.BookID == bookID);
            if (cartItem == null)
            {
                _context.Carts.Add(new CartModel { BookID = bookID, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
                _context.Carts.Update(cartItem);
            }

            _context.SaveChanges();
            return this;
        }

        public DBManager RemoveBook(int ID)
        {
            var book = _context.Books.SingleOrDefault(x => x.ID == ID);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return this;
        }

        public DBManager RemoveBookFromCart(int bookID)
        {
            var cartItem = _context.Carts.SingleOrDefault(x => x.BookID == bookID);
            if (cartItem == null)
            {
                return this;
            }
            else
            {
                _context.Carts.Remove(cartItem);
            }
            _context.SaveChanges();
            return this;
        }

        public DBManager UpdateBook(BookModel bookModel)
        {
            var book = _context.Books.Update(bookModel);
            _context.SaveChanges();
            return this;
        }

        public BookModel GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.ID == id);
            return book;
        }

        public List<BookModel> GetBooks()
        {
            return _context.Books.ToList();
        }

        public List<BookModel> GetBooksInCart()
        {
            var bookModels = _context.Books
                .Join(_context.Carts, b => b.ID, c => c.BookID, (b, c) => new BookModel
                {
                    ID = b.ID,
                    Author = b.Author,
                    Title = b.Title,
                    Price = b.Price,
                    AmountInCart = c.Quantity
                })
                .ToList();

            return bookModels;
        }

    }
}
