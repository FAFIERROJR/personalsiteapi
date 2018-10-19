using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personalsiteapi.Models;

namespace personalsiteapi.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly PersonalSiteDbContext _context;

        public ProjectController(PersonalSiteDbContext context){
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Project>> getAll(){
            return _context.Projects.ToList();
        }


        [HttpGet("{key}", Name="GetProject")]
        public ActionResult<Project> getByKey(string key){
            var school = _context.Projects.Single(s => s.ProjectKey == key);
            if(school == null){
                return NotFound();
            }
            return school;
        }

        [HttpGet("/ByCourse/{courseKey}", Name="GetProjectByCourse")]
        public ActionResult<List<Project>> getByCourse(string courseKey){
            var project = _context.Projects.Where(s => s.CourseName == courseKey);
            if(project == null){
                return NotFound();
            }
            return project.ToList();
        }


        [HttpPost]
        public IActionResult addProject(Project project){
            _context.Projects.Add(project);
            _context.SaveChanges();

            return CreatedAtRoute("GetSchool", new {key = project.ProjectKey}, project);
        }

        [HttpPut("{id}")]
        public IActionResult Update(String id, Project project){
            var proj = _context.Projects.Find(id);
            proj.CourseName = project.CourseName;
            proj.Description = project.Description;
            proj.ImgUrlList = project.ImgUrlList;
            proj.ProjectName = project.ProjectName;

            _context.Projects.Update(proj);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{key}", Name="DeleteProject")]
        public ActionResult<Project> deleteByKey(string key){
            var project = _context.Projects.Find(key);
            if(project == null){
                return NotFound();
            }

            _context.Projects.Remove(project);
            return project;
        }
    }
}