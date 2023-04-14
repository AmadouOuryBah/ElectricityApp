using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IRenter
    {
        Task<List<RenterDto>> GetAllAsync();
        Task<RenterDto> AddAsync(RenterRequest renter);
        Task<RenterDto> UpdateAsync(int id, RenterRequest renter);
        Task<string> DeleteAsync(int id);
    }
}
