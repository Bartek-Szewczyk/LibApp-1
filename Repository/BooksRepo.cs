using System.Collections.Generic;
using System.Linq;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibApp.Data
{
    public class BooksRepo : IBooksRepo
    {
        private readonly ApplicationDbContext _context;

        public BooksRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.Include(b => b.Genre)
                .ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Include(b => b.Genre).FirstOrDefault(b => b.Id == id);
        }

        public EntityEntry<Book> AddBook(Book book)
        {
            return _context.Books.Add(book);
        }

        public EntityEntry<Book> RemoveBook(int id)
        {
            return _context.Books.Remove(GetBookById(id));
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}