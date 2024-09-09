using MediatR;

namespace Larmo.Core.Application.Notifications.MakeAsRead;

public sealed class MakeAsReadCommand : IRequest
{
    private int _id;
    public void SetId(int notificationId) => _id = notificationId;
    public int GetId() => _id;
}