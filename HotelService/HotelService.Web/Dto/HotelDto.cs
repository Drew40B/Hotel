using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotelService.Web.Dto
{
    public class HotelDto
    {
        public HotelDto()
        {
            Rooms = new List<RoomDto>();
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("rooms")]
        public List<RoomDto> Rooms { get; set; }
    }
}