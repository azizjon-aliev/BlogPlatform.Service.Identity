using System.Net;

namespace Identity.Application.Common.Exceptions;

public class CustomException(string message, HttpStatusCode code = HttpStatusCode.BadRequest)
    : Exception($"{message}")
{
    public HttpStatusCode Code { get; } = code;
};