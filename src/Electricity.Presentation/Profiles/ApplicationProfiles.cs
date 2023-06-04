using AutoMapper;
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.DataAccess.Entities;

namespace Electricity.Presentation.Profiles
{
    public class ApplicationProfiles : Profile
    {
        public ApplicationProfiles()
        {
            CreateMap<ElectricalEquipementRequest, ElectricalEquipement>()
            .ReverseMap();
            CreateMap<ElectricalEquipement, ElectricalEquipementDto>()
            .ReverseMap();


            CreateMap<RoomRequest, Room>()
            .ReverseMap();
            CreateMap<Room, RoomDto>()
            .ReverseMap();

            CreateMap<RenterRequest, Renter>()
            .ReverseMap();
            CreateMap<Renter, RenterDto>()
            .ReverseMap();

            CreateMap<BuildingRequest, Building>()
            .ReverseMap();
            CreateMap<Building, BuildingDto>()
            .ReverseMap();

            CreateMap<RoomElectricalEquipementRequest, RoomElectricalEquipement>()
            .ReverseMap();
            CreateMap<RoomElectricalEquipement, RoomElectricalEquipementDto>()
            .ReverseMap();

            CreateMap<ScheduleRequest, Schedule>()
           .ReverseMap();
            CreateMap<Schedule, ScheduleDto>()
            .ReverseMap();

            CreateMap<UserRequest, User>()
          .ReverseMap();
            CreateMap<User, UserDto>()
            .ReverseMap();

            CreateMap<UserRegister, User>()
         .ReverseMap();
            CreateMap<User, UserDto>()
            .ReverseMap();

            CreateMap<ResourceRequest, Resource>()
       .ReverseMap();
            CreateMap<Resource, ResourceDto>()
            .ReverseMap();


        }

    }
}
