using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        
        public int  Id { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Name")]
        [Display(Name = " Movie Name")]
        [StringLength(350)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Select Genre")]
        [Display(Name = "Movie Gendre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Quantity")]
        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Release Date")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
    }
}