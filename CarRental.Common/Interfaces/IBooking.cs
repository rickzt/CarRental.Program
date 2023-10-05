using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

public interface IBooking
{
	public int Id { get; set; }
	public IPerson Customer { get; set; }
	string RegNr { get; init; }
	 string Ssn { get; init; }
	 int? OdometerRent {  get; set; }
	public IVehicle Vehicle { get; set; }
	int? OdometerReturn { get; set; }
	 DateTime DateRented { get; set; }
	 DateTime? DateReturned { get; set; }
	 double? CostDay { get; set; }
	 double? CostKm { get; set; }
    VehicleStatuses RentedStatus { get; set; }
	string? GetCost();

}
