using MediatorWithoutMediatr.Pipeline;
using MediatorWithoutMediatr.UseCases.Course.Create;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MediatorWithoutMediatr.Endpoints.Course
{
    public static class CreateCourseEndpoint
    {

        public static void RegisterCreateCourseEndpoint(this WebApplication app)
        {
            app.MapPost("/course", async (CreateCourse createCourse, CreateCourseHandler createCourseHandler, RequestPipeline pipe, CancellationToken ct) =>
            {
                var response = await pipe.Pipe(createCourse, createCourseHandler.Handle, ct);

                if (!response.IsSuccess)
                    return Results.BadRequest(response.Errors);

                return Results.Ok(response);
            })
            .WithOpenApi();
        }
    }
}
