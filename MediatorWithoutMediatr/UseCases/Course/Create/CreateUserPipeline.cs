using FluentValidation;
using MediatorWithoutMediatr.Commom;
using System.ComponentModel.DataAnnotations;

namespace MediatorWithoutMediatr.UseCases.Course.Create
{
    public class CreateUserPipeline
    {
        private readonly IServiceProvider _serviceProvider;
        public CreateUserPipeline(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Pipe<TRequest, TResponse>(TRequest request, Func<TRequest, CancellationToken, Task<TResponse>> handler,
          CancellationToken cancellationToken = default  
          ) where TRequest : class 
            where TResponse : Response
        {
            var validator = _serviceProvider.GetService<IValidator<TRequest>>();

            if (validator != null)
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                var failures = validationResult.Errors;

                if (failures.Any())
                {
                    var response = new Response(failures);

                    return response as TResponse;
                }
            }

            var result = await handler(request, cancellationToken);

            return result;
        }
    }
}
