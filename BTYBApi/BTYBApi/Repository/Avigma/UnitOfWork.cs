using System.Data;
using System.Data.SqlClient;
using BTYBApi.Data;
using BTYBApi.IRepository;
using BTYBApi.Models;
using Microsoft.Extensions.Options;
using BTYBApi.IRepository.Avigma;
using BTYBApi.IRepository.Project;
using API.Repository.Project;
using BTYBApi.Repository.Project;

namespace BTYBApi.Repository.Avigma
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public IEmailTemplate emailTemplate => new EmailTemplate(_configuration);
        public IUser_Admin_Master_Data user_Admin_Master_Data => new User_Admin_Master_Data(_configuration);
        public IUserMaster_Data userMaster_Data => new UserMaster_Data(_configuration);
        public ICoupon_Master_Data coupon_Master_Data => new Coupon_Master_Data(_configuration); 
        public ISubscription_Master_Data subscription_Master_Data => new Subscription_Master_Data(_configuration);

        public IUP_Price_Master_Data uP_Price_Master_Data => new UP_Price_Master_Data(_configuration);

        public IUP_Tags_Master_Data uP_Tags_Master_Data => new UP_Tags_Master_Data(_configuration);

        public IUser_Comments_Reply_Data user_Comments_Reply_Data => new User_Comments_Reply_Data(_configuration);

        public IUser_Favorite_Data user_Favorite_Data => new User_Favorite_Data(_configuration);

        public IUser_Followers_Data user_Followers_Data => new User_Followers_Data(_configuration);

        public IUser_Like_Data user_Like_Data => new User_Like_Data(_configuration);

        public IUser_Post_Comments_Data user_Post_Comments_Data => new User_Post_Comments_Data(_configuration);

        public IUser_Post_Data user_Post_Data => new User_Post_Data(_configuration);
        public IProvider_Master_Data provider_Master_Data => new Provider_Master_Data(_configuration);
        public INotification_Data notification_Data => new Notification_Data(_configuration);
        public IUP_Highlight_Master_Data uP_Highlight_Master_Data => new UP_Highlight_Master_Data(_configuration);
        public IUser_Subscription_Data user_Subscription_Data => new User_Subscription_Data(_configuration);
        public IOrder_Master_Child_Data order_Master_Child_Data => new Order_Master_Child_Data(_configuration);
        public IUser_Subscription_Group_Data user_Subscription_Group_Data => new User_Subscription_Group_Data(_configuration);
        public IUser_Notification_Data user_Notiffication_Data => new User_Notification_Data(_configuration);
        public IOrder_Master_Data order_Master_Data => new Order_Master_Data(_configuration);
        public IPayment_Master_Data payment_Master_Data => new Payment_Master_Data(_configuration);
    }
}
