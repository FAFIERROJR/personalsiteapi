using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personalsiteapi.Models;

namespace personalsiteapi.Controllers{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase{
        private readonly PersonalSiteDbContext _context;
        public CourseController(PersonalSiteDbContext context){
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<Course>> GetAll(){
            return this._context.Courses.Include(course => course.School).ToList();
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public ActionResult<Course> Get(string name){
            Course course = _context.Courses.Find(name);
            if(course == null){
                return NotFound();
            }
            return course;
        }

        // GET api/values/5
        [HttpGet("BySchool/{schoolKey}")]
        public ActionResult<Course> GetBySchool(string schoolKey){
            Course course = _context.Courses.Include(c => c.SchoolKey).Single(c => c.SchoolKey == schoolKey);
            if(course == null){
                return NotFound();
            }
            return course;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Course> Post(Course course){
            _context.Add(course);
            _context.SaveChanges();
            return course;
        }

        // DELETE api/values/5
        [HttpDelete("{name}")]
        public ActionResult<Course> Delete(string name){
            Course course = _context.Courses.Find(name);
            if(course == null){
                return NotFound();
            }
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return course;
        }
    }
}
