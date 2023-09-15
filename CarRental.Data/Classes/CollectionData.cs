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

		public CollectionData() => SeedData();

		void SeedData() // Lägg till kunder/bilar etc i listorna
		{
			_vehicles.Add(new Car("ABC123", "Volvo", 1, 7000, VehicleTypes.Combi, 150, VehicleStatuses.Booked));
			_vehicles.Add(new Car("BAC412", "Audi", 1, 5000, VehicleTypes.Sedan, 250, VehicleStatuses.Booked));
			_vehicles.Add(new Car("SKT182", "Ford", 1, 8000, VehicleTypes.Van, 125, VehicleStatuses.Available));
			_vehicles.Add(new Car("QPS991", "Jeep", 1, 3500, VehicleTypes.Combi, 225, VehicleStatuses.Booked));
			_vehicles.Add(new Car("MMA572", "Yamaha", 1, 1250, VehicleTypes.Motorcycle, 275, VehicleStatuses.Available));

			_bookings.Add(new Booking("LGA251", "Johan Enkvist (185235)", 10000, null, new DateTime(2011, 02, 02), null, null, BookingStatuses.Open));;
			_bookings.Add(new Booking("PGE501", "Anna Andersson (292452)", 5000, 5500, new DateTime(2011, 02, 02), new DateTime(2011, 03, 03), 500, BookingStatuses.Closed));

			_persons.Add(new Customer(123456, "Svensson", "Jonas"));
			_persons.Add(new Customer(654321, "Andersson", "Andreas"));
		}

		public IEnumerable<IPerson> GetPersons() => _persons;
		public IEnumerable<IBooking> GetBookings() => _bookings;
		public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
	}
}
