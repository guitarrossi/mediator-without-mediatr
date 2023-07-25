using MediatorWithoutMediatr.Notifications.Base;

namespace MediatorWithoutMediatr.Notifications.User
{
    public class GeneratePointsForCreatedUserHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<GeneratePointsForCreatedUserHandler> _logger;

        public GeneratePointsForCreatedUserHandler(ILogger<GeneratePointsForCreatedUserHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Generating points for created user");
        }
    }
}
