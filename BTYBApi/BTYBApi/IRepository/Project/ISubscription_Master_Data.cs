using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface ISubscription_Master_Data
    {
        public List<dynamic> AddUpdateSubscription_Master_Data(Subscription_Master_DTO model);
        public List<dynamic> Get_Subscription_MasterDetailsDTO(Subscription_Master_DTO_Input model);
    }
}