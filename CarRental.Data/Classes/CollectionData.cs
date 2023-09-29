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

		void SeedData()
		{
			_vehicles.Add(new Car(1, "ABC123", "Volvo", 7000, 2, VehicleTypes.Combi, 150, VehicleStatuses.Booked));
			_vehicles.Add(new Car(2, "BAC412", "Audi", 5000, 1.5, VehicleTypes.Sedan, 250, VehicleStatuses.Available));
			_vehicles.Add(new Car(3, "SKT182", "Ford", 7650, 1, VehicleTypes.Van, 125, VehicleStatuses.Available));
			_vehicles.Add(new Car(4, "QPS991", "Jeep", 2475, 3, VehicleTypes.Combi, 225, VehicleStatuses.Available));
			_vehicles.Add(new Motorcycle(5, "MMA572", "Yamaha", 1250, 3.5, 275, VehicleStatuses.Available));
			_vehicles.Add(new Car(6, "LGA251", "Ford", 5972, 1, VehicleTypes.Sedan, 150, VehicleStatuses.Available));
			_vehicles.Add(new Car(7, "PGE501", "Volvo", 5500, 2, VehicleTypes.Combi, 175, VehicleStatuses.Available));

			_persons.Add(new Customer(123456, "Svensson", "Jonas"));
			_persons.Add(new Customer(654321, "Andersson", "Andreas"));
			_persons.Add(new Customer(185235, "Enkvist", "Johan"));
			_persons.Add(new Customer(292452, "Andersson", "Anna"));
			_persons.Add(new Customer(563472, "Svantesson", "Greger"));

			// Ändra bookingstatuses till vehiclestatuses.
			_bookings.Add(new Booking(_vehicles[0], _persons[0], null, new DateTime(2023, 09, 23), null, BookingStatuses.Open));
			_bookings.Add(new Booking(_vehicles[1], _persons[1], 5051, new DateTime(2023, 09, 15), new DateTime(2023, 09, 27), BookingStatuses.Closed));
			_bookings.Add(new Booking(_vehicles[3], _persons[2], 2502, new DateTime(2023, 09, 25), DateTime.Today, BookingStatuses.Closed));



			//_bookings.Add(new Booking(new Car("LGA251", null, 1, null), "Johan Enkvist (185235)", 10000, new DateTime(2011, 02, 02), null, BookingStatuses.Open)); ;
			//_bookings.Add(new Booking(new Car("PGE501", 175, 2, 5500), "Anna Andersson (292452)", 5000,  new DateTime(2011, 02, 15), new DateTime(2011, 03, 03),  BookingStatuses.Closed));
			//_bookings.Add(new Booking(new Car("GKA812", 175, 1.5, 5251), "Johan Åkesson (526737)", 5000, new DateTime(2011, 02, 07), new DateTime(2011, 02, 23),  BookingStatuses.Closed));
            //_bookings.Add(new Booking(new Car("GAJ285", 185, 2.3, 2401),"Greger Svantesson (563472)", 2312, new DateTime(2011, 01, 02), new DateTime(2011, 01, 15), BookingStatuses.Closed));

			// Nullarna på Johan ändras vid return.
			//_bookings.Add(new Booking(new Car(6, "LGA251", "Ford", null, 1, VehicleTypes.Sedan, 150, VehicleStatuses.Booked), new Customer(185235, "Enkvist", "Johan"), 10000, new DateTime(2011, 02, 02), null, BookingStatuses.Open));
			//_bookings.Add(new Booking(new Car(7, "PGE501", "Volvo", 5500, 2, VehicleTypes.Combi, 175, VehicleStatuses.Booked), new Customer(292452, "Andersson", "Anna"), 5000, new DateTime(2011, 02, 02), DateTime.Today, BookingStatuses.Open));






		}

		public IEnumerable<IPerson> GetPersons() => _persons;
		public IEnumerable<IBooking> GetBookings() => _bookings;
		public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => 
			status == default ? _vehicles : _vehicles.Where(a => a.VehicleStatuses == status);
		public void AddNewVehicle(IVehicle v)
		{
			_vehicles.Add(v);
		}
		public void AddNewCustomer(IPerson v)
		{
			_persons.Add(v);
		}

	}
}
