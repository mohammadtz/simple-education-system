using Education.Common.Contracts;
using Education.Common.Dto;
using Education.Courses.Domain.Registrations;
using Education.Courses.Event;
using Education.Courses.Infrastructure;

namespace Education.Courses.Application.Services.Commands;

public abstract class RegisterToCourse
{
    public class Command : ICommand<Response>
    {
        public Command(string courseId)
        {
            CourseId = courseId;
        }

        public string CourseId { get; }
        public Guid Id { get; }
    }

    public class Handler : ICommandHandler<Command, Response>
    {
        private readonly CourseDbContext _courseDbContext;
        private readonly IEventBus _eventBus;

        public Handler(CourseDbContext courseDbContext, IEventBus eventBus)
        {
            _courseDbContext = courseDbContext;
            _eventBus = eventBus;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var registration = new Registration
                {
                    CourseId = Guid.Parse(request.CourseId),
                    RegisterUserId = Guid.NewGuid()
                };
                
                await _courseDbContext.Registrations.AddAsync(registration, cancellationToken);
                await _courseDbContext.SaveChangesAsync(cancellationToken);

                await _eventBus.Publish(new StudentRegisteredToCourseEvent(registration.Id, DateTime.Now));

                return response.Ok(new
                {
                    registration.Id
                });
            }
            catch (Exception e)
            {
                return response.Exception(e);
            }
        }
    }
}