using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IUP_Highlight_Master_Data
    {
        public List<dynamic> AddUpdateUP_Highlight_Master_Data(UP_Highlight_Master_DTO model);
        public List<dynamic> Get_UP_Highlight_MasterDetailsDTO(UP_Highlight_Master_DTO_Input model);
    }
}
