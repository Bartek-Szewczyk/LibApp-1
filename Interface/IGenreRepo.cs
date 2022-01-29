using System.Collections.Generic;
using LibApp.Models;

namespace LibApp.Data
{
    public interface IGenreRepo
    {
        IEnumerable<Genre> GetAllGenres();
        Genre GetGenreById(int id);
    }
}