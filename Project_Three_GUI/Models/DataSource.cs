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
			const string PATH = @"C:\Users\gunkeec\Desktop\Residents File.csv";

			//FileStream input;
			//StreamReader read;
			string line;
			string[] data;
		List<Prospective_Student> prospectList = null;

			 public List<Prospective_Student> ReadData()
			{
				try
				{
				string line;
				string[] data;
				//List<Prospective_Student> prospectList = null;

				FileStream input = new FileStream(PATH, FileMode.Open, FileAccess.Read);
					StreamReader read = new StreamReader(input);
					line = read.ReadLine(); //primer
					prospectList = new List<Prospective_Student>();

					//Looping structure that's going to read in all of my records
					while (!read.EndOfStream)
					{
						//Our objective is to read in the records and create object instances
						data = read.ReadLine().Split(',');
						prospectList.Add(new Prospective_Student(Convert.ToInt32(data[0]),data[1], data[2], Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), data[6]));
						Console.WriteLine(prospectList[prospectList.Count - 1]);

						//line = read.ReadLine(); //primer


					}

					read.Dispose();
					input.Dispose();

				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
				return prospectList;
			}
			 public void writeData(List<Prospective_Student> prospectList)
			{
				//Write to a file
				FileStream output = new FileStream(PATH, FileMode.Create, FileAccess.Write);
				StreamWriter write = new StreamWriter(output);
				write.WriteLine("ID,First Name,Last Name,Floor,Room,Rent,Student Type");

				foreach (Prospective_Student x in prospectList)
				{
					//Write out each record
					write.WriteLine($"{x.ID.ToString()},{x.FirstName},{x.LastName},{x.Floor},{x.Room},{x.Rent.ToString()}, {x.Type}");
				}

				write.Dispose();
				output.Dispose();
			}




			//Add a new Object instance
			//prospectList.Add(new Prospective_Student("Khali", "khali@dunwoody.edu", "Fall 2018", "Day", 1));

	}


}

