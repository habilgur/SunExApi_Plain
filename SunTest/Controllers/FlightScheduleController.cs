using Newtonsoft.Json;
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
    public class FlightScheduleController : ApiController
    {

        /* /api/FlightSchedule/Post  */
        [HttpPost]
        public IHttpActionResult Post(FlightScheduleRootObject _model, string user, string pass)
        {

            if (!ApiSecurity.Login(user, pass)) return Unauthorized();

            try
            {
                using (SunExpressEntities context = new SunExpressEntities())
                {
                    var fSData = _model.FlightScheduleData.FlightSchedule;

                    foreach (var item in fSData)
                    {
                        var flightSchedule = new Orm.FlightSchedule
                        {

                            FlightNum = item.FlightNum,
                            Airline = item.Airline,

                            OriginatingAirport = item.OriginatingAirport,
                            DestinationAirport = item.DestinationAirport,
                            TourOperator = Convert.ToBoolean(item.TourOperator),
                            DepartureTime = TimeSpan.Parse(item.DepartureTime),
                            ArrivalTime = TimeSpan.Parse(item.ArrivalTime),

                            EffectiveEndDate = DateToOLEFormat(item.EffectiveEndDate),
                            EffectiveStartDate = DateToOLEFormat(item.EffectiveStartDate),
                            SectorLength = TimeSpan.Parse(item.SectorLength),


                        };

                        context.FlightSchedule.Add(flightSchedule);

                        context.SaveChanges();


                        int flightSchId = flightSchedule.FlightScheduleID; //Get ID for futher table inserts

                        ///DayOfWeek Extraction
                        Dictionary<string, Day> dayList = new Dictionary<string, Day>();

                        AddToList(item, dayList);

                        foreach (var day in dayList)
                        {
                            if (day.Value != null)
                            {
                                var flightDayTableDetails = new FlightScheduleDayOfWeek();

                                flightDayTableDetails.FlightScheduleID = flightSchId;
                                flightDayTableDetails.WeekDay = day.Key.ToString();
                                flightDayTableDetails.IsSchedule = Convert.ToBoolean(day.Value.IsScheduled);
                                flightDayTableDetails.Currency = day.Value.Currency;
                                flightDayTableDetails.IncentiveTarget = Convert.ToInt16(day.Value.IncentiveTarget);
                                flightDayTableDetails.SpendPerHead = Convert.ToInt16(day.Value.SpendPerHead);

                                context.FlightScheduleDayOfWeek.Add(flightDayTableDetails);

                            }
                        }


                        context.SaveChanges();

                    }

                   
                }

                return Ok("Saved Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest("Error! Not Added!");
            }

        }

        /// <summary>
        /// Extract Day classes properties to a list with its name
        /// </summary>
        /// <param name="item"></param>
        /// <param name="listday"></param>
        private static void AddToList(Dto.FlightSchedule item, Dictionary<string, Day> listday)
        {
            listday.Add("Sun", item.DayOfWeekMask.Sun);
            listday.Add("Mon", item.DayOfWeekMask.Mon);
            listday.Add("Tue", item.DayOfWeekMask.Tue);
            listday.Add("Wed", item.DayOfWeekMask.Wed);
            listday.Add("Thu", item.DayOfWeekMask.Thu);
            listday.Add("Fri", item.DayOfWeekMask.Fri);
            listday.Add("Sat", item.DayOfWeekMask.Sat);
        }

        private static int DateToOLEFormat(string date)
        {
            return Convert.ToInt32(DateTime.Parse(date).ToOADate());
        }



    }

}





