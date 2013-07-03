using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DavidMVC.Models;

namespace DavidMVC.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/

        public ActionResult ShowCategory(string id)
        {
            var category = CategoryProvider.AllCategories.Find(n => n.CategoryId == id);
            return View(category);
        }

        public ActionResult Index()
        {
            var categoryLs = CategoryProvider.AllCategories;
            return View(categoryLs);
        }
    }
}
