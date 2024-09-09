using Larmo.Shared.Application.Paging;
using MediatR;

namespace Larmo.Core.Application.Notifications.GetViewCollection;

public class GetNotificationCollectionQuery : PageRequest, IRequest<PageResponse<NotificationResult>>;