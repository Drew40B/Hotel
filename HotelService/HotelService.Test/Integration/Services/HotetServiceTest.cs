using Xunit;
using HotelService.Test;
using HotelService.Web.Services;
using HotelService.Web.Models;
using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using HotelService.Web.Database;
using AutoMapper;

namespace HotelService.Test.Services
{



    public class HotetServiceTest : IDisposable
    {

        private string _prefix = "Test:" + Guid.NewGuid().ToString();
        private IMapper _mapper;

        public HotetServiceTest()
        {
            try
            {
                // Initialize mapping
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<HotelMapping>();

                });

                //TODO is there a beeter place to validate mapping config?
                config.AssertConfigurationIsValid();

                _mapper = config.CreateMapper();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }


        [Fact]
        public async void CreateHotel()
        {
            var config = TestHelper.GetIConfigurationRoot();
            var service = new HotelService.Web.Services.HotelService(config, _mapper);

            var init = new HotelInitModel
            {
                Location = "Somewhere",
                Name = _prefix,
                FloorCount = 5,
                RoomsPerFloor = 10,
                Amenities = new string[] { "Coffee Maker", "Fridge" },
                Mode = CreateMode.Random
            };

            var result = await service.Create(init);

        }
        [Fact]
        public void CreateRandomRoom()
        {
            var config = TestHelper.GetIConfigurationRoot();
            var service = new HotelService.Web.Services.HotelService(config, null);
            var init = new HotelInitModel
            {
                Location = "Somewhere",
                Name = _prefix,
                FloorCount = 5,
                RoomsPerFloor = 10,
                Amenities = new string[] { "Coffee Maker", "Fridge" },
                Mode = CreateMode.Random
            };

            var room = service.CreateRoom(1, 3, init);

            Assert.Equal(room.Number, 103);
            Assert.True(room.MaxOccupants > 1);
            Assert.True(room.Description.Length > 1);

        }

        [Fact]
        public async void FindHotel()
        {


            var config = TestHelper.GetIConfigurationRoot();
            var client = new MongoClient(config.GetConnectionString("hotels_db"));
            var database = client.GetDatabase("hotels_db");
            var collection = database.GetCollection<HotelDbModel>("hotels");

            var dbModel = new HotelDbModel();
            dbModel.Name = _prefix;

            await collection.InsertOneAsync(dbModel);

            var service = new HotelService.Web.Services.HotelService(config, _mapper);
            var found = service.FindHotel(dbModel.Name);

            Assert.NotNull(found);

        }


        public void Dispose()
        {
            var config = TestHelper.GetIConfigurationRoot();
            var service = new HotelService.Web.Services.HotelService(config, null);

            var client = new MongoClient(config.GetConnectionString("hotels_db"));
            var database = client.GetDatabase("hotels_db");

            database.GetCollection<HotelDbModel>("hotels").DeleteMany(h => h.Name == _prefix);
        }
    }
}