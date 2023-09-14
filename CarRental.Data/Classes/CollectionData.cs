using CarRental.Data.Interfaces;
using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Diagnostics;

namespace CarRental.Data.Classes
{
	public class CollectionData : IData
	{
		//readonly List<IPerson> _persons = new List<IPerson>();
		readonly List<IVehicle> _vehicles = new List<IVehicle>();
		//readonly List<IBooking> _bookings = new List<IBooking>();

		public CollectionData() => SeedData();

		void SeedData() // Lägg till kunder/bilar etc i listorna
		{
            _vehicles.Add(new Car("ABC123", "Volvo", 1, 7000, VehicleTypes.Combi, 150, VehicleStatuses.Booked));
        }

		//public IEnumerable<IPerson> GetPersons() => _persons;
		//public IEnumerable<IBooking> GetBookings() => _bookings;
		public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
	}
}
