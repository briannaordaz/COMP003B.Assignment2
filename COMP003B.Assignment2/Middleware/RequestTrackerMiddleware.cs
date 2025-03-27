namespace COMP003B.Assignment2.Middleware;

public class RequestTrackerMiddleware
{
   //fields
   private readonly RequestDelegate _next; 
   private readonly ILogger _logger;

   //constructor
   public RequestTrackerMiddleware(RequestDelegate next, ILogger<RequestTrackerMiddleware> logger)
   {
      _next = next;
      _logger = logger;
   }

   public async Task Invoke(HttpContext context)
   {
      
      Console.WriteLine($"[Request] {context.Request.Method} {context.Request.Path}"); 
      
      await _next(context);
      
      Console.WriteLine($"[Response] {context.Response.StatusCode}");      
      
   }
}