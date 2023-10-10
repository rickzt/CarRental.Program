
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Linq.Expressions;

namespace CarRental.Data.Interfaces;

public interface IData
{
	List<T> Get<T>(Expression<Func<T, bool>> expression);
	T? Single<T>(Expression<Func<T, bool>> expression);
	public void Add<T>(T item);

	int NextVehicleId { get; }
	int NextBookingId { get; }
	int NextPersonId { get; }

	IBooking RentVehicle(int vehicleId, int customerId);
	IBooking ReturnVehicle(int vehicleId, double? distance);
}


