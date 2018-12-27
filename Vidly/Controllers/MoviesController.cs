using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        /// <returns></returns>
        public ActionResult Random()
        {
            /*Below way of passing data to view will work when view needs data from only Model
            however when view needs dara from multiple models then we need to pass ViewModel object to view() which is shown below. 

            var movie = new Movie() { Name = "Shrek!"};
            return View(movie);
            */


            var movie = new Movie { Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "Mayur"},
                new Customer{Id = 2, Name = "Himani"},
                new Customer{Id = 3, Name = "Rahul"},
                new Customer{Id = 4, Name = "Babu"},
                new Customer{Id = 5, Name = "Gopi"},

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);


        }

        public ActionResult Edit(int id)
        {
            return Content("ID = " + id);
        }

        //Movies --> Indes of movies
        //TO make parameters options we have to make them nullable
        //In below example string is already a nullable type hence we donn't have to do anything for sortBy parameter
        //However paramter pageIndex is of type int which is not nullable by default hence we declare it as 'int?' to make it nullable
        public ActionResult Index(int?  pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1; // This is default pageIndex value when it is not passed in http request.

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name"; // This is default sortBy value when it is not passed in http request

            return Content(string.Format("Page Index = {0} , Sort By = {1} ", pageIndex, sortBy));
        }

        ////This method is called by old way of routing i.e. by adding custom route inside RouteConfig.cs
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(string.Format("{0}/{1}",year,month));
        //}

        //Below method is called by new way of routing i.e. adding attributes on top of action method.
        //But to enable attribute route we still have call method   "routes.MapMvcAttributeRoutes()" inside RouteConfig.cs

        //[Route("movies/released2/{month:regex(\\d{2}:range(1,12))}/{year:regex(\\d{4})}")]
        [Route("movies/released2/{month:regex(\\d{2}):range(1 , 12)}/{year:regex(\\d{4})}")]
        public ActionResult ByReleaseDate2(int month, int year)
        {
            return Content(string.Format("{0}/{1}", month, year));
        }

        //Explanation of attribute route in above method
        //[Route("movies/released2/{month:regex(\\d{2}:range(1,12))}/{year:regex(\\d{4})}")]
        //movies/released2/ --? this is URL
        // {month}/{year} --> parameters
        //{month:regex(\\d{2}:range(1,12))} --> parameter with constraints. Using attribute routes we can add multiple constraints.
        // Google to find out more methods (apart from regex() & range()) that can be used to define constraints 
    }
}