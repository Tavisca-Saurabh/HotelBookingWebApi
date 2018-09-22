using HotelBookingApplication.DataAccess;
using HotelBookingApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HotelBookingApplication.Controllers
{
    public class HomeController : ApiController
    {
        // GET: api/Home
        [Route("get")]
        [HttpGet]
        public IHttpActionResult GetHotel()
        {
            Logger.GetInstance.SaveInToLogFile("Get All Hotel From JSON");
            var hotels = JsonOperation.GetAllHotels();
            if (hotels != null)
            {
                return Ok(hotels);
            }
            return NotFound();//("No Hotel Found with the given ID");
        }

        HttpClient client = new HttpClient();
        static List<HotelModel> entireList = new List<HotelModel>();
        List<HotelModel> jsonList = new List<HotelModel>();
        List<HotelModel> HotelList = new List<HotelModel>();

        [Route("get/{id}")]
        [HttpGet]
        public async Task<List<HotelModel>> CallWebAPIAsync(int id)
        {
            Logger.GetInstance.SaveInToLogFile("Get All Hotel From JSON & WCF Services");
            await Task.Run(async () =>
             {
                 client.BaseAddress = new Uri("http://localhost:49332");
                 HttpResponseMessage response = await client.GetAsync("HotelService.svc/GetHotelDetails/" + id.ToString() + "");
                 if (response.IsSuccessStatusCode)
                 {
                     HotelList = await response.Content.ReadAsAsync<List<HotelModel>>();

                 }
             });
            await Task.Run(() =>
            {
                var path = @"C:\Users\smanchanda\Downloads\HotelWCF Project\HotelBookingApplication\HotelBookingApplication\DataAccess\HotelAmenities.json";
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    jsonList = JsonConvert.DeserializeObject<List<HotelModel>>(json);

                }
                //jsonList = JsonOperation.GetAllHotelsByID(id);
            });
            for (int i = 0; i < HotelList.Count; i++)
            {
                HotelModel entireObject = new HotelModel();
                entireObject.ID = id;
                entireObject.Name = jsonList[id - 1].Name;
                entireObject.Address = jsonList[id - 1].Address;
                entireObject.Amenities = jsonList[id - 1].Amenities;
                entireObject.image = jsonList[id - 1].image;
                entireObject.noOfRoomAvailable = HotelList[i].noOfRoomAvailable;
                entireObject.price = HotelList[i].price;
                entireObject.roomType = HotelList[i].roomType;
                entireObject.roomKey = HotelList[i].roomKey;
                entireList.Add(entireObject);
            }

            return entireList;
        }

        // POST: api/Home
        [Route("post/{type}")]
        [HttpPost]
        public IHttpActionResult Post(string type)
        {
            Logger.GetInstance.SaveInToLogFile("Booking Hotel");
            HotelModel currentBookingData = new HotelModel();
            for (int i = 0; i < entireList.Count; i++)
            {
                if (entireList[i].roomType == type)
                {
                    currentBookingData.ID = entireList[i].ID;
                    currentBookingData.Name = entireList[i].Name;
                    currentBookingData.Address = entireList[i].Address;
                    currentBookingData.Amenities = entireList[i].Amenities;
                    currentBookingData.image = entireList[i].image;
                    currentBookingData.price = entireList[i].price;
                    currentBookingData.roomType = type;
                    currentBookingData.roomKey = entireList[i].roomKey;
                    currentBookingData.noOfRoomAvailable = entireList[i].noOfRoomAvailable;
                    break;
                }
            }
            var isSuccessful = SqlOperartion.Add(currentBookingData);
            if (isSuccessful)
                return Ok("Booked Added successfully");
            return BadRequest("Could not Book");
        }
    }
}
