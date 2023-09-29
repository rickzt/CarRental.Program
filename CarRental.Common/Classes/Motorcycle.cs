using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Motorcycle : IVehicle
{
	public int Id { get; private set; }
	public string RegNr { get; init; }
	public string Maker { get; init; }
	public int? Odometer { get; set; }
	public int? CostDay { get; set; }
	public double? CostKm { get; set; }
	public VehicleTypes VehicleTypes = VehicleTypes.Motorcycle;
	public VehicleStatuses VehicleStatuses { get; set; }


	public Motorcycle(int id, string regNr, string maker, int? odometer, double? costKm, int costDay, VehicleStatuses vehicleStatuses)
	{
		this.Id = id;
		this.RegNr = regNr;
		this.Maker = maker;
		this.Odometer = odometer;
		this.CostKm = costKm;
		this.CostDay = costDay;
		this.VehicleStatuses = vehicleStatuses;
	}
	public Motorcycle(int id, IVehicle motorcycle)
	{
		this.Id = id;
		this.RegNr = motorcycle.RegNr;
		this.Maker = motorcycle.Maker;
		this.Odometer = motorcycle.Odometer;
		this.CostKm = motorcycle.CostKm;
		this.VehicleTypes = motorcycle.GetVehicleTypes();
		this.CostDay = motorcycle.CostDay;
		this.VehicleStatuses = motorcycle.VehicleStatuses;
	}
	public VehicleTypes GetVehicleTypes() { return VehicleTypes; }
}
