using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LibApp.Models;

namespace LibApp.Data
{
    public class GenreRepo : IGenreRepo
    {
        private readonly ApplicationDbContext _context;

        public GenreRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genre.ToList();
        }

        public Genre GetGenreById(int id)
        {
            return _context.Genre.FirstOrDefault(g => g.Id == id);
        }
    }
}