using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CaryCrimes.Models;

namespace CaryCrimes.Controllers
{
    public class CategoryController : ApiController
    {

        public string[] Get()
        {
            return CrimeData.Categories;
        }
    }
}
