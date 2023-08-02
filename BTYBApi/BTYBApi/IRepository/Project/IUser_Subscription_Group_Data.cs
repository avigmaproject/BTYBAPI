using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUser_Subscription_Group_Data
    {
        public List<dynamic> AddUpdateUser_Subscription_Group_Data(User_Subscription_Group_DTO model);
        public List<dynamic> Get_User_Subscription_GroupDetailsDTO(User_Subscription_Group_DTO_Input model);
    }
}