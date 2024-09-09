namespace Larmo.Shared.Common;

public static class PermissionNames
{
    // operations permissions
    public const string CanViewAllOperation = nameof(CanViewAllOperation);
    public const string CanAddOperation = nameof(CanAddOperation);
    public const string CanViewOperationDetails = nameof(CanViewOperationDetails);
    public const string CanUpdateOperation = nameof(CanUpdateOperation);

    // notifications permissions
    public const string CanViewAllNotification = nameof(CanViewAllNotification);
    public const string CanViewAllOwnedNotification = nameof(CanViewAllOwnedNotification);
    public const string CanAddNotification = nameof(CanAddNotification);
    public const string CanViewNotificationDetails = nameof(CanViewNotificationDetails);
    public const string CanUpdateNotification = nameof(CanUpdateNotification);
    public const string CanCheckNotification = nameof(CanCheckNotification);
}