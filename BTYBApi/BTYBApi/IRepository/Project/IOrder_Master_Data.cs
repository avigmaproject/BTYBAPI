using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IOrder_Master_Data
    {
        public List<dynamic> AddUpdateOrder_Master_Data(Order_Master_DTO model);
        public List<dynamic> Get_Order_MasterDetailsDTO(Order_Master_DTO_Input model);
    }
}