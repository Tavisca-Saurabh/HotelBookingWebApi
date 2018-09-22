using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelService.Model;

namespace HotelService.DataAccess
{
    public class Repository : IRepository
    {
        public List<HotelDetailModel> GetHotelDetails(string HotelID)
        {
            HotelRepository Hotel = new HotelRepository();
            return Hotel.GetHotelDetails(HotelID);
        }
    }
}