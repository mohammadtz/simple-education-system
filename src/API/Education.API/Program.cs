using Education.Common.Contracts;
using Education.Common.Services;
using Education.Courses.Application.Services.Commands;
using Education.Courses.Infrastructure;
using Education.Financial.Application.Services.Subscribers;
using Education.Financial.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(
        typeof(CreateCourseCommand).Assembly,
        typeof(Education.Users.Application.Services.Subscribes.CourseCreatedSubscribe).Assembly,
        typeof(StudentRegisteredSubscriber).Assembly);
});

builder.Services.AddTransient<IDispatcher, Dispatcher>();
builder.Services.AddTransient<IEventBus, InMemoryEventBus>();

builder.Services.AddDbContext<CourseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CourseConnection")));

builder.Services.AddDbContext<FinancialDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinancialConnection")));

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
