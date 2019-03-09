using Xunit;
using HotelService.Test;
using HotelService.Web.Services;
using HotelService.Web.Models;
using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using HotelService.Web.Dto;

namespace HotelService.Test.Services
{



    public class HotetServiceTest : IDisposable
    {

        private string _prefix = "Test:" + Guid.NewGuid().ToString();

        [Fact]
        public async void CreateHotel()
        {
            var config = TestHelper.GetIConfigurationRoot();
            var service = new HotelService.Web.Services.HotelService(config);

            var init = new HotelInitModel
            {
                Location = "Somewhere",
                Name = _prefix,
                FloorCount = 5,
                RoomsPerFloor = 10,
                Amenities = new string[] {"Coffee Maker","Fridge"},
                Mode = CreateMode.Random
            };

            var result = await service.Create(init);

        }
        [Fact]
        public void CreateRandomRoom()
        {
            var config = TestHelper.GetIConfigurationRoot();
            var service = new HotelService.Web.Services.HotelService(config);
              var init = new HotelInitModel
            {
                Location = "Somewhere",
                Name = _prefix,
                FloorCount = 5,
                RoomsPerFloor = 10,
                Amenities = new string[] {"Coffee Maker","Fridge"},
                Mode = CreateMode.Random
            };

            var room = service.CreateRoom(1, 3,init);

            Assert.Equal(room.Number, 103);
            Assert.True(room.MaxOccupants > 1);
            Assert.True(room.Description.Length > 1);

        }


        public void Dispose()
        {
            var config = TestHelper.GetIConfigurationRoot();
            var service = new HotelService.Web.Services.HotelService(config);

             var client = new MongoClient(config.GetConnectionString("hotels_db"));
            var database = client.GetDatabase("hotels_db");

            database.GetCollection<HotelDto>("hotels").DeleteMany(h => h.Name == _prefix);
        }
    }
}