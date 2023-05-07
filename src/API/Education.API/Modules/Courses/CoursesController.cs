using Education.Common.Contracts;
using Education.Common.Dto;
using Education.Courses.Application.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Modules.Courses;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public CoursesController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpGet]
    public async Task<Response> CreateCourse()
    {
        await _dispatcher.ExecuteCommandAsync(new CreateCourseCommand.Command());
        return new Response().Ok();
    }
}