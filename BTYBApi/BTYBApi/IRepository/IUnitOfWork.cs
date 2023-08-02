using BTYBApi.IRepository.Avigma;
using BTYBApi.IRepository.Project;

namespace BTYBApi.IRepository
{
    public interface IUnitOfWork
    {
        IEmailTemplate emailTemplate { get; }
        IUser_Admin_Master_Data user_Admin_Master_Data { get; }
        IUserMaster_Data userMaster_Data { get; }
        ICoupon_Master_Data coupon_Master_Data { get; }
        ISubscription_Master_Data subscription_Master_Data { get; }
        IUP_Price_Master_Data uP_Price_Master_Data { get; }
        IUP_Tags_Master_Data uP_Tags_Master_Data { get; }
        IUser_Comments_Reply_Data user_Comments_Reply_Data { get; }
        IUser_Favorite_Data user_Favorite_Data { get; }
        IUser_Followers_Data user_Followers_Data { get; }
        IUser_Like_Data user_Like_Data { get; }
        IUser_Post_Comments_Data user_Post_Comments_Data { get; }
        IUser_Post_Data user_Post_Data { get; }
        IProvider_Master_Data provider_Master_Data { get; }
        INotification_Data notification_Data { get; }
        IUP_Highlight_Master_Data uP_Highlight_Master_Data { get; }
        IUser_Subscription_Data user_Subscription_Data { get; }
        IOrder_Master_Child_Data order_Master_Child_Data { get; }
        IUser_Subscription_Group_Data user_Subscription_Group_Data { get; }
        IUser_Notification_Data user_Notiffication_Data { get; }
        IOrder_Master_Data order_Master_Data { get; }
        IPayment_Master_Data payment_Master_Data { get; }
    }
}
