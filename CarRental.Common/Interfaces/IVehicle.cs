using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

public interface IVehicle
{
    string regNr { get; set; }
    string maker { get; set; }
    int odometer { get; set; }
    int costDay { get; set; }
    double costKm { get; set; }
	VehicleTypes vehicleTypes { get; set; }
	VehicleStatuses vehicleStatuses { get; set; }

}
