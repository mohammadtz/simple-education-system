using Education.Common.Contracts;
using Education.Courses.Event;

namespace Education.Courses.Application.Services.Commands;

public class CreateCourseCommand
{
    public class Command : ICommand
    {
        public Guid Id { get; }
    }

    public class Handler : ICommandHandler<Command>
    {
        private readonly IEventBus _eventBus;

        public Handler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            // TODO: Handle Create Course
            await _eventBus.Publish(new CourseCreatedEvent(Guid.NewGuid(), DateTime.Now));
        }
    }
}