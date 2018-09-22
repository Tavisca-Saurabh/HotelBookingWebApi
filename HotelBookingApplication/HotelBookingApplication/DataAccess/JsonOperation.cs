using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBookingApplication.Models;
using Newtonsoft.Json;
using System.IO;
namespace HotelBookingApplication.DataAccess
{
    public class JsonOperation
    {
        public static List<HotelModel> GetAllHotels()
        {
            Logger.GetInstance.SaveInToLogFile("Get All Hotel From Json");
            List<HotelModel> HotelDetails = new List<HotelModel>();
            using (StreamReader r = new StreamReader(@"C:\Users\smanchanda\Downloads\HotelWCF Project\HotelBookingApplication\HotelBookingApplication\DataAccess\HotelAmenities.json"))
            {
                string json = r.ReadToEnd();
                List<HotelModel> items = JsonConvert.DeserializeObject<List<HotelModel>>(json);
                for (var index = 0; index < items.Count; index++)
                {
                    HotelModel hotel = new HotelModel();

                    hotel.ID = items[index].ID;
                    hotel.Name = items[index].Name;
                    hotel.Address = items[index].Address;
                    hotel.Amenities = items[index].Amenities;
                    hotel.image = items[index].image;
                    HotelDetails.Add(hotel);
                }
            }
            return HotelDetails;
        }

        public static List<HotelModel> GetAllHotelsByID(int id)
        {
            Logger.GetInstance.SaveInToLogFile("Get All Hotel By ID From Json");
            List<HotelModel> HotelDetails = new List<HotelModel>();
            using (StreamReader r = new StreamReader(@"C:\Users\smanchanda\Downloads\HotelWCF Project\HotelBookingApplication\HotelBookingApplication\DataAccess\HotelAmenities.json"))
            {
                string json = r.ReadToEnd();
                List<HotelModel> items = JsonConvert.DeserializeObject<List<HotelModel>>(json);
                for (var index = 0; index < items.Count; index++)
                {
                    HotelModel hotel = new HotelModel();
                    if (hotel.ID == id)
                    {
                        hotel.ID = items[index].ID;
                        hotel.Name = items[index].Name;
                        hotel.Address = items[index].Address;
                        hotel.Amenities = items[index].Amenities;
                        hotel.image = items[index].image;
                        HotelDetails.Add(hotel);
                    }
                }
            }
            return HotelDetails;
        }

    }
}