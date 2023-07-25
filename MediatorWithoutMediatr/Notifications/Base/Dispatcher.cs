namespace MediatorWithoutMediatr.Notifications.Base
{
    public class Dispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider= serviceProvider;
        }

        public async Task PublishMessage<T>(T message, CancellationToken cancellationToken = default) where T : IBaseNotification
        {
            await Task.WhenAll(
                _serviceProvider.GetRequiredService<IEnumerable<INotificationHandler<T>>>()
                    .Select(h => h.Handle(message, cancellationToken))
                );
            
        }

    }
}
