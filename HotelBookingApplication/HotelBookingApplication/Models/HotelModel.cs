using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBookingApplication.Models
{
    public class HotelModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Amenities { get; set; }
        public string Address { get; set; }
        public string image { get; set; }
        public int noOfRoomAvailable { get; set; }
        public string roomType { get; set; }
        public int price { get; set; }
        public int roomKey { get; set; }
    }
}