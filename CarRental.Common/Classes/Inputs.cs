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

	public int customerId { get; set; }
	public int? Distance { get; set; }
	public bool Rented { get; set; } = false;
	public string RegNo { get; set; } = string.Empty;
	public string Make { get; set; } = string.Empty;
	public int? Odometer { get; set; } = null;
	public double? CostKm { get; set; } = null;
	public Customer Customer { get; set; }
	public int? CostDay { get; set; } = null;
	public VehicleTypes? VehicleType = default;
	public VehicleStatuses VehicleStatuses = VehicleStatuses.Available;
	public VehicleStatuses filteredStatuses { get; set; } = default;
	public int? Ssn { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public string Testmessage { get; set; } = string.Empty;
	public string ErrorMessage { get; set; } = string.Empty;



	public IVehicle? AddNewVehicle()
	{
		if (RegNo != string.Empty && Make != string.Empty && Odometer != null && CostKm != null && VehicleType != null/*  && testCostDay != null */)
		{
			if (VehicleType == VehicleTypes.Motorcycle)
			{
				// FIXA ID!! och cost/day
				var vehicle = new Motorcycle(0, RegNo, Make, Odometer, (double)CostKm, 150, VehicleStatuses);
				RegNo = string.Empty; Make = string.Empty; Odometer = null; CostKm = null; VehicleType = null;
				return vehicle;
			}
			else
			{
				// FIXA ID!! och cost/day
				var vehicle = new Car(0, RegNo, Make, (int)Odometer, (double)CostKm, (VehicleTypes)VehicleType, 150, VehicleStatuses);
				RegNo = string.Empty; Make = string.Empty; Odometer = null; CostKm = null; VehicleType = null;
				return vehicle;
			}
		}
		else
		{

			return null;
		}
	}
	public IPerson? AddNewCustomer()
	{
		if (Ssn > 0 && FirstName != string.Empty && LastName != string.Empty)
		{
			var customer = new Customer(Ssn, FirstName, LastName);
			Testmessage = "worked";
			return customer;
		}
		else
			Testmessage = "didnt work";
		return null;
	}
	public void NullButtons()
	{
		RegNo = string.Empty;
		Make = string.Empty;
		Odometer = null;
		CostKm = null;
		VehicleType = null;
		CostDay = null;
	}
	public void rentedtest()
	{
		Rented = true;
	}
}