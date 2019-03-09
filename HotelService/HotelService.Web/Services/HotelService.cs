using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelService.Web.Dto;
using HotelService.Web.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace HotelService.Web.Services
{
    public class HotelService
    {
        const int MAX_FLOORS = 100;
        const int MAX_ROOMS_PER_FLOOR = 50;
        private readonly IMongoCollection<HotelDto> _hotels;


        public HotelService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("hotels_db"));
            var database = client.GetDatabase("hotels_db");
            _hotels = database.GetCollection<HotelDto>("hotels");


        }


        public async Task<HotelModel> Create(HotelInitModel hotel)
        {
            var dto = new HotelDto();

            dto.Name = hotel.Name;
            dto.Location = hotel.Location;


            for (int floor = 1; floor <= hotel.FloorCount; floor++)
            {
                for (int room = 1; room <= hotel.RoomsPerFloor; room++)
                {

                    dto.Rooms.Add(CreateRoom(floor, room, hotel));
                }
            }

            await _hotels.InsertOneAsync(dto);
            return null;

        }

        public string[] Validate(HotelInitModel hotel)
        {
            var result = new List<string>();

            if (hotel.FloorCount > MAX_FLOORS)
            {
                result.Add($"Floor count greater than max floor count: ${MAX_FLOORS}");
            }

            if (hotel.RoomsPerFloor > MAX_ROOMS_PER_FLOOR)
            {
                result.Add($"Rooms per floor greater tham maximum: ${MAX_ROOMS_PER_FLOOR}");
                return null;
            }

            return result.ToArray();
        }

        public RoomDto CreateRoom(int floor, int roomNumber, HotelInitModel model)
        {

            roomNumber = floor * 100 + roomNumber;

            RoomDto room = null;

            switch (model.Mode)
            {
                case CreateMode.Random:
                    room = CreateRandomRoom();
                    break;
                default:
                    throw new ArgumentException($"Unknown room creation mode: {model.Mode} ");

            }

            room.Number = roomNumber;
            room.Description = $"Room# ${roomNumber}";
            room.MaxOccupants = 4;
            room.Amenities = model.Amenities;
            return room;
        }


        private RoomDto CreateRandomRoom()
        {
            var result = new RoomDto();

            var rand = new Random();
            int value = rand.Next(Enum.GetNames(typeof(Bedding)).Length);
            result.Bedding = ((Bedding)value).ToString();


            return result;
        }




    }
}