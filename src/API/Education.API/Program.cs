using Education.Common.Contracts;
using Education.Common.Services;
using Education.Courses.Application.Services.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(
        typeof(CreateCourseCommand).Assembly,
        typeof(Education.Lessons.Application.Services.Subscribes.CourseCreatedSubscribe).Assembly,
        typeof(Education.Users.Application.Services.Subscribes.CourseCreatedSubscribe).Assembly);
});

builder.Services.AddTransient<IDispatcher, Dispatcher>();
builder.Services.AddTransient<IEventBus, InMemoryEventBus>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
