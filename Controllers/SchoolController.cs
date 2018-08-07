using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var school = _context.Schools.Include(s => s.Courses).Single(s => s.SchoolKey == key);
            if(school == null){
                return NotFound();
            }
            return school;
        }

        [HttpGet("{key}/{property}", Name="GetSchoolProperty")]
        public ActionResult<Object> getSchoolProperty(string key, string property){
            var school = _context.Schools.Find(key);
            if(school == null){
                return NotFound();
            }
            switch(property){
                case "EndYear":
                    return school.EndYear;
                case "Gpa":
                    return school.Gpa;
                case "Honors":
                    return school.Honors;
                case "ImgUrl":
                    return school.ImgUrl;
                case "Name":
                    return school.Name;
                case "StartYear":
                    return school.StartYear;
                default:
                    return NotFound();
            }
        }

        [HttpPost]
        public IActionResult addSchool(School school){
            _context.Schools.Add(school);
            _context.SaveChanges();

            return CreatedAtRoute("GetSchool", new {key = school.SchoolKey}, school);
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