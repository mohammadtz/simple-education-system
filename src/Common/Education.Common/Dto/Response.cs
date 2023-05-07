using System.Text.RegularExpressions;
using Education.Common.Constants;
using Microsoft.AspNetCore.Http;

namespace Education.Common.Dto;

public class Response<T>
{
    public int StatusCode { get; set; } = StatusCodes.Status200OK;
    public string? Message { get; set; }
    public string? DebugMessage { get; set; }
    public T? Data { get; set; }

    public Response<T> Ok(T? data = default, string? message = null)
    {
        return new Response<T>
        {
            StatusCode = StatusCodes.Status200OK,
            Message = message,
            Data = data
        };
    }

    public Response<T> NotValid(string? message = null, T? data = default)
    {
        return new Response<T>
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = message,
            Data = data
        };
    }

    public Response<T> NotFound(string message)
    {
        return new Response<T>
        {
            StatusCode = StatusCodes.Status404NotFound,
            Message = message,
            Data = default
        };
    }

    public Response<T> Exception(Exception e)
    {
        return new Response<T>
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Message = Regex.IsMatch(e.Message, MyRegex.EnglishAlphabetRegex)
                ? Messages.InternalServerError
                : e.Message,
            DebugMessage = Regex.IsMatch(e.Message, MyRegex.EnglishAlphabetRegex)
                ? e.InnerException?.Message ?? e.Message
                : null,
            Data = default
        };
    }
}

public class Response
{
    public int StatusCode { get; set; } = StatusCodes.Status200OK;
    public string? Message { get; set; }
    public string? DebugMessage { get; set; }
    public object? Data { get; set; }

    public Response Ok(object? data = default, string? message = null)
    {
        return new Response
        {
            StatusCode = StatusCodes.Status200OK,
            Message = message,
            Data = data
        };
    }

    public Response NotValid(string? message = null, object? data = default)
    {
        return new Response
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = message,
            Data = data
        };
    }

    public Response NotFound(string message)
    {
        return new Response
        {
            StatusCode = StatusCodes.Status404NotFound,
            Message = message,
            Data = default
        };
    }

    public Response Exception(Exception e)
    {
        var isEnglishAlphabet = Regex.IsMatch(e.Message, MyRegex.EnglishAlphabetRegex);

        return new Response
        {
            StatusCode = isEnglishAlphabet
                ? StatusCodes.Status500InternalServerError
                : StatusCodes.Status400BadRequest,
            Message = isEnglishAlphabet
                ? Messages.InternalServerError
                : e.Message,
            DebugMessage = isEnglishAlphabet
                ? e.InnerException?.Message ?? e.Message
                : null,
            Data = default
        };
    }
}