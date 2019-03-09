using System.Collections.Generic;

namespace HotelService.Web.Models
{
    /// <summary>
    /// Room
    /// </summary>
    public class RoomModel
    {
        /// <summary>
        /// default ctor
        /// </summary>
        public RoomModel()
        {
            Amenities = new List<string>();

        }
        public int Number { get; set; }
        public int MaxOccupants { get; set; }
        public string Description { get; set; }

        public Bedding Bedding { get; set; }

        public IList<string> Amenities { get; set; }
    }
}