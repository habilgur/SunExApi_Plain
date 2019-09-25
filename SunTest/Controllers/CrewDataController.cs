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
    public class CrewDataController : ApiController
    {


        public IHttpActionResult Post(CrewDataRootObject _model, string user, string pass)
        {


            if (!ApiSecurity.Login(user, pass)) return Unauthorized();

            try
            {
                using (SunExpressEntities context = new SunExpressEntities())
                {
                    var crewDataList = _model.CrewData.Crew;

                    if (crewDataList.Count > 0)
                        foreach (var flightCrew in crewDataList)
                        {
                            bool savedBefore = context.Crew.Any(x => x.CrewID.Equals(flightCrew.CrewId));

                            if (!savedBefore)
                            {
                                Orm.Crew newCrew = new Orm.Crew();
                                newCrew.CrewID = flightCrew.CrewId;
                                newCrew.Airline = flightCrew.Airline;
                                newCrew.Airport = flightCrew.Airport;
                                newCrew.FirstName = flightCrew.FirstName;
                                newCrew.LastName = flightCrew.LastName;
                                newCrew.Title = flightCrew.Title;
                                newCrew.StartDate = DateToOLEFormat(flightCrew.StartDate);
                                newCrew.EndDate = DateToOLEFormat(flightCrew.EndDate);

                                context.Crew.Add(newCrew);
                                context.SaveChanges();


                            }


                        }

                    return Ok("Saved Succesfully");
                }


   
            }
            catch (Exception)
            {

                return BadRequest("Not Saved");
            }


        }

        private static int DateToOLEFormat(string date)
        {
            return Convert.ToInt32(DateTime.Parse(date).ToOADate());
        }
    }


}
