using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUser_Followers_Data
    {
        public List<dynamic> AddUpdateUser_Followers_Data(User_Followers_DTO model);
        public List<dynamic> Get_User_FollowersDetailsDTO(User_Followers_DTO_Input model);
    }
}
