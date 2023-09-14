using CarRental.Common.Enums;

namespace CarRental.Common.Classes
{
	public class Booking
	{
        public string regNr;
        public string ssn;
        public int odometerRent;
        public int? odometerReturn;
        public string dateRented;
        public string dateReturned;
        public double? cost;
        public BookingStatuses rentedStatus;


        public Booking(string regNr, string ssn, int odometerRent, int? odometerReturn, string dateRented, string dateReturned, double? cost, BookingStatuses rentedStatus)
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
