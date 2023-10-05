using CarRental.Data.Interfaces;
using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;
using System;

namespace CarRental.Data.Classes
{
	public class CollectionData : IData
	{
		readonly List<IPerson> _persons = new List<IPerson>();
		readonly List<IVehicle> _vehicles = new List<IVehicle>();
		readonly List<IBooking> _bookings = new List<IBooking>();

		// Ids - från video - Customer och Bookings behöver ID properties
		public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(g => g.Id) + 1;
		public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(g => g.Id) + 1;
		public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(g => g.Id) + 1;


		public List<T> Get<T>(Expression<Func<T, bool>> expression)
		{
			return default;
		}
		public T? Single<T>(Expression<Func<T, bool>> expression)
		{
			return default;
		}
		public void Add<T>(T item)
		{

		}
		public IBooking RentVehicle(int vehicleId, int customerId)
		{
			var vehicle = _vehicles.Single(i => i.Id == vehicleId);
			vehicle.VehicleStatuses = VehicleStatuses.Booked;

			var customer = _persons.Single(i => i.Id == customerId);
			var booking = new Booking(NextBookingId, vehicle, customer, null, DateTime.Today, null, VehicleStatuses.Booked);
			_bookings.Add(booking);
			return booking;


		}

		public IBooking ReturnVehicle(int vehicleId, int? distance)
		{
            var vehicle = _vehicles.Single(y => y.Id == vehicleId);
			vehicle.VehicleStatuses = VehicleStatuses.Available;

		    var newOdometer = vehicle.Odometer + distance;
			vehicle.Odometer = newOdometer;

			var booking = _bookings.Single(i => i.Vehicle.Id == vehicleId && i.RentedStatus == VehicleStatuses.Booked);

			booking.OdometerReturn = newOdometer;
            booking.RentedStatus = VehicleStatuses.Available;
			booking.DateReturned = DateTime.Today;

			//var booking = _bookings.Single(x=> x.Vehicle == vehicle);
			//booking.OdometerReturn = cost;

			return booking;
		}

		public string[] VehicleStatusNames() => Enum.GetNames(typeof(VehicleStatuses));
		public string[] VehicleTypeNames() => Enum.GetNames(typeof(VehicleTypes));
		public VehicleTypes GetVehicleType(string name) => (VehicleTypes)Enum.Parse(typeof(VehicleTypes), name);


		public CollectionData() => SeedData();

		void SeedData()
		{
			_vehicles.Add(new Car(NextVehicleId, "ABC123", "Volvo", 7000, 2, VehicleTypes.Combi, 150, VehicleStatuses.Available));
			_vehicles.Add(new Car(NextVehicleId, "BAC412", "Audi", 5000, 1.5, VehicleTypes.Sedan, 250, VehicleStatuses.Available));
			_vehicles.Add(new Car(NextVehicleId, "SKT182", "Ford", 7650, 1, VehicleTypes.Van, 125, VehicleStatuses.Available));
			_vehicles.Add(new Car(NextVehicleId, "QPS991", "Jeep", 2475, 3, VehicleTypes.Combi, 225, VehicleStatuses.Available));
			_vehicles.Add(new Motorcycle(NextVehicleId, "MMA572", "Yamaha", 1250, 3.5, 275, VehicleStatuses.Booked));
			_vehicles.Add(new Car(NextVehicleId, "LGA251", "Ford", 5972, 1, VehicleTypes.Sedan, 150, VehicleStatuses.Available));
			_vehicles.Add(new Car(NextVehicleId, "PGE501", "Volvo", 5500, 2, VehicleTypes.Combi, 175, VehicleStatuses.Available));

			_persons.Add(new Customer(NextPersonId, 123456, "Svensson", "Jonas"));
			_persons.Add(new Customer(NextPersonId, 654321, "Andersson", "Andreas"));
			_persons.Add(new Customer(NextPersonId, 185235, "Enkvist", "Johan"));
			_persons.Add(new Customer(NextPersonId, 292452, "Andersson", "Anna"));
			_persons.Add(new Customer(NextPersonId, 563472, "Svantesson", "Greger"));

			_bookings.Add(new Booking(NextBookingId, _vehicles[4], _persons[0], null, new DateTime(2023, 09, 23), null, VehicleStatuses.Booked));
			_bookings.Add(new Booking(NextBookingId, _vehicles[1], _persons[1], 5051, new DateTime(2023, 09, 15), new DateTime(2023, 09, 27), VehicleStatuses.Available));
			_bookings.Add(new Booking(NextBookingId, _vehicles[3], _persons[2], 2502, new DateTime(2023, 09, 25), DateTime.Today, VehicleStatuses.Available));
		}




		//_bookings.Add(new Booking(new Car("LGA251", null, 1, null), "Johan Enkvist (185235)", 10000, new DateTime(2011, 02, 02), null, BookingStatuses.Open)); ;
		//_bookings.Add(new Booking(new Car("PGE501", 175, 2, 5500), "Anna Andersson (292452)", 5000,  new DateTime(2011, 02, 15), new DateTime(2011, 03, 03),  BookingStatuses.Closed));
		//_bookings.Add(new Booking(new Car("GKA812", 175, 1.5, 5251), "Johan Åkesson (526737)", 5000, new DateTime(2011, 02, 07), new DateTime(2011, 02, 23),  BookingStatuses.Closed));
		//_bookings.Add(new Booking(new Car("GAJ285", 185, 2.3, 2401),"Greger Svantesson (563472)", 2312, new DateTime(2011, 01, 02), new DateTime(2011, 01, 15), BookingStatuses.Closed));

		// Nullarna på Johan ändras vid return.
		//_bookings.Add(new Booking(new Car(6, "LGA251", "Ford", null, 1, VehicleTypes.Sedan, 150, VehicleStatuses.Booked), new Customer(185235, "Enkvist", "Johan"), 10000, new DateTime(2011, 02, 02), null, BookingStatuses.Open));
		//_bookings.Add(new Booking(new Car(7, "PGE501", "Volvo", 5500, 2, VehicleTypes.Combi, 175, VehicleStatuses.Booked), new Customer(292452, "Andersson", "Anna"), 5000, new DateTime(2011, 02, 02), DateTime.Today, BookingStatuses.Open));







		/* * Todo:
		 * RentVehicle/Rent metod
		 * ReturnVehicle/Return metod
		 * 
		 * Get-Persons-Bookings-Vehicles får inte finnas. Måste vara generiska. En Get metod där man skickar in ett lambda uttryck i parantesen för att filtrera data
		 * t.ex Hämta alla personer vars namn är John eller hämta alla bilar med en viss vehicletype
		 * Get metoden ska hämta en lista på allt som matchar.
		 * Single metod ska hämta EN sak (t.ex person via personnr eller en bil via regnr)
		 * 
		 * en Add metod där man kan lägga till person/bokning/fordon
		 * 
		 * Get - returnerar lista med lambda uttryck (filter)
		 * Single - returnerar EN sak med lambra uttryck (filter)
		 * Add - lägger till valfri (person, bil, booking) 
		*/


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
