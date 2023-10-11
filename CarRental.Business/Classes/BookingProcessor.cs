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
        public bool IsProcessing { get; set; } = false;
        public string exceptionMessage = string.Empty;

		public BookingProcessor(IData db)
        {
            _db = db;
        }
        public IEnumerable<Vehicle> GetVehicles(VehicleStatuses status = default)
        {
            try
            {
            if (status == default)
            {
			    return _db.Get<Vehicle>(null); 
            }
            else
                return _db.Get<Vehicle>(a => a.VehicleStatuses == status);

            }
            catch (Exception ex)
            { 
                exceptionMessage = ex.Message;
                return default;
            }
		}
        public IEnumerable<Customer> GetCustomers()
		{
            try
            {
			var customerList = _db.Get<IPerson>(null).Cast<Customer>().ToList();
			return customerList;
            }
            catch (Exception ex)
            {
				exceptionMessage = ex.Message;
				return default;
			}
		}
		public IEnumerable<IBooking> GetBookings()
        {
            try
            {
            return _db.Get<IBooking>(null);
            }
			catch (Exception ex)
			{
				exceptionMessage = ex.Message;
				return default;
			}
		}
        public async Task<IBooking>? RentVehicleASYNC(int vehicleId, int customerId)
        {
            try
            {
			IsProcessing = true;
			await Task.Delay(10000);
            IsProcessing = false;
			return _db.RentVehicle(vehicleId, customerId);
            }
			catch (Exception ex)
			{
				exceptionMessage = ex.Message;
				return default;
			}
		}
		public IBooking ReturnVehicle(int vehicleId, double? distance)
        {
            try
            {
			var distRounded = Math.Ceiling((decimal)distance);
		    return _db.ReturnVehicle(vehicleId, (double)distRounded);       
            }
			catch (Exception ex)
			{
				exceptionMessage = ex.Message;
				return default;
			}
        }
        public void AddVehicle(Inputs input, Vehicle? vehicle)
        {
            try
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
			catch (Exception ex)
			{
				exceptionMessage = ex.Message;
			}
        }
        public void AddCustomer(Inputs input, IPerson? person)
        {
            try
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
			catch (Exception ex)
			{
				exceptionMessage = ex.Message;
			}
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
	}
}
