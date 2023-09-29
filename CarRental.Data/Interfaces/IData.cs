
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Data.Interfaces;

public interface IData
{
	IEnumerable<IPerson> GetPersons(); // Hämta personer
	IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default); // Ta reda på om bilen är bokad eller inte
	IEnumerable<IBooking> GetBookings(); 
	// Hämta bokningar
	//IBooking GetBooking (int vehicleId);
	//IPerson GetPerson(string socialSecurityNumber);
	//IPerson GetPerson(int id);
	//IVehicle GetVehicle(string registrationNumber);
	//IVehicle GetVehicle(int id);


	void AddNewVehicle(IVehicle v);
	void AddNewCustomer(IPerson v);
}
