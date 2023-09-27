using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRental.Common.Classes;

public class Inputs
{

	public string RegNo { get; set; } = string.Empty;
	public string Make { get; set; } = string.Empty;
	public int? Odometer { get; set; } = null;
	public double? CostKm { get; set; } = null;
	public int? CostDay { get; set; } = null;
	public VehicleTypes? VehicleType = default;
	public VehicleStatuses VehicleStatuses = VehicleStatuses.Available;
	public VehicleStatuses filteredStatuses { get; set; } = default;



	public IVehicle? AddNewVehicle()
	{
		if (RegNo != string.Empty && Make != string.Empty && Odometer != null && CostKm != null && VehicleType != null/*  && testCostDay != null */)
		{
			if (VehicleType == VehicleTypes.Motorcycle)
			{
				var vehicle = new Motorcycle(RegNo, Make, Odometer, (double)CostKm, 150, VehicleStatuses);
				RegNo = string.Empty; Make = string.Empty; Odometer = null; CostKm = null; VehicleType = null;
				return vehicle;
			}
			else
			{
				var vehicle = new Car(RegNo, Make, (int)Odometer, (double)CostKm, (VehicleTypes)VehicleType, 150, VehicleStatuses);
				RegNo = string.Empty; Make = string.Empty; Odometer = null; CostKm = null; VehicleType = null;
				return vehicle;
			}
		}
		else
		{

			return null;
		}
	}
	public void NullButtons()
	{
		RegNo = string.Empty;
		Make = string.Empty;
		Odometer = null;
		CostKm = null;
		VehicleType = null;
	}
}
