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
        public void AddNewVehicleButton(Inputs input, IVehicle? vehicle)
        {
            // ta in en bil i parametern och lägg till ID med hjälp av en annan Car konstruktor.
            vehicle = input.AddNewVehicle();
            var id = _db.GetVehicles().Max(x => x.Id) + 1;
            if (vehicle.GetVehicleTypes() == VehicleTypes.Motorcycle && vehicle != null)
            {
                var newVehicle = new Motorcycle(id, vehicle);
				_db.AddNewVehicle(newVehicle);
			}
			else if (vehicle.GetVehicleTypes() != VehicleTypes.Motorcycle && vehicle != null)
            {
				var newVehicle = new Motorcycle(id, vehicle);
				_db.AddNewVehicle(newVehicle);
                input.NullButtons();
            }
            else
                input.NullButtons();
		}
        public void AddNewCustomerButton(Inputs input)
        {
            var newC = input.AddNewCustomer();
            if (newC != null)
            {
                _db.AddNewCustomer(newC);
                input.NullButtons();
            }
            else
                input.NullButtons();
        }
	}
}
