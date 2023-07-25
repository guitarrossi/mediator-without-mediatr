using MediatorWithoutMediatr.Commom;

namespace MediatorWithoutMediatr.UseCases.Base
{
    public interface IHandler<T> where  T : IUseCase
    {
        Task<Response> Handle(T request, CancellationToken cancellationToken);
    }
}
