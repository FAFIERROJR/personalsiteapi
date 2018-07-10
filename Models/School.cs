namespace personalsiteapi.Models{
    public class School{
        public long Id {get; set;}
        public string ImgUrl {get; set;}
        public string Name {get; set;}
        public string StartYear {get; set;}

        public string EndYear {get; set;}

        public string[] Honors {get; set;}

        // public virtual ICollection<Courses> NotableCourses;

        // public virtual ICollection<Projects> NotableProjects;
    }
}