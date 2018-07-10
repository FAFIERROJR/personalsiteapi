using Microsoft.EntityFrameworkCore;

namespace personalsiteapi.Models{

    public class PersonalSiteDbContext: DbContext{
         public PersonalSiteDbContext(DbContextOptions<PersonalSiteDbContext> options)
            :base(options){
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<School>()
                .HasAlternateKey(s => s.Name)
                .HasName("AlternateKey_Name");
        }

            public DbSet<School> Schools {get; set;}
    }
}