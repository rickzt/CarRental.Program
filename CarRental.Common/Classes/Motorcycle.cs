using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Motorcycle : IVehicle
{
	// Private om de tilldelas via constructor, public om man vill kunna anropa via t.ex car.regNr
	public string regNr { get; set; }
	public string maker { get; set; }
	public int odometer { get; set; }
	public int costDay { get; set; }
	public double costKm { get; set; }
	public VehicleTypes vehicleTypes = VehicleTypes.Motorcycle;
	public VehicleStatuses vehicleStatuses { get; set; }


	public Motorcycle(string regNr, string maker, int odometer, double costKm, int costDay, VehicleStatuses vehicleStatuses)
	{
		this.regNr = regNr;
		this.maker = maker;
		this.odometer = odometer;
		this.costKm = costKm;

		this.costDay = costDay;
		this.vehicleStatuses = vehicleStatuses;
	}
	public VehicleTypes GetVehicleTypes() { return vehicleTypes; }
}
