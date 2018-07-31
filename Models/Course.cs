using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace personalsiteapi.Models{
    public class Course{
        [Key]
        public string CourseName {get; set;}
        [Required]
        public string CourseTitle{get; set;}
        //public ICollection<Project> Projects {get; set;}

        public string SchoolKey {get; set;}
        public School School {get; set;}
    }
}