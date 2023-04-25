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
            CreateMap<ElectricalEquipementRequest, ElectricalEquipment>()
            .ReverseMap();
            CreateMap<ElectricalEquipment, ElectricalEquipementDto>()
            .ReverseMap();

            CreateMap<ElectricalMeterRequest, ElectricalMeter>()
            .ReverseMap();
            CreateMap<ElectricalMeter, ElectricityMeterDto>()
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

        }
      
    }
}
