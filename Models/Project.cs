using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace personalsiteapi.Models{
    public class Project{
        [Key]
        public string ProjectKey {get; set;}
        [Required]
        public string ProjectName {get; set;}
        public string Description {get; set;}
        public string[] ImgUrlList {get; set;}

        public string CourseName {get; set;}
        public Course Course;
    }
}