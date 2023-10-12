using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace CarRental.Common.Classes;


public class Car : Vehicle
{  

	public Car (int? id, string regNr, string maker, int? odometer, double? costKm, VehicleTypes vechicleTypes, int? costDay, VehicleStatuses vehicleStatuses)
	{
		SetId(id);
		this.RegNr = regNr;
		this.Maker = maker;
		this.Odometer = odometer;
		this.CostKm = costKm;
		this.VehicleTypes = vechicleTypes;
		this.CostDay = costDay;
		this.VehicleStatuses = vehicleStatuses;
		this.TempCustomerId = null;
	}
	public Car(string regNr, string maker, int? odometer, double? costKm, VehicleTypes vechicleTypes, int? costDay, VehicleStatuses vehicleStatuses)
	{
		this.RegNr = regNr;
		this.Maker = maker;
		this.Odometer = odometer;
		this.CostKm = costKm;
		this.VehicleTypes = vechicleTypes;
		this.CostDay = costDay;
		this.VehicleStatuses = vehicleStatuses;
	}
	public VehicleTypes GetVehicleTypes()
	{ return VehicleTypes; }
	
}
