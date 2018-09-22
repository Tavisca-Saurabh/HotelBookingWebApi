using HotelBookingApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelBookingApplication.DataAccess
{
    public class SqlOperartion
    {
        public static bool Add(HotelModel entireList)
        {
            Logger.GetInstance.SaveInToLogFile("Add Booking Details in SQL Database");
            try
            {
                using (var connection = new SqlConnection("Data Source=TAVDESK005;Initial Catalog=HotelBooking;User ID=sa;Password=test123!@#"))
                {

                    connection.Open();
                    string sql = "INSERT INTO Booking(HotelID,Name,Address,Amenities,Image,NoOfRooms,Price,RoomType) VALUES(@HotelID,@Name,@Address,@Amenities,@Image,@NoOfRooms,@Price,@RoomType)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@HotelID", entireList.ID);
                    cmd.Parameters.AddWithValue("@Name", entireList.Name);
                    cmd.Parameters.AddWithValue("@Address", entireList.Address);
                    cmd.Parameters.AddWithValue("@Amenities", entireList.Amenities);
                    cmd.Parameters.AddWithValue("@Image", entireList.image);
                    cmd.Parameters.AddWithValue("@NoOfRooms", 1);
                    cmd.Parameters.AddWithValue("@Price", entireList.price);
                    cmd.Parameters.AddWithValue("@RoomType", entireList.roomType);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    if (CallAPIOperation.UpdateWCFApi(entireList))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}