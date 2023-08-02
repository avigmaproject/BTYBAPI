using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface ICoupon_Master_Data
    {
        public List<dynamic> AddUpdateCoupon_Master_Data(Coupon_Master_DTO model);
        public List<dynamic> Get_Coupon_MasterDetailsDTO(Coupon_Master_DTO_Input model);
    }
}