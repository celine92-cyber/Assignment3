using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly Assignment3DbContext _moviesdb;


        public HomeController(ILogger<HomeController> logger, Assignment3DbContext moviesdb)
        {
            _logger = logger;
            _moviesdb = moviesdb;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(ApplicationResponse appResponse)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                SearchStorage.AddApplication(appResponse);
                //add new data to database
                _moviesdb.Movies.Add(appResponse);
                _moviesdb.SaveChanges();

                return View("Confirmation", appResponse);
            }
        }

        [HttpGet]
        public IActionResult SearchedList()
        {
            return View(_moviesdb.Movies);
        }

        [HttpPost]
        public IActionResult EditForm(int editId)
        {
            ApplicationResponse movieToEdit = _moviesdb.Movies.FirstOrDefault(s => s.MovieId == editId);
            ViewBag.movieToEdit = movieToEdit;
            return View("EditForm");
        }

        //Edit the database record
        //we got the movieToEdit from the previous EditFrom Method
        [HttpPost]
        public IActionResult Edit(ApplicationResponse movieWithEdits)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.movieToEdit = movieWithEdits;
                return View("EditForm");
            }
            else
            {
                var movieToEdit = _moviesdb.Movies.FirstOrDefault(s => s.MovieId == movieWithEdits.MovieId);
                movieToEdit.Category = movieWithEdits.Category;
                movieToEdit.Title = movieWithEdits.Title;
                movieToEdit.Year = movieWithEdits.Year;
                movieToEdit.Director = movieWithEdits.Director;
                movieToEdit.Rating = movieWithEdits.Rating;
                movieToEdit.Edited = movieWithEdits.Edited;
                movieToEdit.LentTo = movieWithEdits.LentTo;
                movieToEdit.Notes = movieWithEdits.Notes;
                _moviesdb.SaveChanges();
                return View("SearchedList", _moviesdb.Movies);
            }

        }

        //Delete records
        //By matching the deleteId we got from the input, we can delete the correct one that the user wants to delete
        [HttpPost]
        public IActionResult Delete(int deletionId)
        {
            _moviesdb.Remove(_moviesdb.Movies.FirstOrDefault(s => s.MovieId == deletionId));
            _moviesdb.SaveChanges();
            return View("SearchedList", _moviesdb.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
