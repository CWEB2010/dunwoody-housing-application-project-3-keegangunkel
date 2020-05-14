using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Project_3.Models;

namespace Project_3.Models
{
    class DataSource
    {

			//DECLARATIONS
			const string PATH = @"C:\Users\gunkeec\Documents\Semester 2\Programming\Project_3_Keegan_Gunkel\Residents File.xlsx";

			//FileStream input;
			//StreamReader read;
			string line;
			string[] data;
		int athleteCount;
		int scholarshipCount;
		int workerCount;
		List<Resident_Student> residentList = null;
		List<Student_Count> countList = null;
		List<Student_Count> studentWorkerList = null;
		List<Student_Count> scholarshipList = null;

		public List<Resident_Student> ReadData()
			{
				try
				{
				string line;
				string[] data;
				//List<Prospective_Student> prospectList = null;

				FileStream input = new FileStream(PATH, FileMode.Open, FileAccess.Read);
					StreamReader read = new StreamReader(input);
					line = read.ReadLine(); //primer
					residentList = new List<Resident_Student>();

					//Looping structure that's going to read in all of my records
					while (!read.EndOfStream)
					{
						//Our objective is to read in the records and create object instances
						data = read.ReadLine().Split(',');
					residentList.Add(new Resident_Student(data[0], data[1], data[2], data[3], data[4], Convert.ToInt32(data[5]), data[6]));


				}

					read.Dispose();
					input.Dispose();

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				return residentList;
			}
			 public void WriteData(List<Resident_Student> residentList)
			{
				//Write to a file
				FileStream output = new FileStream(PATH, FileMode.Create, FileAccess.Write);
				StreamWriter write = new StreamWriter(output);
				write.WriteLine("ID,First Name,Last Name,Floor,Room,Rent,Student Type");

				foreach (Resident_Student x in residentList)
				{
					//Write out each record
					write.WriteLine($"{x.ID.ToString()},{x.FirstName},{x.LastName},{x.Floor},{x.Room},{x.Rent.ToString()}, {x.Type}");
				}

				write.Dispose();
				output.Dispose();
			}
		public List<Student_Count> CountList()
		{

			try
			{
				string line;
				string[] data;
				//List<Prospective_Student> prospectList = null;

				FileStream input = new FileStream(PATH, FileMode.Open, FileAccess.Read);
				StreamReader read = new StreamReader(input);
				line = read.ReadLine(); //primer
				countList = new List<Student_Count>();

				//Looping structure that's going to read in all of my records
				while (!read.EndOfStream)
				{
					//Our objective is to read in the records and create object instances
					data = read.ReadLine().Split(',');
					if (data[6].ToUpper() == "ATHLETE")
					{
						athleteCount += 1;
						countList.Add(new Student_Count(athleteCount,scholarshipCount,workerCount));
						
					}
					else if (data[6].ToUpper() == "SCHOLARSHIP")
					{
						scholarshipCount += 1;
						countList.Add(new Student_Count(athleteCount, scholarshipCount, workerCount));

					}
					if (data[6].ToUpper() == "STUDENT WORKER")
					{
						workerCount += 1;
						countList.Add(new Student_Count(athleteCount, scholarshipCount, workerCount));

					}
					//line = read.ReadLine(); //primer

				}

				read.Dispose();
				input.Dispose();

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return countList;



			}
			//Add a new Object instance
			//prospectList.Add(new Prospective_Student("Khali", "khali@dunwoody.edu", "Fall 2018", "Day", 1));

		



		
	//Add a new Object instance
	//prospectList.Add(new Prospective_Student("Khali", "khali@dunwoody.edu", "Fall 2018", "Day", 1));

	}


}

