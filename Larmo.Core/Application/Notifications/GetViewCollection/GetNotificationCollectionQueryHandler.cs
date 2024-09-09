using Larmo.Core.Repository;
using Larmo.Shared.Application.Paging;
using Larmo.Shared.Extension;
using MediatR;

namespace Larmo.Core.Application.Notifications.GetViewCollection;

public sealed class GetNotificationCollectionQueryHandler(INotificationRepository notificationRepository)
    : IRequestHandler<GetNotificationCollectionQuery, PageResponse<NotificationResult>>
{
    public async Task<PageResponse<NotificationResult>> Handle(GetNotificationCollectionQuery request, CancellationToken cancellationToken)
    {
        var notifications = await notificationRepository.AsPage(new NotificationSpecification())
            .WithPagingOptions(request, cancellationToken);

        return notifications;
    }
}