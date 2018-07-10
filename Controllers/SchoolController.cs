using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using personalsiteapi.Models;

namespace personalsiteapi.Controllers
{
    [Route("api/schools")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly PersonalSiteDbContext _context;

        public SchoolController(PersonalSiteDbContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<School>> getAll(){
            return _context.Schools.ToList();
        }
        [HttpGet("{key}", Name="GetSchool")]
        public ActionResult<School> getByKey(string key){
            var school = _context.Schools.Find(key);
            if(school == null){
                return NotFound();
            }
            return school;
        }

        [HttpPost]
        public IActionResult addSchool(School school){
            _context.Schools.Add(school);
            _context.SaveChanges();

            return CreatedAtRoute("GetSchool", new {key = school.Key}, school);
        }

        [HttpDelete("{key}", Name="DeleteSchool")]
        public ActionResult<School> deleteByKey(string key){
            var school = _context.Schools.Find(key);
            if(school == null){
                return NotFound();
            }

            _context.Schools.Remove(school);
            return school;
        }
    }
}