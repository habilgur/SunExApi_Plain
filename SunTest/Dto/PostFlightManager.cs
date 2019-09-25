using Newtonsoft.Json;
using SunTest.Orm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SunTest.Dto
{
    // Used for parsing data from Client

    public class PostFlightRootObject
    {
       [JsonProperty("PostFlightData")]
        public PostFlightData PostFlightData { get; set; }

    }

    public partial class PostFlightData
    {
        [JsonProperty("PostFlight")]
        public List<PostFlight> PostFlight { get; set; }

    }

    public partial class PostFlight
    {
        [JsonProperty("FlightNum")]
        public int FlightNum { get; set; }

        [JsonProperty("OriginatingAirport")]
        public string OriginatingAirport { get; set; }

        [JsonProperty("DestinationAirport")]
        public string DestinationAirport { get; set; }

        [JsonProperty("Airline")]
        public string Airline { get; set; }

        [JsonProperty("FlightDate")]
        public string FlightDate { get; set; }

        [JsonProperty("PassengerCount")]
        public int PassengerCount { get; set; }

        [JsonProperty("DepartureTime")]
        public TimeSpan DepartureTime { get; set; }

        [JsonProperty("ArrivalTime")]
        public TimeSpan ArrivalTime { get; set; }

        [JsonProperty("AircraftRegistrationNo")]
        public string AircraftRegistrationNo { get; set; }

        [JsonProperty("Crews")]
        public Crews Crews { get; set; }
    }

    public partial class Crews
    {
        [JsonProperty("CrewID")]
        public List<string> CrewId { get; set; }
    }

    // Used for showing data from DB to Client

    public class PostFlightClientView
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
        public IQueryable<String> Crews { get; set; }

    }
}