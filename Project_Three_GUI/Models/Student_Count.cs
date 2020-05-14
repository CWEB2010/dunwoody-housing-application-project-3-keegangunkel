using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_3.Models;

namespace Project_3.Models
{
    public class Student_Count
    {
        public int AthleteCount { get; set; }
		public int ScholarshipCount { get; set; }
		public int WorkerCount { get; set; }
		public Student_Count(int athleteCount, int scholarshipCount, int workerCount)
		{
			AthleteCount = athleteCount;
			ScholarshipCount = scholarshipCount;
			WorkerCount = workerCount;

		}
	}
	
}
