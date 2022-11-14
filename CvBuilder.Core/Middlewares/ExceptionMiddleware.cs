namespace CvBuilder.Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[Error]: {ex.Message}");

                if (ex.InnerException != default && !string.IsNullOrWhiteSpace(ex.InnerException.Message))
                {
                    _logger.LogError($"[Error]: {ex.InnerException.Message}");
                }

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new ProblemDetails
                {
                    Status = httpContext.Response.StatusCode,
                    Title = $"""
                    {ex.Message}
                    {ex.InnerException?.Message}
                    """
                }));
            }
        }
    }
}
