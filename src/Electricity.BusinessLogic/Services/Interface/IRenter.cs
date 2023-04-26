using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IRenter
    {
        Task<List<RenterDto>> GetAllAsync();
        Task<RenterDto> AddAsync(RenterRequest renter);
        Task<RenterDto> UpdateAsync(RenterDto renter);
        Task<string> DeleteAsync(int id);

        Task<RenterDto> GetById(int id);


    }
}
