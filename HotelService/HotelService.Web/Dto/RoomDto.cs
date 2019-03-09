using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotelService.Web.Dto
{
    public class RoomDto
    {

        public int Number { get; set; }
        public int MaxOccupants { get; set; }
        public string Description { get; set; }

        public string Bedding { get; set; }

        public string[] Amenities { get; set; }
    }
}