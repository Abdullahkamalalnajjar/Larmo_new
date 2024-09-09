using Larmo.Core.Repository;
using MediatR;

namespace Larmo.Core.Application.Notifications.MakeAsRead;

internal sealed class MakeAsReadCommandHandler(INotificationRepository notificationRepository)
    : IRequestHandler<MakeAsReadCommand>
{
    public async Task Handle(MakeAsReadCommand request, CancellationToken cancellationToken)
    {
        var notification = await notificationRepository.GetByIdAsync(request.GetId(), cancellationToken);
        if (notification is null)
            throw new NullReferenceException("notification not found");

        notification.IsChecked = true;
        await notificationRepository.UpdateAsync(notification, cancellationToken);
    }
}