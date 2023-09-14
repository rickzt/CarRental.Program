using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Interfaces;

namespace CarRental.Business.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db;

        public BookingProcessor(IData db)
        {
            _db = db;
        }

        // Klasserna ska innehålla logik för att beräkna kostnader, kilometer m.m

        /*public IEnumerable<Customer> GetCustomers() // Using customer classes? ctrl + .
        {
            // return db.customers?
        }*/
        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
        {
            return _db.GetVehicles(status);
        }
        /*public IEnumerable<IBooking> GetBookings()
        {

        }*/

    }
}
