using Microsoft.EntityFrameworkCore;

namespace personalsiteapi.Models{

    public class PersonalSiteDbContext: DbContext{
         public PersonalSiteDbContext(DbContextOptions<PersonalSiteDbContext> options)
            :base(options){
            }

            public DbSet<School> Schools {get; set;}
    }
}