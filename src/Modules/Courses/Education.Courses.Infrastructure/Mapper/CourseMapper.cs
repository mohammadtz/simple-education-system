using Education.Courses.Domain.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Courses.Infrastructure.Mapper;

public class CourseMapper : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder
            .HasMany(x => x.Registrations)
            .WithOne(x => x.Course)
            .HasForeignKey(x => x.CourseId)
            .IsRequired();
    }
}