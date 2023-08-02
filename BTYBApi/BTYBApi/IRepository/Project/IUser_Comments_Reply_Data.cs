using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUser_Comments_Reply_Data
    {
        public List<dynamic> AddUpdateUser_Comments_Reply_Data(User_Comments_Reply_DTO model);
        public List<dynamic> Get_User_Comments_ReplyDetailsDTO(User_Comments_Reply_DTO_Input model);
    }
}