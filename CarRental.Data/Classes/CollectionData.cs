using CarRental.Data.Interfaces;
using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Linq.Expressions;
using System.Data;
using System.Reflection;
using CarRental.Common.Extensions;


namespace CarRental.Data.Classes
{
	public class CollectionData : IData
	{
		readonly List<IPerson> _persons = new List<IPerson>();
		readonly List<Vehicle> _vehicles = new List<Vehicle>();
		readonly List<IBooking> _bookings = new List<IBooking>();
		
		public int NextVehicleId => (int)(_vehicles.Count.Equals(0) ? 1 : _vehicles.Max(g => g.Id) + 1);
		public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(g => g.Id) + 1;
		public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(g => g.Id) + 1;


		public List<T> Get<T>(Expression<Func<T, bool>> expression)
		{
		var list = GetListReflection<T>();
		if (expression == null || expression == default) return list;
		else return list.Where(expression.Compile()).ToList();
		}
		public T? Single<T>(Expression<Func<T, bool>> expression)
		{
			var list = GetListReflection<T>();
			if (expression == null || expression == default) throw new ArgumentNullException("No expression found");
			else return list.Single(expression.Compile());
		}
		public void Add<T>(T item)
		{
			var list = GetListReflection<T>();
			if (item == null) throw new ArgumentNullException();
			list?.Add(item);
		}
		private List<T>? GetListReflection<T>()
		{
			try
			{
				FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
				var list = fields.SingleOrDefault(f => f.FieldType == typeof(List<T>))?.GetValue(this) as List<T>;
				return list;
			}
			catch
			{
				throw;
			}
		}

		public IBooking RentVehicle(int vehicleId, int customerId)
		{
			var vehicle = _vehicles.Single(i => i.Id == vehicleId);
			vehicle.VehicleStatuses = vehicle.VehicleStatuses.ChangeStatus();
			vehicle.VehicleStatuses = VehicleStatuses.Booked;

			var customer = _persons.Single(i => i.Id == customerId);
			var booking = new Booking(NextBookingId, vehicle, customer, null, DateTime.Today, null, VehicleStatuses.Booked);
			_bookings.Add(booking);
			return booking;
		}

		public IBooking ReturnVehicle(int vehicleId, double? distance)
		{
            var vehicle = _vehicles.Single(y => y.Id == vehicleId);
			vehicle.VehicleStatuses = VehicleStatuses.Available;

		    var newOdometer = vehicle.Odometer + distance;
			vehicle.Odometer = (int?)newOdometer;

			var booking = _bookings.Single(i => i.Vehicle.Id == vehicleId && i.VehicleStatus == VehicleStatuses.Booked);

			booking.OdometerReturn = (int?)newOdometer;			
			booking.VehicleStatus = booking.VehicleStatus.ChangeStatus();
			booking.DateReturned = DateTime.Today;

			return booking;
		}

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
	}
}
