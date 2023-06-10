
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Entities;
using Electricity.DataAccess.Repositories.Interface;

namespace Electricity.BusinessLogic.Services
{
    public class ConsumptionComputationService : IConsumptionCalcultationService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IResourceRepository _resourceRepository;
        private readonly IGenericRepository<Schedule> _scheduleRepository;
        public ConsumptionComputationService(IRoomRepository roomRepository, IResourceRepository resourceRepository,
            IGenericRepository<Schedule> scheduleRepository)
        {
            _roomRepository = roomRepository;
            _resourceRepository = resourceRepository;
            _scheduleRepository = scheduleRepository;
        }

        public void FindHotWaterConsumed(FilterParameter filterParameter)
        {
            var rooms = _roomRepository.GetRoomsByBuilding(filterParameter.BuildingId);
        }
    }
}
