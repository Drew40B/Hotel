namespace HotelService.Web.Models
{
    /// <summary>
    /// Model used to initialize a hotel
    /// </summary>
    public class HotelInitModel
    {
        /// <summary>
        /// Name of the hotel
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Location of the hotel
        /// </summary>
        /// <value></value>
        public string Location { get; set; }

        /// <summary>
        /// Number of floors
        /// </summary>
        /// <value></value>
        public int FloorCount { get; set; }

        /// <summary>
        /// Number of rooms per floor
        /// </summary>
        /// <value></value>
        public int RoomsPerFloor { get; set; }

        /// <summary>
        /// Default amenities to add to each room
        /// </summary>
        /// <value></value>
        public string[] Amenities { get; set; }

        public CreateMode Mode { get; set; }
    }
}