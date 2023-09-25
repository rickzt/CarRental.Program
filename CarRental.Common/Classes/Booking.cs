using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Globalization;

namespace CarRental.Common.Classes
{
	public class Booking : IBooking
	{
        // Fixa stor bokstav på alla properties
        public string RegNr { get; init; }
        public string Ssn { get; init; }
        public int OdometerRent {  get; set; }
        public int? OdometerReturn { get; set; }
        public DateTime DateRented {  get; set; }
        public DateTime? DateReturned {  get; set; }
        public double? CostDay { get; set; }
		public double? CostKm { get; set; }
		public BookingStatuses RentedStatus { get; set; }


        public Booking(string regNr, string ssn, int odometerRent, int? odometerReturn, DateTime dateRented, DateTime? dateReturned, double? costDay, BookingStatuses rentedStatus, double? costKm)
        {
            this.RegNr = regNr;
            this.Ssn = ssn;
            this.OdometerRent = odometerRent;
            this.OdometerReturn = odometerReturn;
            this.DateRented = dateRented;
            this.DateReturned = dateReturned;
            this.RentedStatus = rentedStatus;
            this.CostDay = costDay;
            this.CostKm = costKm;
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
