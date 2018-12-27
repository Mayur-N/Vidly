using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels 
{
    //ViewModel is an Model created specifically for a view to hold data and rules required for that view.
    //Model folder contains the pure domain Model Clasess, whereas ViewModel folder contains Model for each view.
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}