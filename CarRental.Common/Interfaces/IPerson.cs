using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Interfaces;

public interface IPerson
{
	string firstName { get; set; }
	string lastName { get; set; }
	int ssn { get; set; }
}
