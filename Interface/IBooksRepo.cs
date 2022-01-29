using System.Collections;
using System.Collections.Generic;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibApp.Data
{
    public interface IBooksRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        EntityEntry<Book> AddBook(Book book);
        int Save();
    }
}