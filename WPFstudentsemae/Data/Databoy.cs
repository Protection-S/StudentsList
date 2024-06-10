using Microsoft.EntityFrameworkCore;
using WPFstudentsemae.Model;

namespace WPFstudentsemae.Data
{
    public class Databoy : DbContext
    {
        public DbSet<Student> MainStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\lalka\\source\\repos\\WPFstudentsemae\\WPFstudentsemae\\studentData.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("MainStudents");
        }
    }
}
