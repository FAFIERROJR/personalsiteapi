using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace personalsiteapi.Models{
    public class School{
        [Key]
        public string SchoolKey {get; set;}
        [Required]
         public string Name {get; set;}
        [Required]
        public string ImgUrl {get; set;}
        [Required]
        public double Gpa{get; set;}
        [Required]
        public string StartYear {get; set;}
        [Required]
        public string EndYear {get; set;}
        [Required]
        public string[] Honors {get; set;}

        public List<Course> Courses;

    }
}