using BTYBApi.Models.Project;
using System.Data;

namespace BTYBApi.IRepository.Project
{
    public interface IUser_Post_Data
    {
        public List<dynamic> AddUpdateUser_Post_Data(User_Post_DTO model);
        public List<dynamic> Get_User_PostDetailsDTO(User_Post_DTO_Input model);
        public List<dynamic> AddUpdateUser_Post_Like_Share_Data(User_Post_Like_Share_DTO model);
        public List<dynamic> Get_User_Post_SearchDetailsDTO(User_Post_Search_DTO model);
        public DataSet Get_UserDetailsByPost_Story(User_Post_DTO model);
        public string SendNotification(User_Notification_DTO user_Notification_DTO);
        public List<dynamic> AddUpdateProduct_Shop_Purchase_Count_Data(Product_Shop_Purchase_DTO model);
    }
}
