using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_3.Models
{
	class Prospective_Student
	{
		//Name	Email	Term_Start	time	number_of_visits
		public string FirstName { get; set; }
		public string LastNme { get; set; }
		public string Floor { get; set; }
		public string Room { get; set; }
		public int Rent { get; set; }
		public string Type { get; set; }

		public Prospective_Student(string fname, string lname, string floor, string room, int rent, string studentType)
		{
			FirstName = fname;
			LastNme = lname;
			Floor = floor;
			Room = room;
			Rent = rent;
			Type = studentType;
		}

		/*Define a toString method 
		public override string ToString()
		{
			return String.Format($"Welcome, {Name}, Data: Email {Email}, Start Term: {StartTerm}, Time Format: {Time}, Number of visits to Dunwoody {NumberOfVisits}");
		}
		*/

	}
}
