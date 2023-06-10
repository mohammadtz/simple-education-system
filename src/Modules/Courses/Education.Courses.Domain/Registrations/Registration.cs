using Education.Courses.Domain.Courses;

namespace Education.Courses.Domain.Registrations;

public class Registration
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid RegisterUserId { get; set; }

    public Course Course { get; set; } = null!;
}