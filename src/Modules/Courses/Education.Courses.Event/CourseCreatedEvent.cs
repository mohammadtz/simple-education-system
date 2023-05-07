using Education.Common.Contracts;

namespace Education.Courses.Event;

public class CourseCreatedEvent : IntegrationEvent
{
    public CourseCreatedEvent(Guid id, DateTime occurredOn) : base(id, occurredOn)
    {
    }
}