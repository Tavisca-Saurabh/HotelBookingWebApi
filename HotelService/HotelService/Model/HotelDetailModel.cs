using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelService.Model
{
    [DataContract]
    public class HotelDetailModel
    {
        [DataMember]
        public int noOfRoomAvailable{ get; set; }
        [DataMember]
        public string roomType { get; set; }
        [DataMember]
        public int price { get; set; }
        [DataMember]
        public int roomKey { get; set; }
    }
}