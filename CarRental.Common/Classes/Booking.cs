using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
	public class Booking : IBooking
	{
        public string regNr { get; set; }
        public string ssn { get; set; }
        public int odometerRent {  get; set; }
        public int? odometerReturn { get; set; }
        public DateTime dateRented {  get; set; }
        public DateTime? dateReturned {  get; set; }
        public double? cost { get; set; }
        public BookingStatuses rentedStatus { get; set; }


        public Booking(string regNr, string ssn, int odometerRent, int? odometerReturn, DateTime dateRented, DateTime? dateReturned, double? cost, BookingStatuses rentedStatus)
        {
            this.regNr = regNr;
            this.ssn = ssn;
            this.odometerRent = odometerRent;
            this.odometerReturn = odometerReturn;
            this.dateRented = dateRented;
            this.dateReturned = dateReturned;
            this.cost = cost;
            this.rentedStatus = rentedStatus;
        }
    }
}
