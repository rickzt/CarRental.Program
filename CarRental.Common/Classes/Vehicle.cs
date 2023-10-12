using CarRental.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Classes;

abstract public class Vehicle
{
    public int? Id { get; private set; }
    public string RegNr { get; init; }
    public string Maker { get; init; }
    public int? Odometer { get; set; }
    public int? CostDay { get; set; }
    public double? CostKm { get; set; }
    public VehicleTypes VehicleTypes { get; set; }
    public VehicleStatuses VehicleStatuses { get; set; }
    public int? TempCustomerId {get; set; }
    public VehicleTypes GetVehicleTypes()
    { return VehicleTypes; }
    public void SetId(int? id)
    {
        if (id != null)
            Id = id;
    }


}
