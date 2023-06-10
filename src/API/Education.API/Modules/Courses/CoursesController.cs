using Education.Common.Contracts;
using Education.Common.Dto;
using Education.Courses.Application.Dto.Requests;
using Education.Courses.Application.Services.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Modules.Courses;

[ApiController]
[Route("api/[controller]/[action]")]
public class CoursesController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public CoursesController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<Response> CreateCourse()
    {
        var response = await _dispatcher.ExecuteCommandAsync(new CreateCourseCommand.Command());
        return response;
    }

    [HttpPost]
    public async Task<Response> RegisterToCourse([FromBody] RegisterToCourseRequest request)
    {
        var result = await _dispatcher.ExecuteCommandAsync(new RegisterToCourse.Command(request.CourseId));
        return result;
    }
}