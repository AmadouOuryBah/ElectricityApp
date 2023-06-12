
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

        public async Task<List<double>> FindHotWaterConsumed(FilterParameter filterParameter)
        {
            var rooms = _roomRepository.GetRoomsByBuilding(filterParameter.BuildingId);

            List<DateTime> dates1 = new List<DateTime>();
            List<DateTime> dates2 = new List<DateTime>();

            foreach (var room in rooms)
            {
                if (room.LeavingDate.Date < new DateTime(01 / 04 / 2023).Date)
                {
                    continue;
                }
                else
                {
                    if (room.LeavingDate == null)
                    {
                        dates1.Add(new DateTime(01 / 04 / 2023));
                    }
                }

                if (room.LeavingDate.Date < new DateTime(30 / 04 / 2023).Date)
                {
                    dates2.Add(room.LeavingDate);
                }
                else
                {
                    dates2.Add(new DateTime(30 / 04 / 2023));
                }

            }

            var  schedules = await GetDaysBySchedule();


            var kdays = new List<double>();

           
           
            for( int i = 1; i < rooms.Count;  i++) 
            {
                TimeSpan time  = dates2[i] - dates1[i];
                double Totaldays = time.Days;
                


                for (int j = 1; j < schedules.Count; j++)
                {
                    if (rooms[i].Schedule.Name == schedules[j].name)
                    {
                        Totaldays = Math.Floor((Totaldays * schedules[j].day) / 7);

                        kdays.Add(Totaldays);
                    } 
                }
                
            }

            var kp = new List<double>();
            var k = new double[rooms.Count];

            for (int i = 1; i < rooms.Count; i++)
            {
                k[i] = kdays[i] * rooms[i].TotalWorkers;

                 kp.Add(k[i]);
            }
            return kp;
        }

        private async Task<List<(string name, int day)>> GetDaysBySchedule()
        {

            var rejimDays = new List<(string, int)>();

            (string name, int day) rejimDay = ("", 0);
                

            var schedules = await _scheduleRepository.GetAllAsync();

            for (int i = 0; i < schedules.Count; i++)
            {
                int kday = 0;
                if (schedules[i].Sun == true)
                {
                    rejimDay = (schedules[i].Name, kday += 1);
                }
                if (schedules[i].Mon == true)
                {
                    rejimDay = (schedules[i].Name, kday += 1);
                }
                if (schedules[i].Tue == true)
                {
                    rejimDay = (schedules[i].Name, kday += 1);
                }
                if (schedules[i].Wed == true)
                {
                    rejimDay = (schedules[i].Name, kday += 1);
                }
                if (schedules[i].Thu == true)
                {
                    rejimDay = (schedules[i].Name, kday += 1);
                }
                if (schedules[i].Fri == true)
                {
                    rejimDay = (schedules[i].Name, kday += 1);
                }
                if (schedules[i].Sat == true)
                {
                    rejimDay = (schedules[i].Name, kday += 1);
                }
                rejimDays.Add(rejimDay);
            }

            return rejimDays;
        }
    }
}
