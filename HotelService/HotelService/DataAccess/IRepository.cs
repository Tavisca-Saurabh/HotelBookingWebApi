using HotelService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.DataAccess
{
    interface IRepository
    {
        List<HotelDetailModel> GetHotelDetails(string HotelID);
    }
}
