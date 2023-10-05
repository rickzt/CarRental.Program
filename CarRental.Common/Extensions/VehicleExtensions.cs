using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Extensions;

public static class VehicleExtensions
{
	public static int Duration(this DateTime startDate, DateTime endDate)
	{
		var duration = (int)(endDate - startDate).TotalDays;
		return duration;
	}
}
