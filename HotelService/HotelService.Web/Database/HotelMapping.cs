using AutoMapper.Configuration;

namespace HotelService.Web.Database
{
    public class HotelMapping :MapperConfigurationExpression
    {
        public HotelMapping()
        {
            CreateMap<HotelModel,HotelDbModel>().ReverseMap();
        }
    }
}