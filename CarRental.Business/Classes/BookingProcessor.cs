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
using System.Linq.Expressions;

namespace CarRental.Business.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;

		public BookingProcessor(IData db)
        {
            _db = db;
        }
        public IEnumerable<Vehicle> GetVehicles(VehicleStatuses status = default)
        {
            if (status == default)
            {
			    return _db.Get<Vehicle>(null); 
            }
            else
                return _db.Get<Vehicle>(a => a.VehicleStatuses == status);
            //return _db.GetVehicles(status);
		}
        public IEnumerable<Customer> GetCustomers()
		{
			var customerList = _db.Get<IPerson>(null).Cast<Customer>().ToList();
			return customerList;
		}
		public IEnumerable<IBooking> GetBookings()
        {
            return _db.Get<IBooking>(null);
            //return _db.GetBookings();
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
		public IBooking ReturnVehicle(int vehicleId, double? distance)
        {
            var distRounded = Math.Ceiling((decimal)distance);
		    return _db.ReturnVehicle(vehicleId, (double)distRounded);       
        }
        public void AddVehicle(Inputs input, Vehicle? vehicle)
        {
            vehicle = input.AddNewVehicle();
            if (vehicle != null)
            {
                vehicle.SetId(_db.NextVehicleId);
                _db.Add(vehicle);
                input.NullButtons();
            }
            else
                input.NullButtons();
        }
        public void AddCustomer(Inputs input, IPerson? person)
        {
            person = input.AddNewCustomer();
            if (person != null)
            {
                person.Id = _db.NextPersonId;
                _db.Add(person);
                input.NullButtons();
            }
            else
                input.NullButtons();
		}
		// ------------ // Används ej 
		public Vehicle? GetVehicle(int vehicleId)
        {
            return _db.Single<Vehicle>(i => i.Id == vehicleId);
        }
		public Vehicle? GetVehicle(string regNo)
        {
            return _db.Single<Vehicle>(r=>r.RegNr == regNo);
        }
        public IPerson? GetPerson(string ssn)
        {
            return _db.Single<IPerson>(s => s.Ssn.ToString() == ssn);
        }
		public IBooking? GetBooking(int vehicleId)
        {
            return _db.Single<IBooking>(v => v.Id == vehicleId);
        }






		/* Metoder som ska finnas i bp - troligtvis med lambda uttryck
         * 
         * (x)IENumerable<IBooking> GetBookings()
         * (x)IBooking GetBooking(int vehicleId) - Finns inte i PDF'en
         * (x) IEnumerable<Customer> GetCustomers()
         * (x)IPerson? GetPerson(string ssn)
         * (x)IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
         * (x)IVehicle? GetVehicle(int vehicleId)
         * (x)IVehicle? GetVehicle(string regNo)
         * async Task<IBooking> RentVehicle(int vehicleId, int customerId)
         * {
         * }
         * (x)IBooking ReturnVehicle(int vehicleId, double distance) 
         * (x)void AddVehicle(string make, string regNo, double odometer, double costkm, vehiclestatuses status, vehicletypes type)
         * (x)void AddCustomer(string ssn, string firstname, string lastname)
         */
	}
}
