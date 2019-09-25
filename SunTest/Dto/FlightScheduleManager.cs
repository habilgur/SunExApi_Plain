using Newtonsoft.Json;
using SunTest.Orm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SunTest.Dto
{

    #region JsonClasses

    public partial class FlightScheduleRootObject
    {
        [JsonProperty("FlightScheduleData")]
        public FlightScheduleData FlightScheduleData { get; set; }
    }

    public partial class FlightScheduleData
    {
        [JsonProperty("FlightSchedule", NullValueHandling = NullValueHandling.Ignore)]
        public List<FlightSchedule> FlightSchedule { get; set; }

    }



    public partial class FlightSchedule
    {
        [JsonProperty("FlightNum")]
        public int FlightNum { get; set; }

        [JsonProperty("Airline")]
        public string Airline { get; set; }

        [JsonProperty("OriginatingAirport")]
        public string OriginatingAirport { get; set; }

        [JsonProperty("DestinationAirport")]
        public string DestinationAirport { get; set; }

        [JsonProperty("TourOperator")]
        public bool TourOperator { get; set; }

        [JsonProperty("DepartureTime")]
        public string DepartureTime { get; set ; }

        [JsonProperty("ArrivalTime")]
        public string ArrivalTime { get; set; }

        [JsonProperty("DayOfWeekMask")]
        public DayOfWeekMask DayOfWeekMask { get; set; }

        [JsonProperty("SectorLength")]
        public string SectorLength { get; set; }

        [JsonProperty("EffectiveStartDate")]
        public string EffectiveStartDate { get; set; }

        [JsonProperty("EffectiveEndDate")]
        public string EffectiveEndDate { get; set; }

        //Comes from CrewDataManager
        [JsonProperty("CrewData")]
        public CrewData CrewData { get; set; }
    }


    public class Day
    {

        [JsonProperty("IsScheduled")]
        public bool IsScheduled { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("SpendPerHead")]
        public int SpendPerHead { get; set; }

        [JsonProperty("IncentiveTarget")]
        public int IncentiveTarget { get; set; }
    }


    public partial class DayOfWeekMask
    {
        [JsonProperty("Mon")]
        public Day Mon { get; set; }

        [JsonProperty("Tue")]
        public Day Tue { get; set; }

        [JsonProperty("Wed")]
        public Day Wed { get; set; }

        [JsonProperty("Thu")]
        public Day Thu { get; set; }

        [JsonProperty("Fri")]
        public Day Fri { get; set; }

        [JsonProperty("Sat")]
        public Day Sat { get; set; }

        [JsonProperty("Sun")]
        public Day Sun { get; set; }
    }

    #endregion

    // Used for showing data from DB to Client

    public class FlightScheduleClientView
    {
        public int FlightNum { get; set; }
        public string Airline { get; set; }
        public string OriginatingAirport { get; set; }
        public string DestinationAirport { get; set; }
        public bool TourOperator { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public List<DayOfWeekFlightSchClientView> DayOfWeekMask { get; set; }
        public TimeSpan SectorLength { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
    }

    public class DayOfWeekFlightSchClientView
    {

        public string WeekDay { get; set; }
        public string IsSchedule { get; set; }
        public string Currency { get; set; }
        public string SpendPerHead { get; set; }
        public string IncentiveTarget { get; set; }

    }
}




  


