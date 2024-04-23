using Microsoft.EntityFrameworkCore;
using static StudentApplication.Controllers.EmployeeController;

namespace StudentApplication.Models
{
   
    public class MyDatabaseDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<University> Universities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=asp.db");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
           // optionsBuilder.EnableSensitiveDataLogging(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().HasKey(r => r.Identifer);

            //modelBuilder.Entity<University>()
            //    .HasMany(e => e.Students)
            //    .WithOne(r=> r.University)
            //    .HasForeignKey(r=> r.UniversityId);

            modelBuilder.Entity<Student>()
                .Property(r => r.Name).IsRequired();

            modelBuilder.Entity<Student>()
               .HasIndex(r => r.Name).IsUnique();

            // .HasColumnType("nvarchar(200)")
            // .HasMaxLength(200);
            //modelBuilder.Entity<Student>()
            //    .Property(r => r.Salary).HasPrecision(18, 3);
        }

    }
}
