namespace personalsiteapi.Models{
    public class School{
        public long Id {get; set;}
        public string Name {get; set;}
        public string StartYear;
        public string EndYear;
        public string[] Honors;

        // public virtual ICollection<Courses> NotableCourses;

        // public virtual ICollection<Projects> NotableProjects;
    }
}