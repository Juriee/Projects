using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie =new Movie() {Name = "Sherk!"};
            ViewData["Movies"] = "Preguson Jurie";
            ViewBag.Movie = movie;
            var customers=new List<Customer>
            {
                new Customer {Id = 1,Name = "Customer1 "},
                new Customer {Id = 2,Name = "Customer2 "},
            new Customer {Id =3,Name = "Customer3 "}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers =  customers
            };
            
           return View(viewModel);
       
        
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            var movieModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            ViewData["addMovie"] = "Edit Movie";
            if (ModelState.IsValid)
            {
              
                if (movie == null)
                {
                    return HttpNotFound();
                }
                else
                {
                  
                    return View("AddNewMovie", movieModel);
                }
            }
            else
            {
                return View("AddNewMovie", movieModel);
            }

           
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }
        public ActionResult AddNewMovie()
        {
            var genre = _context.Genres.ToList();
            var movieViewModel = new NewMovieViewModel
            {
                Genres = genre
            };
            ViewData["addMovie"] = "New Movie";
            return View(movieViewModel);
            
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.Id == 0)
                {
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDb = _context.Movies.SingleOrDefault(d => d.Id == movie.Id);
                    movieInDb.Name = movie.Name;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.NumberInStock = movie.NumberInStock;
                }

                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                var genre = _context.Genres.ToList();
                var movieViewModel = new NewMovieViewModel
                {
                    Genres = genre
                };
                ViewData["addMovie"] = "New Movie";
                return View(movieViewModel);
            }
        }


    }
}