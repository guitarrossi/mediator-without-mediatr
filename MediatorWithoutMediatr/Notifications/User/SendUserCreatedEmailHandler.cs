using MediatorWithoutMediatr.Notifications.Base;

namespace MediatorWithoutMediatr.Notifications.User
{
    public class SendUserCreatedEmailHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<SendUserCreatedEmailHandler> _logger;

        public SendUserCreatedEmailHandler(ILogger<SendUserCreatedEmailHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Sending email for created user");
        }
    }
}
