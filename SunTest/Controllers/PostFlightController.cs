using SunTest.Dto;
using SunTest.Orm;
using SunTest.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SunTest.Controllers
{
    //[BasicAuthentication]

    public class PostFlightController : ApiController
    {

        // /api/PostFlight/Post
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post(PostFlightRootObject _model, string user, string pass)
        {
            if (!ApiSecurity.Login(user, pass)) return Unauthorized();

            try
            {
                using (SunExpressEntities context = new SunExpressEntities())
                {
                    var pFList = _model.PostFlightData.PostFlight;

                    foreach (var item in pFList)
                    {
                        var postFlight = new Orm.PostFlight
                        {
                            AircraftRegistrationNo = item.AircraftRegistrationNo,
                            Airline = item.Airline,
                            ArrivalTime = item.ArrivalTime,
                            DepartureTime = item.DepartureTime,
                            DestinationAirport = item.DestinationAirport,
                            FlightDate = DateToOLEFormat(item.FlightDate),
                            FlightNum = item.FlightNum,
                            OriginatingAirport = item.OriginatingAirport,
                            PassengerCount = Convert.ToInt32(item.PassengerCount),

                        };

                        context.PostFlight.Add(postFlight);

                        context.SaveChanges();

                        int pFID = postFlight.PostFlightID;

                        if(item.Crews.CrewId.Count>0)
                        foreach (var crew in item.Crews.CrewId)
                        {
                            var postFlightCrew = new PostFlightCrew();

                            postFlightCrew.CrewID = crew;
                            postFlightCrew.PostFlightID = pFID;

                            context.PostFlightCrew.Add(postFlightCrew);
                        }

                        context.SaveChanges();
                    }
                }

                return Ok("Saved Successfully");
                //return Json("SavedSuccesfully");
            }
            catch (Exception ex)
            {

                return BadRequest($" {ex.Message}, Error: Not Saved!");
            }

        }

        private static int DateToOLEFormat(string date)
        {
            return Convert.ToInt32(DateTime.Parse(date).ToOADate());
        }
    }
}

