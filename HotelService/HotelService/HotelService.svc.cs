using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cassandra;
using HotelService.DataAccess;
using HotelService.Model;

namespace HotelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelService.svc or HotelService.svc.cs at the Solution Explorer and start debugging.
    public class HotelService : IHotelService
    {
        //public List<HotelDetailModel> GetHotelDetails(string HotelID)
        //{
        //    try
        //    {
        //        List<HotelDetailModel> currentData = new List<HotelDetailModel>();
        //        //--------------------------Cassandra----------------------------

        //        // Connect to the TicTacToe keyspace on our cluster running at 127.0.0.1
        //        Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
        //        ISession session = cluster.Connect("hotelservices");

        //        RowSet rs = session.Execute("select * from hoteldetails where hotelid=" + Convert.ToInt32(HotelID) + " ALLOW FILTERING");
        //        //Iterate through the RowSet
        //        foreach (var result in rs)
        //        {
        //            HotelDetailModel data = new HotelDetailModel();
        //            data.noOfRoomAvailable = Convert.ToInt32(result["availableroom"]);
        //            data.roomType = Convert.ToString(result["roomtype"]);
        //            data.price = Convert.ToInt32(result["price"]);
        //            currentData.Add(data);

        //        }
        //        return currentData;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public List<HotelDetailModel> GetHotelDetails(string HotelID)
        {
            Repository Data = new Repository();
            if (Data.GetHotelDetails(HotelID) != null)
            {
                return Data.GetHotelDetails(HotelID);
                //return Content(HttpStatusCode.BadRequest, "Any object");
            }
            //var BadRequest = new HotelDetailModel { noOfRoomAvailable = 0, price = 0, roomType = "None" };
            return null;//new List<HotelDetailModel>() { BadRequest };
        }
    }
}
