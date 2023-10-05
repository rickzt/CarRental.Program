using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes
{
	public class Customer : IPerson
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int? Ssn { get; init; }
		public int Id { get; set; }

		public Customer(int? ssn, string lastName, string firstName)
		{
			this.Ssn = ssn;
			this.LastName = lastName;
			this.FirstName = firstName;
		}
		public Customer(int id, int? ssn, string lastName, string firstName)
		{
			this.Id = id;
			this.Ssn = ssn;
			this.LastName = lastName;
			this.FirstName = firstName;
		}
		public Customer(int id, IPerson person)
		{
			Id = id;
			Ssn = person.Ssn;
			LastName = person.LastName;
			FirstName = person.FirstName;
		}
	}
}
