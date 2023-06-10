using Education.Common.Contracts;

namespace Education.Courses.Event;

public class StudentRegisteredToCourseEvent : IntegrationEvent
{
    public StudentRegisteredToCourseEvent(Guid id, DateTime occurredOn) : base(id, occurredOn)
    {
    }
}