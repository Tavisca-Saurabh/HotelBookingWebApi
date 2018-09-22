using System;
using Cassandra;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBookingApplication.Models;

namespace HotelBookingApplication.DataAccess
{
    public class CallAPIOperation
    {
        public static bool UpdateWCFApi(HotelModel entireList)
        {
            Logger.GetInstance.SaveInToLogFile("Update WCF Api After Booking");
            try
            {
                //--------------------------Cassandra----------------------------

                // Connect to the keyspace on our cluster running at 127.0.0.1
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("hotelservices");

                //Prepare a statement oncehotelservices
                var ps = session.Prepare("UPDATE HotelDetails SET availableroom=? WHERE roomtype=? AND HotelID=? AND roomid=?");

                //...bind different parameters every time you need to execute
                var statement = ps.Bind(entireList.noOfRoomAvailable - 1, entireList.roomType, entireList.ID, entireList.roomKey);
                //Execute the bound statement with the provided parameters
                session.Execute(statement);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}