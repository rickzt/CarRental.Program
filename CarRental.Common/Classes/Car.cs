using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace CarRental.Common.Classes;


public class Car : IVehicle
{
		public int Id { get; private set; }    
		public string RegNr { get; init; }
        public string Maker { get; init; }
        public int? Odometer { get; set; }
        public int? CostDay { get; set; }
        public double? CostKm { get; set; }
		public VehicleTypes VehicleTypes { get; set; }
		public VehicleStatuses VehicleStatuses { get; set; }

	public Car (int id, string regNr, string maker, int? odometer, double? costKm, VehicleTypes vechicleTypes, int? costDay, VehicleStatuses vehicleStatuses)
	{
		this.Id = id;
		this.RegNr = regNr;
		this.Maker = maker;
		this.Odometer = odometer;
		this.CostKm = costKm;
		this.VehicleTypes = vechicleTypes;
		this.CostDay = costDay;
		this.VehicleStatuses = vehicleStatuses;
	}
	// utan ID
	public Car( string regNr, string maker, int? odometer, double? costKm, VehicleTypes vechicleTypes, int? costDay, VehicleStatuses vehicleStatuses)
	{
		this.RegNr = regNr;
		this.Maker = maker;
		this.Odometer = odometer;
		this.CostKm = costKm;
		this.VehicleTypes = vechicleTypes;
		this.CostDay = costDay;
		this.VehicleStatuses = vehicleStatuses;
	}
	public Car(int id, IVehicle car)
	{
		this.Id = id;
		this.RegNr = car.RegNr;
		this.Maker = car.Maker;
		this.Odometer = car.Odometer;
		this.CostKm = car.CostKm;
		this.VehicleTypes = car.GetVehicleTypes();
		this.CostDay = car.CostDay;
		this.VehicleStatuses = car.VehicleStatuses;
	}
	public VehicleTypes GetVehicleTypes()
	{ return VehicleTypes; }
}
