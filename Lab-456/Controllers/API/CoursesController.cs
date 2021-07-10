using Lab_456.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab_456.Controllers.API
{
    public class CoursesController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.ID == id && c.LucturerID == userId);
            if (course.IsCanceled)
            {
                return NotFound();
            }
            course.IsCanceled = true;
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
