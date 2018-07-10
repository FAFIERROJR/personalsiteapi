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
        [HttpGet("{id}", Name="GetSchool")]
        public ActionResult<School> getById(long id){
            var school = _context.Schools.Find(id);
            if(school == null){
                return NotFound();
            }
            return school;
        }

        [HttpPost]
        public IActionResult addSchool(School school){
            _context.Schools.Add(school);
            _context.SaveChanges();

            return CreatedAtRoute("GetSchool", new {id = school.Id}, school);
        }
    }
}