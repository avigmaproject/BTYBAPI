using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUser_Post_Comments_Data
    {
        public List<dynamic> AddUpdateUser_Post_Comments_Data(User_Post_Comments_DTO model);
        public List<dynamic> Get_User_Post_CommentsDetailsDTO(User_Post_Comments_DTO_Input model);
    }
}
