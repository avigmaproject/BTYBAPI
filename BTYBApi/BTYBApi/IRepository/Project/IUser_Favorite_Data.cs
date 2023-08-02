using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUser_Favorite_Data
    {
        public List<dynamic> AddUpdateUser_Favorite_Data(User_Favorite_DTO model);
        public List<dynamic> Get_User_FavoriteDetailsDTO(User_Favorite_DTO_Input model);
    }
}
