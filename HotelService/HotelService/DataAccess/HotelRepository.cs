using Cassandra;
using HotelService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelService.DataAccess
{
    public class HotelRepository
    {
        public List<HotelDetailModel> GetHotelDetails(string HotelID)
        {
            try
            {
                //--------------------------Cassandra----------------------------
                List<HotelDetailModel> currentData = new List<HotelDetailModel>();

                // Connect to the TicTacToe keyspace on our cluster running at 127.0.0.1
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("hotelservices");

                RowSet rs = session.Execute("select * from hoteldetails where hotelid=" + Convert.ToInt32(HotelID) + " ALLOW FILTERING");
                //Iterate through the RowSet
                foreach (var result in rs)
                {
                    HotelDetailModel data = new HotelDetailModel();
                    data.noOfRoomAvailable = Convert.ToInt32(result["availableroom"]);
                    data.roomType = Convert.ToString(result["roomtype"]);
                    data.price = Convert.ToInt32(result["price"]);
                    data.roomKey = Convert.ToInt32(result["roomid"]);
                    currentData.Add(data);

                }
                return currentData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}