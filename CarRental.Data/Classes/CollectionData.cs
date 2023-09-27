using CarRental.Data.Interfaces;
using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Diagnostics;

namespace CarRental.Data.Classes
{
	public class CollectionData : IData
	{
		readonly List<IPerson> _persons = new List<IPerson>();
		readonly List<IVehicle> _vehicles = new List<IVehicle>();
		readonly List<IBooking> _bookings = new List<IBooking>();
        //public IEnumerable<IVehicle> carList = new List<IVehicle>(); // Listan som ändras i UI't.

        public CollectionData() => SeedData();

		void SeedData()
		{
			_vehicles.Add(new Car("ABC123", "Volvo", 7000, 2, VehicleTypes.Combi, 150, VehicleStatuses.Booked));
			_vehicles.Add(new Car("BAC412", "Audi", 5000, 1.5, VehicleTypes.Sedan, 250, VehicleStatuses.Booked));
			_vehicles.Add(new Car("SKT182", "Ford", 7650, 1, VehicleTypes.Van, 125, VehicleStatuses.Available));
			_vehicles.Add(new Car("QPS991", "Jeep", 2475, 3, VehicleTypes.Combi, 225, VehicleStatuses.Booked));
			_vehicles.Add(new Motorcycle("MMA572", "Yamaha", 1250, 3.5, 275, VehicleStatuses.Available));

            _bookings.Add(new Booking(new Car("LGA251", null, 1, null), "Johan Enkvist (185235)", 10000, new DateTime(2011, 02, 02), null, BookingStatuses.Open)); ;
            _bookings.Add(new Booking(new Car("PGE501", 175, 2, 5500), "Anna Andersson (292452)", 5000,  new DateTime(2011, 02, 15), new DateTime(2011, 03, 03),  BookingStatuses.Closed));
			_bookings.Add(new Booking(new Car("GKA812", 175, 1.5, 5251), "Johan Åkesson (526737)", 5000, new DateTime(2011, 02, 07), new DateTime(2011, 02, 23),  BookingStatuses.Closed));
            _bookings.Add(new Booking(new Car("GAJ285", 185, 2.3, 2401),"Greger Svantesson (563472)", 2312, new DateTime(2011, 01, 02), new DateTime(2011, 01, 15), BookingStatuses.Closed));


            _persons.Add(new Customer(123456, "Svensson", "Jonas"));
			_persons.Add(new Customer(654321, "Andersson", "Andreas"));
		}

		public IEnumerable<IPerson> GetPersons() => _persons;
		public IEnumerable<IBooking> GetBookings() => _bookings;
		public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => 
			status == default ? _vehicles : _vehicles.Where(a => a.VehicleStatuses == status);
		public void AddNewVehicle(IVehicle v)
		{
			_vehicles.Add(v);
		}
	}
}
