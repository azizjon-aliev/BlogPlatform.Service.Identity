namespace Identity.Application.Common.Exceptions;

public class CustomBadRequestException(string message) : Exception($"{message}");