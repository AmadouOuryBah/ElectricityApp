
using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
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
        private readonly IMapper _mapper;
        public ConsumptionComputationService(IRoomRepository roomRepository, IResourceRepository resourceRepository,
            IGenericRepository<Schedule> scheduleRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _resourceRepository = resourceRepository;
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<List<RenterByConsumedWater>> HotWaterConsumedByRenter(FilterParameter filterParameter)
        {
            var rooms = _roomRepository.GetRoomsByBuilding(filterParameter.BuildingId);
            var roomsFiltered = new List<RoomFiltered>();

       
            foreach (var room in rooms)
            {
                /*if (room.LeavingDate.Date < new DateTime(01 / 04 / 2023).Date)
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
                }*/
                RoomFiltered roomFiltered = new RoomFiltered();
                
                if (room.LeavingDate < new DateTime(filterParameter.Year, filterParameter.Month, 1).Date)
                {
                    continue;
                }
                else if (room.ArrivalDate >= new DateTime(filterParameter.Year, filterParameter.Month, 1).Date) 
                {
                    
                    roomFiltered.ArrivalDate = room.ArrivalDate.Date;
                }
                else if (room.ArrivalDate < new DateTime(filterParameter.Year, filterParameter.Month, 1).Date)
                {
                   
                    roomFiltered.ArrivalDate = new DateTime(filterParameter.Year, filterParameter.Month, 1).Date;
                }


                if (Math.Abs((room.LeavingDate - room.ArrivalDate).Days) <= 30)
                {
                    
                    roomFiltered.LeavingDate = room.LeavingDate.Date;
                }
                else
                {
                   

                    roomFiltered.LeavingDate = new DateTime(filterParameter.Year, filterParameter.Month, 28).AddDays(2);
                }

                roomFiltered.Renter = room.Renter.Name;
                roomFiltered.Room = room.Name;
                roomFiltered.Schedule = room.Schedule.Name;
                roomFiltered.TotalWorkers = room.TotalWorkers;

                
                 roomsFiltered.Add(roomFiltered);

            }

            var  schedules = await GetDaysBySchedule();

            var kdays = new List<double>();

            for( int i = 0; i < roomsFiltered.Count;  i++) 
            {
                double Totaldays = (roomsFiltered[i].LeavingDate - roomsFiltered[i].ArrivalDate).TotalDays;
               
                for (int j = 0; j < schedules.Count; j++)
                {
                    if (roomsFiltered[i].Schedule == schedules[j].name)
                    {
                        Totaldays = Math.Floor((Totaldays * schedules[j].day) / 7);

                        kdays.Add(Totaldays);
                    } 
                }
                
            }

            var kp = new List<double>();
            var k = new double[roomsFiltered.Count];
            var rentersByConsumedWater = new List<RenterByConsumedWater>();

           

            for (int i = 0; i < roomsFiltered.Count; i++)
            {
                //k[i] = kdays[i] * roomsFiltered[i].TotalWorkers;
                // kp.Add(k[i]);

                var renterByConsumedWater = new RenterByConsumedWater();

                renterByConsumedWater.Renter = roomsFiltered[i].Renter;
                renterByConsumedWater.Room = roomsFiltered[i].Room;
                renterByConsumedWater.Quantity = kdays[i] * roomsFiltered[i].TotalWorkers;

                rentersByConsumedWater.Add(renterByConsumedWater);
            }
            return rentersByConsumedWater ;
        }
        /// <summary>
        /// getting tuple of number of day by rejim
        /// </summary>
        /// <returns></returns>
        private async Task<List<(string name, int day)>> GetDaysBySchedule()
        {
            var rejimDays = new List<(string, int)>();

            (string name, int day) rejimDay = ("", 0);
                

            var schedules = await _scheduleRepository.GetAllAsync();

            for (int i = 0; i < schedules.Count; i++)
            {

                if (schedules[i].Sun == true)
                {
                    rejimDay.day += 1;
                }
                if (schedules[i].Mon == true)
                {
                    rejimDay.day += 1;
                }
                if (schedules[i].Tue == true)
                {
                    rejimDay.day += 1;
                }
                if (schedules[i].Wed == true)
                {
                    rejimDay.day += 1;
                }
                if (schedules[i].Thu == true)
                {
                    rejimDay.day += 1;
                }
                if (schedules[i].Fri == true)
                {
                    rejimDay.day += 1;
                }
                if (schedules[i].Sat == true)
                {
                    rejimDay.day += 1;
                }

                rejimDay.name = schedules[i].Name;
                rejimDays.Add(rejimDay);
            }
          
            return rejimDays;
        }
    }
}
