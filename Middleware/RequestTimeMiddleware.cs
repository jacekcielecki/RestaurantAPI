using System.Diagnostics;
using System.Threading;

namespace RestaurantAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch _stopwatch;
        private readonly ILogger<RequestTimeMiddleware> _logger;
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = _stopwatch.Elapsed;
            if (ts.Seconds > 4)
            {
                var message = 
                    $"Request [{context.Request.Method} at {context.Request.Path} took {ts.Seconds} seconds";
                _logger.LogInformation(message);
            }
            // Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);


        }
    }
}
