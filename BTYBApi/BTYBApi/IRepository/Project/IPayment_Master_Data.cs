using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IPayment_Master_Data
    {
        public List<dynamic> AddUpdatePayment_Master_Data(Payment_Master_DTO model);
        public List<dynamic> Get_Payment_MasterDetailsDTO(Payment_Master_DTO_Input model);
    }
}