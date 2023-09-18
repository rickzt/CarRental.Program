using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

public interface IBooking
{
	 string regNr { get; set; }
	 string ssn { get; set; }
	 int odometerRent {  get; set; }
	 int? odometerReturn { get; set; }
	 DateTime dateRented { get; set; }
	 DateTime? dateReturned { get; set; }
	 double? costDay { get; set; }
	 double? costKm { get; set; }
	BookingStatuses rentedStatus { get; set; }
	string GetCost();
	public string GetCostTest();
}
