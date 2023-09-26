using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Interfaces;
using CarRental.Data.Classes;
using CarRental.Common.Classes;
using System.Collections;

namespace CarRental.Business.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;
		public BookingProcessor(IData db)
        {
            _db = db;
        }
        public IEnumerable<Customer> GetCustomers()
		{
            var customerList = _db.GetPersons().Where(x => x is Customer).Cast<Customer>().ToList();
			return customerList;
		}
        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
        {
            return _db.GetVehicles(status);
        }
		public IEnumerable<IBooking> GetBookings()
        {
            return _db.GetBookings();
        }
	}
}
