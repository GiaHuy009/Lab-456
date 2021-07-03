using Lab_456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Lab_456.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses
                .Include(c => c.Lucturer)
                .Include(c => c.category)
                .Where(c => c.DateTime > DateTime.Now);
            return View(upcomingCourses);
        }
    }
}