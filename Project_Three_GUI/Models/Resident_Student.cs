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
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Floor { get; set; }
		public int Room { get; set; }
		public int Rent { get; set; }
		public string Type { get; set; }

		public Resident_Student(int id, string fname, string lname, int floor, int room, int rent, string studentType)
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
