
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace SunTest.Orm
{

using System;
    using System.Collections.Generic;
    
public partial class PostFlight
{

    public int PostFlightID { get; set; }

    public Nullable<int> FlightNum { get; set; }

    public string OriginatingAirport { get; set; }

    public string DestinationAirport { get; set; }

    public string Airline { get; set; }

    public Nullable<int> FlightDate { get; set; }

    public Nullable<int> PassengerCount { get; set; }

    public Nullable<System.TimeSpan> DepartureTime { get; set; }

    public Nullable<System.TimeSpan> ArrivalTime { get; set; }

    public string AircraftRegistrationNo { get; set; }

}

}
