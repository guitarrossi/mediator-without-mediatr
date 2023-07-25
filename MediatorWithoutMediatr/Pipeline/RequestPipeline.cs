using FluentValidation;
using MediatorWithoutMediatr.Commom;
using System.ComponentModel.DataAnnotations;

namespace MediatorWithoutMediatr.Pipeline
{
    public class RequestPipeline
    {
        private readonly IServiceProvider _serviceProvider;
        public RequestPipeline(IServiceProvider serviceProvider)
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
