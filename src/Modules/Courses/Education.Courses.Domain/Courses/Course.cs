using Education.Courses.Domain.Registrations;

namespace Education.Courses.Domain.Courses;

public class Course
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;

    public ICollection<Registration> Registrations { get; set; } = new HashSet<Registration>();
}