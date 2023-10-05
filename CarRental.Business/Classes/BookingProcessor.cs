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
/*        public async Task<IBooking> RentVehicleASYNC(int vehicleId, int customerId)
         {
            _db.RentVehicle(vehicleId, customerId);
            await Task.Delay(10000);
            return default;
         }*/
		public IBooking RentVehicle(int vehicleId, int customerId)
		{
			return _db.RentVehicle(vehicleId, customerId);
		}
		public IBooking ReturnVehicle(int vehicleId, int? distance)
        {
            return _db.ReturnVehicle(vehicleId, distance);
        }
		public void AddNewVehicleButton(Inputs input, IVehicle? vehicle)
        {
            vehicle = input.AddNewVehicle();
            // Metod för assignID istället?
            var id = _db.GetVehicles().Max(x => x.Id) + 1;
            if (vehicle?.GetVehicleTypes() == VehicleTypes.Motorcycle && vehicle != null)
            {
                var newVehicle = new Motorcycle(id, vehicle);
				_db.AddNewVehicle(newVehicle);
			}
			else if (vehicle?.GetVehicleTypes() != VehicleTypes.Motorcycle && vehicle != null)
            {
				var newVehicle = new Motorcycle(id, vehicle);
				_db.AddNewVehicle(newVehicle);
                input.NullButtons();
            }
            else
                input.NullButtons();
		}
        public void AddNewCustomerButton(Inputs input, IPerson? customer)
        {
            customer = input.AddNewCustomer();
			var id = _db.GetPersons().Max(x => x.Id) + 1;
			if (customer != null)
            {
                var newCustomer = new Customer(id, customer);
                _db.AddNewCustomer(newCustomer);
                input.NullButtons();
            }
            else
                input.NullButtons();
        }
		/* Metoder som ska finnas i bp - troligtvis med lambda uttryck
         * 
         * IENumerable<IBooking> GetBookings()
         * IBooking GetBooking(int vehicleId) - Finns inte i PDF'en
         * IEnumerable<Customer> GetCustomers()
         * IPerson? GetPerson(string ssn)
         * IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
         * IVehicle? GetVehicle(int vehicleId)
         * IVehicle? GetVehicle(string regNo)
         * async Task<IBooking> RentVehicle(int vehicleId, int customerId)
         * {
         * }
         * IBooking ReturnVehicle(int vehicleId, double distance) 
         * void AddVehicle(string make, string regNo, double odometer, double costkm, vehiclestatuses status, vehicletypes type)
         * void AddCustomer(string ssn, string firstname, string lastname)
         */
		public string[] VehicleStatusNames => _db.VehicleStatusNames();
		public string[] VehicleTypeNames => _db.VehicleTypeNames();
		public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);
	}
}
