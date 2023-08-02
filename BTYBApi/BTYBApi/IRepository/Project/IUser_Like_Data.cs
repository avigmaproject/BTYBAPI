using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUser_Like_Data
    {
        public List<dynamic> AddUpdateUser_Like_Data(User_Like_DTO model);
        public List<dynamic> Get_User_LikeDetailsDTO(User_Like_DTO_Input model);
    }
}
