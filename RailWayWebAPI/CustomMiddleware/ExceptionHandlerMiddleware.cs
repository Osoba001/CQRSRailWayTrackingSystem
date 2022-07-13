using RailWayModelLibrary.Exception;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RailWayWebAPI.CustomMiddleware
{
    public class ExceptionHandlerMiddleware //: IMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.logger = logger;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (DomainNotFoundException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(e.Message);
            }
            catch (DomainValidationException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(e.Message);
            }
            catch (ArgumentException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(e.Message);
            }
            catch (NullReferenceException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(e.Message);
            }
            catch (StackOverflowException e)
            {
                logger.LogError($"Something went wrong {e}");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                logger.LogError($"Something went wrong {e}");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(e.Message);
                
            }
        }
    }
}
