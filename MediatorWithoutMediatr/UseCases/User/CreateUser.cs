using MediatorWithoutMediatr.Commom;
using MediatorWithoutMediatr.Interfaces;
using MediatorWithoutMediatr.Mapper;
using MediatorWithoutMediatr.Notifications.Base;
using MediatorWithoutMediatr.Notifications.User;
using MediatorWithoutMediatr.UseCases.Base;

namespace MediatorWithoutMediatr.UseCases.User
{
    public record CreateUser(string Email, string Password, string Name) : IUseCase
    {
    }

    public record CreateUserResponse(Guid Id) { }

    public record CreateUserHandler : IHandler<CreateUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly Dispatcher _dispatcher;

        public CreateUserHandler(IUserRepository userRepository, Dispatcher dispatcher)
        {
            _userRepository = userRepository;
            _dispatcher = dispatcher;
        }

        public async Task<Response> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = request.MapToUser();

            _userRepository.Add(user);

            var userCreatedEvent = new UserCreatedEvent();

            await _dispatcher.PublishMessage(userCreatedEvent);

            var resultado = new CreateUserResponse(user.Id);

            return new Response(resultado);

        }
    }
}
