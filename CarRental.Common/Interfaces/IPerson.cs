using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

public interface IPerson
{
	string FirstName { get; set; }
	string LastName { get; set; }
	int? Ssn { get; init; }
}
