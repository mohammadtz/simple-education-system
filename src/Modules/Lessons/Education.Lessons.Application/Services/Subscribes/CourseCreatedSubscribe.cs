using Education.Common.Contracts;
using Education.Courses.Event;

namespace Education.Lessons.Application.Services.Subscribes;

public class CourseCreatedSubscribe : IEventSubscriber<CourseCreatedEvent>
{
    public async Task Handle(CourseCreatedEvent notification, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}