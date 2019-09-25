using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SunTest.WebApiClient
{

    class Program
    {
        ///Change the credentials with actuals
        static string username = "test";
        static string password = "test";

        static void Main(string[] args)
        {

            HttpClient client = new HttpClient();

            ///Change the Uri with actual server adresses.
            client.BaseAddress = new Uri("http://localhost:57193");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            #region Basic Authentication
            ///Not used with v1.
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization",
            //Convert.ToBase64String(Encoding.Default.GetBytes("test:test")));
            #endregion


            //PostFlight_Post(client);


            //FlightSchedule_Post(client);


            //CrewData_Post(client);

            Console.ReadLine();

        }

        /// <summary>
        /// List halinde bir veya birden fazla PostFlight datası iletir.
        /// </summary>
        /// <param name="client"></param>
        private static void PostFlight_Post(HttpClient client)
        {

            PostFlightData postFlightData = new PostFlightData()
            {

                PostFlight = new List<PostFlight>()
                {

                     new PostFlight()
                     {
                        FlightNum = 654,
                        OriginatingAirport = "ATH",
                        DestinationAirport = "DUS",
                        Airline = "SXS",
                        FlightDate = "2019-09-02Z",
                        PassengerCount = 188,
                        DepartureTime = new TimeSpan(06, 00, 00),
                        ArrivalTime = new TimeSpan(08, 00, 00),
                        AircraftRegistrationNo = "TC-SOA",
                        Crews = new Crews { CrewID = new List<string> { "000111", "000112", "000113" } }


                     },

                     //new PostFlight()
                     //{

                     //},

                }


            };

            PostFlightRootObject root = new PostFlightRootObject();

            root.PostFlightData = postFlightData;

            ///StructureCheck
            ///string jsonContent = JsonConvert.SerializeObject(root);


            string apiQuery = ( $"/api/PostFlight/Post?user={username}&pass={password}" );

            Uri url = new Uri(client.BaseAddress + apiQuery);


            var postTask = client.PostAsJsonAsync(url, root);

            postTask.Wait();

            var result = postTask.Result;

            var innerMsg = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"{(Int32)result.StatusCode}, {result.ReasonPhrase},{innerMsg}");


        }


        /// <summary>
        /// List halinde bir veya birden fazla FlightSchedule datası iletir.
        /// </summary>
        /// <param name="client"></param>
        private static void FlightSchedule_Post(HttpClient client)
        {

            FlightScheduleData flightScheduleData = new FlightScheduleData()
            {

                FlightSchedule = new List<FlightSchedule>()
                {

                    new FlightSchedule()
                    {

                        Airline = "THY",
                        DestinationAirport = "IST",
                        FlightNum = "999",
                        OriginatingAirport = "AYT",
                        TourOperator = "true",
                        ArrivalTime = "11:00:00",
                        DepartureTime = "09:00:00",
                        SectorLength = "02:00:00",
                        EffectiveEndDate = "2019-02-11Z",
                        EffectiveStartDate = "2019-02-13Z",


                        DayOfWeekMask = new DayOfWeekMask()
                        {

                            Sun = new Sun() { Currency = "EUR", IncentiveTarget = "1", IsScheduled = "true", SpendPerHead = "1" },
                            Mon = new Mon() { Currency = "EUR", IncentiveTarget = "1", IsScheduled = "true", SpendPerHead = "1" },
                            Tue = new Tue() { Currency = "EUR", IncentiveTarget = "1", IsScheduled = "true", SpendPerHead = "1" },
                            Wed = new Wed() { Currency = "EUR", IncentiveTarget = "1", IsScheduled = "true", SpendPerHead = "1" },
                            Thu = new Thu() { Currency = "EUR", IncentiveTarget = "1", IsScheduled = "true", SpendPerHead = "1" },
                            Fri = new Fri() { Currency = "EUR", IncentiveTarget = "1", IsScheduled = "true", SpendPerHead = "1" },
                            Sat = new Sat() { Currency = "EUR", IncentiveTarget = "1", IsScheduled = "true", SpendPerHead = "1" },

                        }


                    },

                    //new FlightSchedule()
                    //{

                    //}


                }

            };


            FligtScheduleRoot root = new FligtScheduleRoot();

            root.FlightScheduleData = flightScheduleData;

            ///StructureCheck
            ///string jsonContent = JsonConvert.SerializeObject(root);

            string apiQuery = ( $"/api/FlightSchedule/Post?user={username}&pass={password}" );

            Uri url = new Uri(client.BaseAddress + apiQuery);

            var postTask = client.PostAsJsonAsync(url, root);

            postTask.Wait();

            var result = postTask.Result;

            var innerMsg = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"{(Int32)result.StatusCode}, {result.ReasonPhrase},{innerMsg}");

        }


        /// <summary>
        ///List halinde bir veya birden fazla Crew datası iletir.
        /// </summary>
        /// <param name="client"></param>
        private static void CrewData_Post(HttpClient client)
        {

            CrewData crewData = new CrewData()
            {


                Crew = new List<Crew>{

                        new Crew {CrewId="000111", Airline="SXS", Airport="AYT",
                            FirstName ="SAM", LastName="BROWN", Title="SE",
                            StartDate ="2019-07-01Z",EndDate="2019-08-01Z"
                        },
                        new Crew {CrewId="000222", Airline="SXS", Airport="AYT",
                            FirstName ="JOHN", LastName="WHITE", Title="SE",
                            StartDate ="2019-07-01Z",EndDate="2019-08-01Z"
                        },
                        new Crew {CrewId="000333", Airline="SXS", Airport="AYT",
                            FirstName ="CHARLES", LastName="BARKLEY", Title="SE",
                            StartDate ="2019-07-01Z",EndDate="2019-08-01Z"
                        },

                }


            };


            CrewDataRootObject root = new CrewDataRootObject();

            root.CrewData = crewData;


            ///StructureCheck
            string jsonContent = JsonConvert.SerializeObject(root);


            string apiQuery = ( $"/api/CrewData/Post?user={username}&pass={password}" );

            Uri url = new Uri(client.BaseAddress + apiQuery);


            var postTask = client.PostAsJsonAsync(url, root);

            postTask.Wait();

            var result = postTask.Result;

            var innerMsg = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine($"{(Int32)result.StatusCode}, {result.ReasonPhrase},{innerMsg}");
        }

    }
}




















