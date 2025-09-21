using Microsoft.EntityFrameworkCore;

namespace P01_StudentSystem_student.Data
{
    internal class StudentSystemContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=PC-46;Initial Catalog=EFproject519-student;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true);
            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .IsUnicode(false)
                .IsRequired(false);
            modelBuilder.Entity<Student>()
             .Property(s => s.Birthday)
             .IsRequired(false);
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true);
            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsUnicode(true)
                .IsRequired(false);
            modelBuilder.Entity<Resource>()
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true);
            modelBuilder.Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false);
            modelBuilder.Entity<Homework>()
                .Property(h => h.Content)
                .IsUnicode(false);
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

        }
    }
}
