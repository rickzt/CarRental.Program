using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes

{
	public class Car : IVehicle
	{
        public string regNr { get; set; }
        public string maker { get; set; }
        public int odometer { get; set; }
        public int costDay { get; set; }
        public double costKm { get; set; }
        public VehicleTypes vehicleTypes { get; set; }
		public VehicleStatuses vehicleStatuses { get; set; }

		public Car (string regNr, string maker, int odometer, double costKm, VehicleTypes vechicleTypes, int costDay, VehicleStatuses vehicleStatuses)
		{
			this.regNr = regNr;
			this.maker = maker;
			this.odometer = odometer;
			this.costKm = costKm;
			this.vehicleTypes = vechicleTypes;
			this.costDay = costDay;
			this.vehicleStatuses = vehicleStatuses;
		}
    }
}
