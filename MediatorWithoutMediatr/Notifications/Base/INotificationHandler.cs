namespace MediatorWithoutMediatr.Notifications.Base
{
    public interface INotificationHandler<T> where T : IBaseNotification
    {
        Task Handle(T notification, CancellationToken cancellationToken = default);
    }
}
