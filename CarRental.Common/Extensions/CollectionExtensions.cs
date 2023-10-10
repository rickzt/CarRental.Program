﻿using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Extensions;

public static class CollectionExtensions
{
    public static VehicleStatuses ChangeStatus(this VehicleStatuses status)
    {
        if (status == VehicleStatuses.Booked)
            return VehicleStatuses.Available;
        else return VehicleStatuses.Booked;
    }
}
