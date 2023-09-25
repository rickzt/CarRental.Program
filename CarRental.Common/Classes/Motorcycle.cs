using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Motorcycle : IVehicle
{
	// Private om de tilldelas via constructor, public om man vill kunna anropa via t.ex car.regNr
	public string RegNr { get; init; }
	public string Maker { get; init; }
	public int Odometer { get; set; }
	public int CostDay { get; set; }
	public double CostKm { get; set; }
	public VehicleTypes VehicleTypes = VehicleTypes.Motorcycle;
	public VehicleStatuses VehicleStatuses { get; set; }


	public Motorcycle(string regNr, string maker, int odometer, double costKm, int costDay, VehicleStatuses vehicleStatuses)
	{
		this.RegNr = regNr;
		this.Maker = maker;
		this.Odometer = odometer;
		this.CostKm = costKm;
		this.CostDay = costDay;
		this.VehicleStatuses = vehicleStatuses;
	}
	public VehicleTypes GetVehicleTypes() { return VehicleTypes; }
}
