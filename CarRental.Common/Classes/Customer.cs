using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
	public class Customer : IPerson
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int? Ssn { get; init; }

		public Customer(int? ssn, string lastName, string firstName)
		{
			this.Ssn = ssn;
			this.LastName = lastName;
			this.FirstName = firstName;
		}
	}
}
