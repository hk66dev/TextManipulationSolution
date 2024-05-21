using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmissionLibrary
{
    public class Grade
    {
        public string PersonNumber { get; set; } = string.Empty;
        public double Grades { get; set; } = 0.0D;

        /// <summary>
        /// Constructor, all properties
        /// </summary>
        /// <param name="personNumber"></param>
        /// <param name="grade"></param>
        public Grade(string personNumber, double grade)
        {
            PersonNumber = personNumber;
            Grades = grade;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Grade()
        {
            PersonNumber = string.Empty;
            Grades = 0.0D;
        }
    }
}
