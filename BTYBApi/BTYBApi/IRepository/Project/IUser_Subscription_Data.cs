using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUser_Subscription_Data
    {
        public List<dynamic> AddUpdateUser_Subscription_Data(User_Subscription_DTO model);
        public List<dynamic> Get_User_SubscriptionDetailsDTO(User_Subscription_DTO_Input model);
    }
}
