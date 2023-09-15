using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
	public class Customer : IPerson
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public int ssn { get; set; }

		public Customer(int ssn, string lastName, string firstName)
		{
			this.ssn = ssn;
			this.lastName = lastName;
			this.firstName = firstName;
		}
	}
}