#region PostFlight Json Classes
public class PostFlightRootObject
{
    public PostFlightData PostFlightData { get; set; }

}

public partial class PostFlightData
{
    public List<PostFlight> PostFlight { get; set; }

}

public class PostFlight
{
    public int FlightNum { get; set; }
    public string OriginatingAirport { get; set; }
    public string DestinationAirport { get; set; }
    public string Airline { get; set; }
    public string FlightDate { get; set; }
    public int PassengerCount { get; set; }
    public TimeSpan DepartureTime { get; set; }
    public TimeSpan ArrivalTime { get; set; }
    public string AircraftRegistrationNo { get; set; }
    public Crews Crews { get; set; }
}

public class Crews
{
    public List<string> CrewID { get; set; }
}


class PostFlightDataClientView
{
    public string FlightNum { get; set; }
    public string OriginatingAirport { get; set; }
    public string DestinationAirport { get; set; }
    public string Airline { get; set; }
    public string FlightDate { get; set; }
    public string PassengerCount { get; set; }
    public string DepartureTime { get; set; }
    public string ArrivalTime { get; set; }
    public string AircraftRegistrationNo { get; set; }
    public List<Object> Crews { get; set; }

}

#endregion

#region FlightScheduleData Json Classes

public class FlightScheduleClientView
{
    public string FlightNum { get; set; }
    public string Airline { get; set; }
    public string OriginatingAirport { get; set; }
    public string DestinationAirport { get; set; }
    public string TourOperator { get; set; }
    public string DepartureTime { get; set; }
    public string ArrivalTime { get; set; }
    public List<object> DayOfWeekMask { get; set; }
    public string SectorLength { get; set; }
    public string EffectiveStartDate { get; set; }
    public string EffectiveEndDate { get; set; }
}

public class FligtScheduleRoot
{
    public FlightScheduleData FlightScheduleData { get; set; }
}

public class FlightScheduleData
{
    public List<FlightSchedule> FlightSchedule { get; set; }
}

public class FlightSchedule
{
    public string FlightNum { get; set; }
    public string Airline { get; set; }
    public string OriginatingAirport { get; set; }
    public string DestinationAirport { get; set; }
    public string TourOperator { get; set; }
    public string DepartureTime { get; set; }
    public string ArrivalTime { get; set; }
    public DayOfWeekMask DayOfWeekMask { get; set; }
    public string SectorLength { get; set; }
    public string EffectiveStartDate { get; set; }
    public string EffectiveEndDate { get; set; }
    public CrewData CrewData { get; set; }

}

public class DayOfWeekMask
{
    public Mon Mon { get; set; }
    public Tue Tue { get; set; }
    public Wed Wed { get; set; }
    public Thu Thu { get; set; }
    public Fri Fri { get; set; }
    public Sat Sat { get; set; }
    public Sun Sun { get; set; }
}

public class Mon
{
    public string IsScheduled { get; set; }
    public string Currency { get; set; }
    public string SpendPerHead { get; set; }
    public string IncentiveTarget { get; set; }
}

public class Tue
{
    public string IsScheduled { get; set; }
    public string Currency { get; set; }
    public string SpendPerHead { get; set; }
    public string IncentiveTarget { get; set; }
}

public class Wed
{
    public string IsScheduled { get; set; }
    public string Currency { get; set; }
    public string SpendPerHead { get; set; }
    public string IncentiveTarget { get; set; }
}

public class Thu
{
    public string IsScheduled { get; set; }
    public string Currency { get; set; }
    public string SpendPerHead { get; set; }
    public string IncentiveTarget { get; set; }
}

public class Fri
{
    public string IsScheduled { get; set; }
    public string Currency { get; set; }
    public string SpendPerHead { get; set; }
    public string IncentiveTarget { get; set; }
}

public class Sat
{
    public string IsScheduled { get; set; }
    public string Currency { get; set; }
    public string SpendPerHead { get; set; }
    public string IncentiveTarget { get; set; }
}

public class Sun
{
    public string IsScheduled { get; set; }
    public string Currency { get; set; }
    public string SpendPerHead { get; set; }
    public string IncentiveTarget { get; set; }
}


#endregion

#region CrewData

public class CrewDataRootObject
{
    public CrewData CrewData { get; set; }
}

public partial class CrewData
{
    public List<Crew> Crew { get; set; }
}

public partial class Crew
{

    public string CrewId { get; set; }

    public string FirstName { get; set; }


    public string LastName { get; set; }

    public string Airline { get; set; }

    public string Airport { get; set; }

    public string Title { get; set; }

    public string StartDate { get; set; }

    public string EndDate { get; set; }
}

#endregion






