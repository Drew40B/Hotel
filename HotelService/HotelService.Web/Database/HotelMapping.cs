using AutoMapper.Configuration;
using HotelService.Web.Models;

namespace HotelService.Web.Database
{
    public class HotelMapping :MapperConfigurationExpression
    {
        public HotelMapping()
        {
            CreateMap<HotelModel,HotelDbModel>()
                .ForMember(x => x.Id,opt => opt.Ignore())
                .ForMember(x => x.Rooms, opt => opt.Ignore());
                
            CreateMap<RoomModel,RoomDbModel>().ReverseMap();
                
        }
    }
}