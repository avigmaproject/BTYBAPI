using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUP_Price_Master_Data
    {
        public List<dynamic> AddUpdateUP_Price_Master_Data(UP_Price_Master_DTO model);
        public List<dynamic> Get_UP_Price_MasterDetailsDTO(UP_Price_Master_DTO_Input model);
    }
}
