using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

public interface IBooking
{
	 string RegNr { get; init; }
	 string Ssn { get; init; }
	 int OdometerRent {  get; set; }
	 int? OdometerReturn { get; set; }
	 DateTime DateRented { get; set; }
	 DateTime? DateReturned { get; set; }
	 double? CostDay { get; set; }
	 double? CostKm { get; set; }
	BookingStatuses RentedStatus { get; set; }
	string? GetCost();

}
