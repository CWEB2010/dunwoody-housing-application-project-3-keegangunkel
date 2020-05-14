using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_3.Models;


namespace Project_3.Models
{
	class Resident_Student
	{
		//Name	Email	Term_Start	time	number_of_visits
		public string ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Floor { get; set; }
		public string Room { get; set; }
		public double Rent { get; set; }
		public string Type { get; set; }

		public Resident_Student(string id, string fname, string lname, string floor, string room, double rent, string studentType)
		{
			ID = id;
			FirstName = fname;
			LastName = lname;
			Floor = floor;
			Room = room;
			Rent = rent;
			Type = studentType;
		}

		//Define a toString method 
		public override string ToString()
		{
			return String.Format($"{ID},{FirstName},{LastName},{Floor},{Room},{Rent},{Type}");
		}
		

	}
}
