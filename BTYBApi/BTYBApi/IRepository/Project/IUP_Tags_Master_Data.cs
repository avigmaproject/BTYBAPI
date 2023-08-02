using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUP_Tags_Master_Data
    {
        public List<dynamic> AddUpdateUP_Tags_Master_Data(UP_Tags_Master_DTO model);
        public List<dynamic> Get_UP_Tags_MasterDetailsDTO(UP_Tags_Master_DTO_Input model);
    }
}
