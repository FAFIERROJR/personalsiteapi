using System.ComponentModel.DataAnnotations;

namespace personalsiteapi.Models{
    public class School{
        [Key]
        public string Key {get; set;}
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

        // public virtual ICollection<Courses> NotableCourses;

        // public virtual ICollection<Projects> NotableProjects;
    }
}