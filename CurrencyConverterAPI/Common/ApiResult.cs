namespace CurrencyConverterAPI.Common;

public class ApiResult(string message, bool success, object? data = null)
{
    public string Message { get; } = message;

    public bool Success { get; } = success;

    public object? Data { get; } = data;
}

public class ApiResultOk(string message) : ApiResult(message, true);
public class ApiResultNotFound(string message) : ApiResult(message, false);
public class ApiResultUnauthorized(string message) : ApiResult(message, false);
public class ApiResultBadRequest(string message) : ApiResult(message, false);
public class ApiDataResultBadRequest(string message, object? data) : ApiResult(message, false, data);