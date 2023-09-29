using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

public interface IVehicle
{
	int Id { get; }
	string RegNr { get; init; }
    string Maker { get; init; }
    int? Odometer { get; set; }
    int? CostDay { get; set; }
    double? CostKm { get; set; }
    
	VehicleStatuses VehicleStatuses { get; set; }

    public VehicleTypes GetVehicleTypes();

}
