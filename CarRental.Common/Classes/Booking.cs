using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Globalization;

namespace CarRental.Common.Classes
{
	public class Booking : IBooking
	{
        // Fixa stor bokstav på alla properties
        public string regNr { get; set; }
        public string ssn { get; set; }
        public int odometerRent {  get; set; }
        public int? odometerReturn { get; set; }
        public DateTime dateRented {  get; set; }
        public DateTime? dateReturned {  get; set; }
        public double? costDay { get; set; }
		public double? costKm { get; set; }
		public BookingStatuses rentedStatus { get; set; }


        public Booking(string regNr, string ssn, int odometerRent, int? odometerReturn, DateTime dateRented, DateTime? dateReturned, double? costDay, BookingStatuses rentedStatus, double? costKm)
        {
            this.regNr = regNr;
            this.ssn = ssn;
            this.odometerRent = odometerRent;
            this.odometerReturn = odometerReturn;
            this.dateRented = dateRented;
            this.dateReturned = dateReturned;
            this.rentedStatus = rentedStatus;
            this.costDay = costDay;
            this.costKm = costKm;
        }
		public string GetCost()
		{
			var daysRented = (dateReturned - dateRented)?.TotalDays;
			var kmDriven = (odometerReturn - odometerRent);
			var totalCost = (costDay * daysRented) + (costKm * kmDriven);
            return totalCost?.ToString(totalCost % 1 == 0 ? "C0" : "C1", CultureInfo.CreateSpecificCulture("en-US"));
			
		}
        public string GetCostTest()
        {
            string totalCost2;
            var daysRented = (dateReturned - dateRented)?.TotalDays;
            var kmDriven = (odometerReturn - odometerRent);
            var totalCost = ((costDay* daysRented) + (costKm* kmDriven));
            totalCost2 = totalCost?.ToString("C0", CultureInfo.CreateSpecificCulture("EN"));
            return totalCost2;
		}
    }
}
