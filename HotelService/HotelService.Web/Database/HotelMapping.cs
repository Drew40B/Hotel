using AutoMapper.Configuration;
using HotelService.Web.Models;

namespace HotelService.Web.Database
{
    public class HotelMapping :MapperConfigurationExpression
    {
        public HotelMapping()
        {
            CreateMap<HotelModel,HotelDbModel>().ReverseMap();
            CreateMap<RoomModel,RoomDbModel>().ReverseMap();
        }
    }
}