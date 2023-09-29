using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Globalization;

namespace CarRental.Common.Classes
{
	public class Booking : IBooking
	{
        public string Ssn { get; init; }
        public int Id { get; set; }
        public string RegNr { get; init; }
        public IPerson Customer { get; set; }
        public IVehicle Vehicle { get; set; }
        public int? OdometerRent {  get; set; }
        public int? OdometerReturn { get; set; }
        public DateTime DateRented {  get; set; }
        public DateTime? DateReturned {  get; set; }
        public double? CostDay { get; set; }
		public double? CostKm { get; set; }
		public BookingStatuses RentedStatus { get; set; }



        public Booking(IVehicle vehicle, IPerson customer, int? odometerReturned, DateTime dateRented, DateTime? dateReturned, BookingStatuses rentedStatus)
        {
            this.RegNr = vehicle.RegNr;
            this.Customer = customer;
            this.OdometerRent = vehicle.Odometer;
            this.OdometerReturn = odometerReturned; // lägg in info som sätter nya odometer efter return.
            this.DateRented = dateRented;
            this.DateReturned = dateReturned;
            this.RentedStatus = rentedStatus;
            this.CostDay = vehicle.CostDay;
            this.CostKm = vehicle.CostKm;
        }
        public string? GetCost()
		{
			var daysRented = (DateReturned - DateRented)?.TotalDays;
			var kmDriven = (OdometerReturn - OdometerRent);
			var totalCost = (CostDay * daysRented) + (CostKm * kmDriven);
            return totalCost?.ToString(totalCost % 1 == 0 ? "C0" : "C1", CultureInfo.CreateSpecificCulture("en-US"));
		}
    }
}
