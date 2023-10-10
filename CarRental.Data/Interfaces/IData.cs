
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Linq.Expressions;

namespace CarRental.Data.Interfaces;

public interface IData
{
/*	IEnumerable<IPerson> GetPersons(); // Hämta personer
	IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default); // Ta reda på om bilen är bokad eller inte
	IEnumerable<IBooking> GetBookings();  */

	List<T> Get<T>(Expression<Func<T, bool>> expression);
	T? Single<T>(Expression<Func<T, bool>> expression);
	public void Add<T>(T item);

	int NextVehicleId { get; }
	int NextBookingId { get; }
	int NextPersonId { get; }

	IBooking RentVehicle(int vehicleId, int customerId);
	IBooking ReturnVehicle(int vehicleId, double? distance);

/*	public string[] VehicleStatusNames();
	public string[] VehicleTypeNames();
	public VehicleTypes GetVehicleType(string name);*/


	// DEN GENERISKA GET - SÖK UPP REFLECTION 


	// Hämta bokningar
	//IBooking GetBooking (int vehicleId);
	//IPerson GetPerson(string socialSecurityNumber);
	//IPerson GetPerson(int id);
	//IVehicle GetVehicle(string registrationNumber);
	//IVehicle GetVehicle(int id);


/*	void AddNewVehicle(IVehicle v);
	void AddNewCustomer(IPerson v);*/
}
