using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;


public class Car : IVehicle
{
        public string RegNr { get; init; }
        public string Maker { get; init; }
        public int? Odometer { get; set; }
        public int? CostDay { get; set; }
        public double CostKm { get; set; }
		public VehicleTypes VehicleTypes { get; set; }
		public VehicleStatuses VehicleStatuses { get; set; }


	public Car (string regNr, string maker, int odometer, double costKm, VehicleTypes vechicleTypes, int costDay, VehicleStatuses vehicleStatuses)
	{
		this.RegNr = regNr;
		this.Maker = maker;
		this.Odometer = odometer;
		this.CostKm = costKm;
		this.VehicleTypes = vechicleTypes;
		this.CostDay = costDay;
		this.VehicleStatuses = vehicleStatuses;
	}
	// Constructor for booking.
	public Car(string regNr, int? costDay, double costKm, int? odometer) => (RegNr, CostDay, CostKm, Odometer) = (regNr, costDay, costKm, odometer);
	public VehicleTypes GetVehicleTypes()
	{ return VehicleTypes; }

}
