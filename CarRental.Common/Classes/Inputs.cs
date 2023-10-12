﻿using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRental.Common.Classes;

public class Inputs
{
	public int? customerId { get; set; }
	public double? Distance { get; set; }
	public bool Rented { get; set; } = false;
	public string RegNo { get; set; } = string.Empty;
	public string Make { get; set; } = string.Empty;
	public int? Odometer { get; set; } = null;
	public double? CostKm { get; set; } = null;
	public Customer? Customer { get; set; }
	public int? CostDay { get; set; } = null;
	public VehicleTypes? VehicleType = default;
	public VehicleStatuses VehicleStatuses = VehicleStatuses.Available;
	public VehicleStatuses filteredStatuses { get; set; } = default;
	public int? Ssn { get; set; }
	public string? FirstName { get; set; } = string.Empty;
	public string? LastName { get; set; } = string.Empty;
	public string ErrorMessage { get; set; } = string.Empty;



	public Vehicle AddNewVehicle()
	{

		try
		{
			if (RegNo.Length.Equals(0) || RegNo == null) throw new ArgumentException("Must have a reg nr");
			if (Make.Length.Equals(0) || Make == null) throw new ArgumentException("Must have a maker");
			if (Odometer.Equals(0) || Odometer == null) throw new ArgumentException("Must enter Odometer value");
			if (CostKm.Equals(0) || CostKm == null) throw new ArgumentException("Must enter Cost per kilometer");
			if (VehicleType.Equals(0) || VehicleType == null) throw new ArgumentException("Must choose a vehicle type");
			if (CostDay.Equals(0) || CostDay == null) throw new ArgumentException("Must enter the cost per day");

			{
				if (VehicleType == VehicleTypes.Motorcycle)
				{
					var vehicle = new Motorcycle(null, RegNo, Make, Odometer, (double)CostKm, CostDay, VehicleStatuses);
					RegNo = string.Empty; Make = string.Empty; Odometer = null; CostKm = null; VehicleType = null;
					ErrorMessage = string.Empty;
					return vehicle;
				}
				else
				{
					var vehicle = new Car(null, RegNo, Make, (int)Odometer, (double)CostKm, (VehicleTypes)VehicleType, CostDay, VehicleStatuses);
					RegNo = string.Empty; Make = string.Empty; Odometer = null; CostKm = null; VehicleType = null;
					ErrorMessage = string.Empty;
					return vehicle;
				}

			}
		}
		catch (Exception ex)
		{
			ErrorMessage = ex.Message;
			return default;

		}
	}
	public IPerson? AddNewCustomer()
	{
		try
		{
			ErrorMessage = string.Empty;
			if (Ssn.Equals(0) || Ssn == null) throw new ArgumentException("Must enter a SSN");
			if (FirstName.Length.Equals(0) || FirstName == null) throw new ArgumentException("Must enter a first name");
			if (LastName.Length.Equals(0) || LastName == null) throw new ArgumentException("Must enter a last name");
			var customer = new Customer(Ssn, FirstName, LastName);
			return customer;
		}
		catch (Exception ex)
		{
			ErrorMessage = ex.Message;
			return default;
		}
	}
	public void NullButtons()
	{
		RegNo = string.Empty;
		Make = string.Empty;
		Odometer = null;
		CostKm = null;
		VehicleType = null;
		CostDay = null;
		Ssn = null;
		FirstName = string.Empty;
		LastName = string.Empty;
		Distance = null;
	}
	public void RentedStatus()
	{
		Rented = true;
	}
/*	public void SelectClient(ChangeEventArgs e)
	{
		if (e.Value != null) return;
		if (int.TryParse(e.ToString(), out int result));
		customerId = result;

		//customer => customer.id = result
	}*/
}