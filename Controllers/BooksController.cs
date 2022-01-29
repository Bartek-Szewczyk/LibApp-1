using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepo _books;
        private readonly IGenreRepo _genre;

        public BooksController(IBooksRepo books, IGenreRepo genre)
        {
            _books = books;
            _genre = genre;
        }

        public IActionResult Index()
        {
            var books = _books.GetAllBooks();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _books.GetBookById(id);

            return View(book);
        }
        
        public IActionResult Edit(int id)
        {
            var book = _books.GetBookById(id);
            if (book == null) 
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _genre.GetAllGenres()
            };

            return View("BookForm", viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new BookFormViewModel
            {
                Genres = _genre.GetAllGenres()
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Book book)
        {
            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _books.AddBook(book);
            }
            else
            {
                var bookInDb = _books.GetBookById(book.Id);
                bookInDb.Name = book.Name;
                bookInDb.AuthorName = book.AuthorName;
                bookInDb.GenreId = book.GenreId;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.DateAdded = book.DateAdded;
                bookInDb.NumberInStock= book.NumberInStock;
            }

            try
            {
                _books.Save();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Books");
        }
    }
}
