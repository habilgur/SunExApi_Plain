using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunTest.Dto
{

    public class CrewDataRootObject
    {
        public CrewData CrewData { get; set; }
    }

    public partial class CrewData
    {
        [JsonProperty("Crew")]
        public List<Crew> Crew { get; set; }
    }

    public partial class Crew
    {
        [JsonProperty("CrewID")]
        public string CrewId { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Airline")]
        public string Airline { get; set; }

        [JsonProperty("Airport")]
        public string Airport { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("EndDate")]
        public string EndDate { get; set; }
    }
}