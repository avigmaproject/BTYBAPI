using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IOrder_Master_Child_Data
    {
        public List<dynamic> AddUpdateOrder_Master_Child_Data(Order_Master_Child_DTO model);
        public List<dynamic> Get_Order_Master_ChildDetailsDTO(Order_Master_Child_DTO_Input model);
    }
}