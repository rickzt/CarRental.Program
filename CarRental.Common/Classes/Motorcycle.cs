using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Motorcycle : Vehicle
{

	public Motorcycle(int? id, string regNr, string maker, int? odometer, double? costKm, int? costDay, VehicleStatuses vehicleStatuses)
	{
        SetId(id);
        this.RegNr = regNr;
		this.Maker = maker;
		this.Odometer = odometer;
		this.CostKm = costKm;
		this.CostDay = costDay;
		this.VehicleStatuses = vehicleStatuses;
		this.VehicleTypes = VehicleTypes.Motorcycle;
	}
	public Motorcycle(int id, Vehicle motorcycle)
	{
        SetId(id);
        this.RegNr = motorcycle.RegNr;
		this.Maker = motorcycle.Maker;
		this.Odometer = motorcycle.Odometer;
		this.CostKm = motorcycle.CostKm;
		this.CostDay = motorcycle.CostDay;
		this.VehicleStatuses = motorcycle.VehicleStatuses;
		this.VehicleTypes = VehicleTypes.Motorcycle;
	}
}
