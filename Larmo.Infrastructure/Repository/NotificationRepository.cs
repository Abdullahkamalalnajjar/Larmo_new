using Larmo.Core.Repository;
using Larmo.Domain.Domain;
using Larmo.Infrastructure.Context;
using Larmo.Shared.Persistence;

namespace Larmo.Infrastructure.Repository;

public class NotificationRepository(ApplicationContext context)
    : Repository<Notification>(context), INotificationRepository;