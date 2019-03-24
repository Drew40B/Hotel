using System.Collections.Generic;
using HotelService.Web.Database;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotelService.Web.Database
{
    public class HotelDbModel
    {
        public HotelDbModel()
        {
            Rooms = new List<RoomDbModel>();
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("rooms")]
        public List<RoomDbModel> Rooms { get; set; }
    }
}