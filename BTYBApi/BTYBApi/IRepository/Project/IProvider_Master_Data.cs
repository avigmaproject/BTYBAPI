using BTYBApi.Models.Project;

namespace BTYBApi.IRepository.Project
{
    public interface IProvider_Master_Data
    {
        public List<dynamic> CreateUpdate_Provider_Master_DataDetails(Provider_Master_DTO model);
    }
}
