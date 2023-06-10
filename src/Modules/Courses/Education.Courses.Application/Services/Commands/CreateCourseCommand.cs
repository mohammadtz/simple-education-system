using Education.Common.Contracts;
using Education.Common.Dto;
using Education.Courses.Domain.Courses;
using Education.Courses.Event;
using Education.Courses.Infrastructure;

namespace Education.Courses.Application.Services.Commands;

public class CreateCourseCommand
{
    public class Command : ICommand<Response>
    {
        public Guid Id { get; }
    }

    public class Handler : ICommandHandler<Command, Response>
    {
        private readonly IEventBus _eventBus;
        private readonly CourseDbContext _courseDbContext;

        public Handler(IEventBus eventBus, CourseDbContext courseDbContext)
        {
            _eventBus = eventBus;
            _courseDbContext = courseDbContext;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = new Course
            {
                Id = Guid.NewGuid(),
                Title = $"Course-{Guid.NewGuid().ToString().Substring(0, 6)}"
            };

            await _courseDbContext.Courses.AddAsync(entity, cancellationToken);
            await _courseDbContext.SaveChangesAsync(cancellationToken);

            await _eventBus.Publish(new CourseCreatedEvent(Guid.NewGuid(), DateTime.Now));
            return new Response().Ok(new { entity.Id });
        }
    }
}