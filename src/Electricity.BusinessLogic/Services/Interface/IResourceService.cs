using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IResourceService
    {
        Task<List<ResourceDto>> GetAllAsync();
        Task<ResourceDto> GetById(int id);
        Task<ResourceDto> AddAsync(ResourceRequest resource);
        Task<ResourceDto> UpdateAsync(ResourceDto resource);
        Task<string> DeleteAsync(int id);

    }
}
