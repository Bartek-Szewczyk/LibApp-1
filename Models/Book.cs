using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
		[Required]
		[StringLength(255)]
		[Display(Name="Book Name")]
		public string Name { get; set; }
		[Required]
		[Display(Name="Author Name")]
		public string AuthorName { get; set; }
		[Required]
		public Genre Genre { get; set; }
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Display(Name="Release Date")]
		[Required]
		public DateTime ReleaseDate { get; set; }
		[Display(Name="Number in Stock")]
		[Required]
		[Range(1,20, ErrorMessage = "Range between 1 and 20")]
		public int NumberInStock { get; set; }
		public int NumberAvailable { get; set; }
	}

}
