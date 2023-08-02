using BTYBApi.Models.Avigma;

namespace BTYBApi.IRepository
{
    public interface INotification_Data
    {
        Task<ResponseModel> SendNotification(NotificationMasterDTO notificationModel);
        Task<string> SendNotificationToken(NotificationMasterTokenDTO notification);
    }
}
