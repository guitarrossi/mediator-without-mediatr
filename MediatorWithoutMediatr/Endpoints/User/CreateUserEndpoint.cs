using MediatorWithoutMediatr.Pipeline;
using MediatorWithoutMediatr.UseCases.Course.Create;
using MediatorWithoutMediatr.UseCases.User;

namespace MediatorWithoutMediatr.Endpoints.User
{
    public static class CreateUserEndpoint
    {
        public static void RegisterCreateUserEndpoint(this WebApplication app)
        {
            app.MapPost("/user", async (CreateUser createUser, CreateUserHandler createUserHandler, RequestPipeline pipe, CancellationToken ct) =>
            {
                var response = await pipe.Pipe(createUser, createUserHandler.Handle, ct);

                if (!response.IsSuccess)
                    return Results.BadRequest(response.Errors);

                return Results.Ok(response);
            })
            .WithOpenApi();
        }
    }
}
