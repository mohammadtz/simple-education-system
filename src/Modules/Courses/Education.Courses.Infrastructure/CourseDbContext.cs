using Education.Courses.Domain.Courses;
using Education.Courses.Domain.Registrations;
using Microsoft.EntityFrameworkCore;

namespace Education.Courses.Infrastructure;

public class CourseDbContext : DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {

    }

    public DbSet<Registration> Registrations { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseDbContext).Assembly);
    }
}