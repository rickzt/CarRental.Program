using CarRental.Common.Enums;

namespace CarRental.Common.Classes
{
	public class Customer
	{
		public int ssn;
		public string lastName;
		public string firstName;

		public Customer(int ssn, string lastName, string firstName)
		{
			this.ssn = ssn;
			this.lastName = lastName;
			this.firstName = firstName;
		}
	}
}
